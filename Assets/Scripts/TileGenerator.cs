using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject TilePrefab;
    public int GridWidth = 8;
    public int Gridlength = 8;
    public Vector3 TilePos;
    public Vector3 TileSize;
    public Vector3 GapBetweenTiles;

    void Start()
    {
        /*TileSize = new Vector3(4f, 1f, 4f);
        GapBetweenTiles = new Vector3(0.5f, 0f, 0.5f);*/
        for (int i=0; i< Gridlength; i++)
        {
            TilePos.x = i * (TileSize.x + GapBetweenTiles.x);
            for(int j=0; j<GridWidth; j++)
            {
                TilePos.z = j * (TileSize.z + GapBetweenTiles.z);
                Instantiate(TilePrefab,TilePos,Quaternion.identity);
                
            }
        }
    }

   
}
