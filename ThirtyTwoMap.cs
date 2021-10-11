using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ThirtyTwoMap : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    private Texture2D map;
    private Vector3 wallRGB;
    private float wall;     //Need standardized color system to denote object types. r value of rgb
    private float door;

    private Pixel pixel;
    public Pixel[] pixels;
    private bool isAlpha;
    private GridMap grid;

    


    private float colorShift; //When I figure out what the correct color shift value is to maintain consistency across all types. (Door is wall + 50 for example)

    void Start()
    {


        map = sprite.texture;       //Grab the 2dTexture of the sprite


        Color32[] pix = map.GetPixels32();  //Get the rgb values into 255 rgb format (includes 'a' value)
        wallRGB = RGBValuesToVector(pix[34]);    //

        
        



        grid = new GridMap(32, 32, 0.03125f, new Vector3(0, 0, 0));

        GameObject testWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 beforeOffsetCubePosition = grid.GetWorldPosition(0, 0);
        beforeOffsetCubePosition.x += 0.015625f;
        beforeOffsetCubePosition.y += 0.015625f;
        beforeOffsetCubePosition.z -= 0.015625f;
        testWall.transform.position = beforeOffsetCubePosition;
        testWall.transform.localScale /= 32;

        

       //pixels = PixelMapper(pixels, pix);


        /*for (int i = 0; i < pix.Length; i++)
        {


            if (i != 32 && pix[i].r == wall)
            {
                GameObject wallBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wallBlock.transform.position = new UnityEngine.Vector3(pix[0].r, pix[0].g, pix[0].b);
                //remove from array?
            }

        }*/

        /*foreach (Pixel p in pixels)
        {
            if (p.rgb.x == pix[32].r)
            {
                Debug.Log("Success");
            }
        }*/
    }

    private Pixel[] PixelMapper(Pixel[] pixels, Color[] colors)
    {
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i].rgb = colors[i].linear;
            Debug.Log(pixels[i].rgb);
        }
        
        return pixels;
    }

    private Vector3 RGBValuesToVector(Color32 color) //Converts rgb values into a Vector 3
    {
        Vector3 rgb = new Vector3(color.r, color.g, color.b);
        return rgb;
    }

}



