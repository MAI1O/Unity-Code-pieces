using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirtyTwo : MonoBehaviour
{
    public Sprite sprite;
    //public GridTile gridTile;
    //public GridObject gridTileWall;
    private Texture2D map;
    private int rows = 32;
    private int columns = 32;
    //public GridManager gridManager;
    private Grid grid;
    private byte colorShift; //When I figure out what the correct color shift value is to maintain consistency across all types. (Door is wall + 50 for example)
   
    


    void Start()
    {
        //grid = gridManager.GetComponent<Grid>();
        map = sprite.texture;

        GenerateFloorMap(map);
        

        

    }


    //I should now figure out a system to remove the duds from the array after the first pass through in order to make instantiation more efficient.

    private void GenerateFloorMap(Texture2D map)    //Generates the whole bottom floor
        {

            Color32[] pix = map.GetPixels32();  //This gets the rgba values of each pixel in the 2dTexture
            Vector2Int[] piXY = new Vector2Int[pix.Length];

            for (int i = 0; i < piXY.Length; i++)
            {
                piXY[i] = new Vector2Int(pix[i].r, pix[i].a);
                Debug.Log("Instances of: " + piXY[i]);
            }


            rows = columns = (int)Mathf.Sqrt(pix.Length);      //Alternatively could just write 32 or 64 in the future, but this is more flexible.
            Debug.Log("Rows = " + rows);

            Debug.Log("Columns = " + columns);


            Vector2Int[,] twoDimensionalPix = new Vector2Int[rows, columns];

            int index = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    twoDimensionalPix[x, y] = piXY[index];      //Need to decide whether I am cutting out just the room, or including the info of the rest of the 32x32. Starting with keeping everything.
                    Debug.Log(twoDimensionalPix[x, y].x + " Instantiating at: " + y + "," + x); //The way I have it set up, y is x, and x is why, so I'm flipping them around
                    
                    if (x * y <= rows * columns && twoDimensionalPix[x,y].x > 0)
                    {
                        //GridManager.Instance.InstantiateGridTile(gridTile, new Vector2Int(x, y), 0, gridTile.m_GridObjectsPivotOffset, gridTile.transform.rotation, null);
                        
                    }
                    index++;

            }
            }

        }

    private void GenerateOutline(Texture2D map)    //Generates the outline of the PixelMap.
    {

        Color32[] pix = map.GetPixels32();  //This gets the rgba values of each pixel in the 2dTexture
        Vector2Int[] piXY = new Vector2Int[pix.Length];

        for (int i = 0; i < piXY.Length; i++)
        {
            piXY[i] = new Vector2Int(pix[i].r, pix[i].a);
            Debug.Log("Instances of: " + piXY[i]);
        }


        rows = columns = (int)Mathf.Sqrt(pix.Length);      //Alternatively could just write 32 or 64 in the future, but this is more flexible.
        Debug.Log("Rows = " + rows);

        Debug.Log("Columns = " + columns);


        Vector2Int[,] twoDimensionalPix = new Vector2Int[rows, columns];

        int index = 0;

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                twoDimensionalPix[x, y] = piXY[index];      //Need to decide whether I am cutting out just the room, or including the info of the rest of the 32x32. Starting with keeping everything.
                

                if (x * y <= rows * columns && twoDimensionalPix[x, y].x >= 4)
                {
                    Debug.Log(twoDimensionalPix[x, y].x + " Instantiating at: " + y + "," + x); //The way I have it set up, y is x, and x is why, so I'm flipping them around
                    //GridManager.Instance.InstantiateGridTile(gridTileWall, new Vector2Int(x, y), 0, gridTile.m_GridObjectsPivotOffset, gridTile.transform.rotation, null);
                    //GridManager.Instance.InstantiateGridObject(gridTileWall, new Vector2Int(x,y), Orientations.North, null, false); //instantiates walls above the floor. Could also just instantiate walls, and switch them to unreachable tiles. 

                }
                index++;

            }
        }

    }

    private void GenerateInteriors(Texture2D map)    //Generates the interior structures of the PixelMap.
    {

        Color32[] pix = map.GetPixels32();  //This gets the rgba values of each pixel in the 2dTexture
        Vector2Int[] piXY = new Vector2Int[pix.Length];

        for (int i = 0; i < piXY.Length; i++)
        {
            piXY[i] = new Vector2Int(pix[i].r, pix[i].a);
            Debug.Log("Instances of: " + piXY[i]);
        }


        rows = columns = (int)Mathf.Sqrt(pix.Length);      //Alternatively could just write 32 or 64 in the future, but this is more flexible.
        Debug.Log("Rows = " + rows);

        Debug.Log("Columns = " + columns);


        Vector2Int[,] twoDimensionalPix = new Vector2Int[rows, columns];

        int index = 0;

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                twoDimensionalPix[x, y] = piXY[index];      //Need to decide whether I am cutting out just the room, or including the info of the rest of the 32x32. Starting with keeping everything.


                if (x * y <= rows * columns && twoDimensionalPix[x, y].x > 4)
                {
                    Debug.Log(twoDimensionalPix[x, y].x + " Instantiating at: " + y + "," + x); //The way I have it set up, y is x, and x is why, so I'm flipping them around
                    //GridManager.Instance.InstantiateGridTile(gridTileWall, new Vector2Int(x, y), 0, gridTile.m_GridObjectsPivotOffset, gridTile.transform.rotation, null);
                    //GridManager.Instance.InstantiateGridObject(gridTileWall, new Vector2Int(x, y), null);

                }
                index++;

            }
        }

    }

    

    
}

    





    








