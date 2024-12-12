using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BaseUnit baseUnit;
    public static Player Instance;
    public int maxNumberOfSteps;
    public List<Tile> OwnedTiles = new List<Tile>();
    
     

    private void Awake() 
    {
        Instance = this;
        baseUnit = GetComponent<BaseUnit>();

    }

    void Start()
    {
        baseUnit.currentTile.SetPlayerOnThisTile();
    }

    public void StepOnTile(Tile steppedTile)
    {        
        steppedTile.SetPlayerOnThisTile(); 
        baseUnit.currentTile.SetPlayerOnThisTile();
        //if(baseUnit.currentTile!= null)
        //{
              
            OwnedTiles.Add(baseUnit.currentTile);
            if(OwnedTiles.Count> maxNumberOfSteps)
            {
                DeleteTile(0);
            }

            baseUnit.currentTile.textOnTile.text = OwnedTiles.Count.ToString();
            baseUnit.currentTile.ChangeColor();

            for(int i = 0; i< OwnedTiles.Count-1; i++)
            {
                OwnedTiles[i].textOnTile.text = "";
            }
            
            
        //}

        //baseUnit.currentTile = steppedTile;
        
    }

     public void StepOnOwnedTile(Tile _steppedTile)
    {   
        bool steppedOnOwnedTile = false;
        int numberOfSteppedTile = 0;
        //for (int i = 0; i < OwnedTiles.Count; i++)
        //{
        //    if(_steppedTile.id == OwnedTiles[i].id) 
        //    {
        //        steppedOnOwnedTile = true;
        //        numberOfSteppedTile = i;                
        //    }
        //}

        if(OwnedTiles.Contains(_steppedTile))
        {
            steppedOnOwnedTile = true;
            numberOfSteppedTile = OwnedTiles.IndexOf(_steppedTile);
        }
            

        if(steppedOnOwnedTile)
        {
           
            StopAllCoroutines();
            StartCoroutine(DeleteTilesInTurn(numberOfSteppedTile+1)); 
            //ChangeDamage();
            UpdateTextOnTile();
            /*
            for (int i = 0; i <= numberOfSteppedTile; i++)
            {                
                DeleteTile(0);
                ChangeDamage();
                UpdateTextOnTile();
            }*/
        }
    }

   
    public IEnumerator DeleteTilesInTurn(int lenght) 
    {   
        List<Tile> tilesToDelete = new List<Tile>();
        
        for (int i = 0; i < lenght; i++)
        {
            if(OwnedTiles[0] != baseUnit.currentTile)   //потом скорее всего удалю это условие                 
                tilesToDelete.Add(OwnedTiles[0]);
            OwnedTiles.RemoveAt(0);
        }
        
            for (int i = tilesToDelete.Count; i > 0; i--) //lenght
            {
                if(tilesToDelete.Count == 0)
                    yield break;
               
                Debug.Log(tilesToDelete.Count);
                //DeleteTile(0);
                tilesToDelete[0].UnChangeColor();
                tilesToDelete[0].textOnTile.text = "";
                tilesToDelete.RemoveAt(0);

                //UpdateTextOnTile();
                if(tilesToDelete.Count >= 1) 
                    tilesToDelete[tilesToDelete.Count-1].textOnTile.text = tilesToDelete.Count.ToString();

                yield return new WaitForSeconds(0.2f);
            }
        
        Debug.Log("Done");
        
    }
    
    void DeleteTile(int _i)
    {   
        if(OwnedTiles.Count > 0)
        {
            OwnedTiles[_i].UnChangeColor();
            OwnedTiles[_i].textOnTile.text = "";
            OwnedTiles.RemoveAt(_i);
            ChangeDamage();
            UpdateTextOnTile();   
        }
    }

     public void ChangeDamage()
    {
        baseUnit.damage = OwnedTiles.Count;
        
        if(OwnedTiles.Count == 0)
            baseUnit.damage = 1;
        //Debug.Log(bChar.damage);
    }

    public void UpdateTextOnTile()
    {    
            if(OwnedTiles.Count >= 1) 
                OwnedTiles[OwnedTiles.Count-1].textOnTile.text = OwnedTiles.Count.ToString();
    
    }

    /* мусор после удалятеля тайлов

    
    public void Hitted()
    {
        tilesToDelete.AddRange(OwnedTiles);
        OwnedTiles.Clear();
        StopAllCoroutines();
        StartCoroutine(DeleteTilesInTurn());
    }

    public void AddTileToDelete(int n)
    {
        for (int i = 0; i < n; i++)
        {
            if(OwnedTiles[0] != baseUnit.currentTile)                    
                tilesToDelete.Add(OwnedTiles[0]);
            OwnedTiles.RemoveAt(0);
        }
        StopAllCoroutines();
        StartCoroutine(DeleteTilesInTurn());
    }
    */
}
