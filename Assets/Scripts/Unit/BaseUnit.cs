using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States {Wall, Wait, Go, Idle, Hit, Raying, GoBack};


public class BaseUnit : MonoBehaviour
{
    
    //////////// Действия
    
    List<ICommonState> commons;
    List<IWalkState> walk;
    
    List<IWallState> walkToWall;

    List<IHitState> hit;
        
    Iinputs iinputs;

    public Tile currentTile;
    
    /////////// Персонаж (хп + урон)    
    
    [SerializeField]
    HealthBar hBar;
    public int damage;
    public int hp = 10;

    public GameObject sprite;
    public Transform spriteLerpTransform;

    
    public int maxHp = 10;

    float speed = 7;
    
    //////////////// Стейт машина
   
    States state;

    Vector2 direction;

    Vector2 lerpStart, lerpEnd;

    

    GameObject rayedObj;
    
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
        switch(state)
        {
            case States.Idle:
                
                direction = iinputs.Inp();
                //Debug.Log(direction);
                if(direction != Vector2.zero)
                {
                    FacingRight(direction);
                    foreach (var item in commons)
                    {
                        item.DoAction(this);
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
                state = States.Idle;
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
        hp -= _damage;
        hBar.UpdateHealthBar(hp,maxHp);
        StartCoroutine(Effects.Shake(5, sprite));

        if(hp<=0)
        {
            EnemySpawner.Instance.DeleteEnemyFromList(this);
            currentTile.SetEmpty();
            Destroy(this.gameObject);
            
        }
    }  

    void FacingRight(Vector2 dir)
    {
        if(dir.x > 0)
            sprite.GetComponent<SpriteRenderer>().flipX = false;
        else if (dir.x < 0)
            sprite.GetComponent<SpriteRenderer>().flipX = true;
    }
    
}
