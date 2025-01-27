using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UnitAnimationController : MonoBehaviour
{

    public Animator animator;

    bool isLocked;

    Coroutine currentAnim;
    Tween punch;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnim(string animName)
    {
        if(!isLocked)
        {
            if(currentAnim!= null)StopCoroutine(currentAnim);

            currentAnim = StartCoroutine(PlayAnim(animName));
        }
            
    }

    
    public void StartAnimWithLock(string animName)
    {
        //transform.localScale = Vector2.one;
        //Tween punch = transform.DOPunchScale(new Vector2(0.5f, 0.5f), 0.4f, 3, 0.3f);
        isLocked = true;
        if(currentAnim!= null) StopCoroutine(currentAnim);

        
        //currentAnim = null;
        currentAnim = StartCoroutine(PlayAnim(animName));
    }

    public IEnumerator PlayAnim(string _animName)
    {
        //if(animator.GetCurrentAnimatorStateInfo(0).IsName(_animName))
        //     animator.Play("Empty");
        animator.Play(_animName, -1, 0);
        //Debug.Log(_animName + " Длительность анимации " + animator.GetCurrentAnimatorStateInfo(0).length);
        //RuntimeAnimatorController ac = animator.runtimeAnimatorController; 
        yield return new WaitForSeconds(0.01f);
        Debug.Log(_animName + " Длительность анимации " + animator.GetCurrentAnimatorStateInfo(0).length); //animator.GetCurrentAnimatorClipInfo(0).Length
        
        punch.Kill();
        transform.localScale = Vector2.one;
        //punch = transform.DOPunchScale(new Vector2(0.5f, 0.5f), 0.3f, 3, 0.3f);
        
        
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        punch.Kill();
        punch = null;
        transform.localScale = Vector2.one;
        //Debug.Log(_animName + " Длительность анимации " + animator.GetCurrentAnimatorClipInfo(0).Length);
        //yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        isLocked = false;
        //animator.Play("Idle");
    }

}
