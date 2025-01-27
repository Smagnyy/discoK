using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    Color steppedColor;
    //[SerializeField]
    //public int id;

    int damage;
    public TMP_Text textOnTile;

    public List<Color> colors;

    [SerializeField]
    bool isPlayerStay;

    [SerializeField]
    bool isEmpty = true;

    SpriteRenderer sprRend;
    public Coroutine FadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerOnThisTile()
    {
        isPlayerStay = !isPlayerStay;
        //isEmpty = !isEmpty;
    }

    public bool GetPlayer()
    {
        return isPlayerStay;
    }
        
    
   

    public void SetEmpty()
    {
        isEmpty = !isEmpty;
    }

    public bool GetEmpty()
    {
        return isEmpty;
    }
    

    public void ChangeColor()
    {       
        sprRend.color = steppedColor;
        //sprRend.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
        //sprRend.color = colors[Random.Range(0, colors.Count)];
        //Debug.Log("color code = " + sprRend.color);
    }

    public void UnChangeColor()
    {
        FadeAnim = StartCoroutine(Effects.Fade(sprRend, sprRend.color, new Color(1, 1, 1), 5));
        Debug.Log("COLOR!!!");
        
    }

    
}
