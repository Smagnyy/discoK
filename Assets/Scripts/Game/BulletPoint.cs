using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class BulletPoint : MonoBehaviour
{
    public Image frame;
    public TMP_Text countText;
    public Image explosionIMG;

    
    public Image bulletImage;
    
    public Tile ownedTile;

    int counter;
   

    
    void Start()
    {
        counter = 3;
        countText.text = counter.ToString();
    }

    
    void Update()
    {
         frame.transform.localScale = new Vector2 (0.75f + Mathf.PingPong(Time.time/3, 0.25f), 0.75f + Mathf.PingPong(Time.time/3, 0.25f));

         if(Input.GetKeyDown(KeyCode.J))
         {
            Count();
         }
    }

    void Count()
    {
        counter--;
        countText.text = counter.ToString();

        if(counter == 1)
        {
            countText.gameObject.SetActive(false);
            bulletImage.transform.localPosition = Vector2.zero;
            bulletImage.rectTransform.sizeDelta = new Vector2(0.8f,0.8f);
        }
        if(counter<=0)
        {
            frame.gameObject.SetActive(false);
            explosionIMG.gameObject.SetActive(true);
            StartCoroutine(MakeExplosion());
            RaycastHit2D ray = Physics2D.Raycast((Vector2)transform.position, Vector2.zero, 0, GlobalValues.layerMaskOfUnit);
            Debug.Log(ray.collider);
            if(ray.collider != null && ray.collider.GetComponent<BaseUnit>() != null)
            {
                ray.collider.GetComponent<BaseUnit>().DecreaseHP(1);
                Debug.Log("ПОПАДАНИЕ");
            }
            else
            {
                Debug.Log("не попал");
            }
            ownedTile.SetEffect();
            
        }
    }

    IEnumerator MakeExplosion()
    {
        yield return explosionIMG.DOFade(0, 0.3f).WaitForCompletion();
        Destroy(this.gameObject);
    }

}
