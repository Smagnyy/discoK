using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int amount;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
        animator.Play("coinDrop");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            GlobalValues.money += amount;
            UI_main.Instance.UpdateMoneyText();
            GlobalContentContainer.Instance.spawnedCoins.Remove(this);
            Destroy(this.gameObject);
        }
        else if(collision.GetComponent<InputGoldStalker>())
        {
            collision.GetComponent<InputGoldStalker>().moneyAmount += amount;
            GlobalContentContainer.Instance.spawnedCoins.Remove(this);
            Destroy(this.gameObject);
        }
        

    }
}
