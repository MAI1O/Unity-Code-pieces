using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ThirtyTwoBit : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    private Texture2D map;
    private float wall;     //Need standardized color system to denote object types.
    private float door;
    private bool isAlpha;
    private Grid grid;

    private float colorShift; //When I figure out what the correct color shift value is to maintain consistency across all types. (Door is wall + 50 for example)

    void Start()
    {


        map = sprite.texture;


        Color[] pix = map.GetPixels();
        wall = pix[32].r;

        grid = new Grid(64, 64, 8f, new Vector3(0,0,0));

        


        for (int i = 0; i < pix.Length; i++)
        {


            if (i != 32 && pix[i].r == wall)
            {
                GameObject wallBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wallBlock.transform.position = new UnityEngine.Vector3(pix[0].r, pix[0].g, pix[0].b);
                //remove from array?
            }

        }


    }



}



