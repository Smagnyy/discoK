using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public static TileGenerator Instance;
    public Tile tilePrefab;

    //public Tile[,] Map;

    public List<Tile> MAP;

    public int sizeX;
    public int sizeY;
    public Vector2 offset;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //int count = 1;
        //Map = new Tile[sizeX, sizeY];
        //for (int i = 0; i < sizeX; i++)
        //{
        //    for (int j = 0; j < sizeY; j++)
        //    {
        //        
        //        Tile newTile = Instantiate(tilePrefab, new Vector3(i-offset.x,j-offset.y,0), Quaternion.identity, this.transform);
        //        newTile.id = count;
        //        count++;
        //        Map[i, j] = newTile;
        //      
        //    }
        //}
    }

    public Tile FindEmpty()
    {
        List<Tile> freeTiles = new List<Tile>();

        
        foreach (Tile item in MAP) //foreach (Tile item in Map)
        {
            if(item.GetEmpty() == true)
            {
                freeTiles.Add(item);
            }
        }

        int selectedTile = Random.Range(0, freeTiles.Count);

        return freeTiles[selectedTile];
    }

    public Tile FindPlayer()
    {
        

        foreach (Tile item in MAP) // foreach (Tile item in Map)
        {
            if(item.GetPlayer() == true)
            {
                return item;
            }
        }

        return null;

       
    }
}
