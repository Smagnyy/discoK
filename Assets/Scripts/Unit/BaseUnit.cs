using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States {Wall, Wait, Go, Idle, Hit, Raying, GoBack};


public class BaseUnit : MonoBehaviour
{

    public List<SpriteRenderer> bodyParts;

    //////////// Звук
    
    AudioSource audioSrc;
    
    //////////// Действия
    
    List<ICommonState> commons;
    List<IWalkState> walk;
    
    List<IWallState> walkToWall;

    List<IHitState> hit;

    List<IDeathState> deathStates;
        
    public Iinputs iinputs;

    public Tile currentTile;
    
    /////////// Персонаж (хп + урон)    
    
    [SerializeField]
    public HealthBar hBar;
    public int damage;
    [SerializeField]
    public int hp = 10;

    public GameObject sprite;
    public Transform spriteLerpTransform;

    
    public int maxHp = 10;

    float speed = 7;
    
    //////////////// Стейт машина
   
    States state;

    Vector2 direction;

    Vector2 lerpStart, lerpEnd;

    public bool canStep;

    GameObject rayedObj;

    public Transform objToFlip;

    //public Animator animator;
    
    public UnitAnimationController AnimContr;

    public UnitSoundSys unitSoundSys;

    private void Awake() 
    {
        
        
    }
    
    
    void Start()
    {
        
        iinputs = GetComponent<Iinputs>();
        walk = GetComponentsInChildren<IWalkState>().ToList();
        walkToWall = GetComponentsInChildren<IWallState>().ToList();
        hit = GetComponentsInChildren<IHitState>().ToList();
        commons = GetComponentsInChildren<ICommonState>().ToList();
        deathStates = GetComponentsInChildren<IDeathState>().ToList();


        //audioSrc = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();
        AnimContr = GetComponent<UnitAnimationController>();
        unitSoundSys = GetComponent<UnitSoundSys>();


        bodyParts.AddRange(GetComponentsInChildren<SpriteRenderer>());

        hBar.UpdateHealthBar(hp,maxHp);

        state = States.Idle;
        
        RaycastHit2D[] res = Physics2D.RaycastAll(transform.position, Vector2.zero, 0, LayerMask.GetMask("Tile")); // 
        foreach (var item in res)
        {
            Debug.Log(" нашел " +item.transform);
        }
        
        currentTile = res[0].transform.GetComponent<Tile>();
        currentTile.SetEmpty();
    }

    
    void Update()
    {
        Debug.Log("Insrance" + GlobalContentContainer.Instance);
        switch(state)
        {
            case States.Idle:
                //if(AnimContr != null)  AnimContr.StartAnimWithLock("Idle");  
                if(canStep || GetComponent<Player>())
                {                    
                    direction = iinputs.Inp();
                    canStep = false;
                }
                    
                //Debug.Log(direction);
                if(direction != Vector2.zero)
                {
                    FacingRight(direction);
                    foreach (var item in commons)
                    {
                        item.DoAction(this);
                    }
                    if(AnimContr != null)  
                    {
                        AnimContr.StartAnimWithLock("AttackBlTree"); //"AttackBlTree"
                        AnimContr.animator.SetFloat("x",direction.x);
                        AnimContr.animator.SetFloat("y",direction.y);
                        
                    }
                    
                    state = States.Raying;              
                }
            break;
            case States.Raying:
                              
                States newState = StaticRaying.RayAll(direction, out rayedObj, this.transform);
                
                lerpStart = transform.position;
                lerpEnd = lerpStart + direction;
                state = newState;
            break;

            case States.Go:
                currentTile.SetEmpty();
                if(unitSoundSys!= null) unitSoundSys.PlaySound(GlobalContentContainer.Instance.TagGameSounds[Random.Range(0,GlobalContentContainer.Instance.TagGameSounds.Count)]);
                transform.position = lerpEnd;
                spriteLerpTransform.position = lerpStart;   
                StartCoroutine(StaticLerpSteps.LerpStep(spriteLerpTransform, lerpStart, lerpEnd, speed));
                
                foreach (var item in walk)
                {
                    item.DoAction(rayedObj.GetComponent<Tile>());
                }
                
                currentTile = rayedObj.GetComponent<Tile>();
                currentTile.SetEmpty();

                state = States.Wait;
            break;
            
            case States.Wall:
                //StartCoroutine(StaticLerpSteps.LerpStepWithBackLocalPos(spriteLerpTransform, new Vector2(0,0), direction, speed));
                StartCoroutine(StaticLerpSteps.LerpStepWithBack(spriteLerpTransform, lerpStart, lerpEnd, speed));
                if(unitSoundSys!= null) unitSoundSys.PlaySound(unitSoundSys.wallCrashSound);
                if(walkToWall.Count>0)
                foreach (var item in walkToWall)
                {
                    item.DoAction();
                }
                lerpEnd = lerpStart;
                state = States.Wait;
            break;

            case States.Hit:
                //StartCoroutine(lerping.LerpStepWithBack(lerpStart, lerpEnd, true, rayedObj.GetComponent<BaseCharacter>()));
                StartCoroutine(StaticLerpSteps.LerpStepWithBack(spriteLerpTransform, lerpStart, lerpEnd, speed));
                if(hit.Count>0)
                foreach (var item in hit)
                {
                    item.DoAction(rayedObj.GetComponent<BaseUnit>());
                }
                lerpEnd = lerpStart;
                state = States.Wait;
            break;

            case States.Wait:
            if((Vector2)spriteLerpTransform.position == lerpEnd)
            {
                direction = Vector2.zero;
                if(AnimContr != null)  AnimContr.StartAnim("Idle");
                state = States.Idle;
            }

                
            break;
        }

   
       
    }


     public void ChangeState( States _state)
    {
        state = _state;
    }

    ///////// методы персонажа
    
     public void DecreaseHP(int _damage)
    {
        if(AnimContr != null)  AnimContr.StartAnimWithChange("GetDamage", "Idle");
        hp -= _damage;
        hBar.UpdateHealthBar(hp,maxHp);
        StartCoroutine(Effects.Shake(5, sprite));
        foreach (var item in commons)
        {
            item.Reset();
        }
        if(hp<=0)
        {
            //if(AnimContr != null)  AnimContr.StartAnimWithLock("Death");
            //EnemySpawner.Instance.DeleteEnemyFromList(this);
            currentTile.SetEmpty();
            
            if(deathStates.Count>0)
                foreach (var item in deathStates)
                {
                    item.DoAction(this);
                }

            //Destroy(this.gameObject);
            
        }
    }  

    void FacingRight(Vector2 dir)
    {
        if(objToFlip!=null)
        {
            if(dir.x > 0)
                objToFlip.localScale = new Vector3(1,1,1);//sprite.GetComponent<SpriteRenderer>().flipX = false;
            else if (dir.x < 0)
                objToFlip.localScale = new Vector3(-1,1,1);//sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }
    
}
