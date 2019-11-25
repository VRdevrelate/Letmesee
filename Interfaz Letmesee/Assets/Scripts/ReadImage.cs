using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ReadImage : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Texture2D[] images;
    private Texture2D[] publicImages;

    //private Texture2D image;


    [SerializeField]
    private GameObject groundObject;
    [SerializeField]
    private GameObject wallObject;
    [SerializeField]
    private GameObject plane;

    private string imagesDir = "/Imagen";
    #endregion

    // Start is called before the first frame update
   
    public void ImageLoad(int mundo)
    {
        
        string dataPath = Application.persistentDataPath;


        //string fileName = "Image1.png";

        //dataPath = "E:/LETMESEE/Letmesee/Interfaz Letmesee/builds";
        dataPath = "c:/builds";
        imagesDir = dataPath + imagesDir;
        Debug.Log(imagesDir);
        Debug.Log(imagesDir + "/");

        Debug.Log(dataPath);

        //fileName = imagesDir + "/" + fileName;

        if (Directory.Exists(imagesDir))
        {

            string[] filesFound = Directory.GetFiles(imagesDir);
            if (filesFound.Length > 0)
            {
                images = new Texture2D[filesFound.Length];
                int counter = 0;

                foreach (string fileAndPath in filesFound)
                {

                    string fileName = fileAndPath.Substring(fileAndPath.LastIndexOf('\\') + 1);
                    string filePath = imagesDir + "/" + fileName;

                    if (File.Exists(filePath))
                    {
                        byte[] imageData = File.ReadAllBytes(filePath);
                        Texture2D tex = new Texture2D(1, 1);
                        tex.LoadImage(imageData);
                        images[counter] = tex;
                        counter++;
                        Debug.Log(imagesDir);
                        Debug.Log(imagesDir + "/" + fileName);

                        Debug.Log(dataPath);

                    }
                    else
                    {
                        Debug.Log("file does not Exists");
                        Debug.Log(imagesDir);
                        Debug.Log(imagesDir + "/" + fileName);

                        Debug.Log(dataPath);

                    }

                    Debug.Log("File and Path: " + filePath);
                }


                //GenerateWorld(images[Random.Range(0, images.Length)]);
                if (mundo > (images.Length))
                { 
                    mundo = 0;
                }
                GenerateWorld(images[mundo]);
                

                int worldx = images[mundo].width;
                int worldz = images[mundo].height;

                plane.gameObject.transform.localScale = new Vector3(worldx / 6, 1, worldz / 6);

            }
            else
            {

            }

            //if (File.Exists(fileName))
            //{
            //byte[] imageData = File.ReadAllBytes(fileName);
            //Texture2D tex = new Texture2D(1, 1);
            //tex.LoadImage(imageData);
            //GenerateWorld(tex);
            //}
            //else
            //{
            //Debug.Log("file not found: " + fileName);
            //}



        }
        else
        {
            Debug.Log("Dir not found: " + imagesDir);
        }


        //if (File.Exists(fileName))
        //{
        //    Debug.Log("file Exists");
        //}
        //else
        //{
        //    Debug.Log("file does not Exists");
        //}

        //if (Directory.Exists(imagesDir))
        //{
        //    Debug.Log("Directory Exists");
        //}
        //else
        //{
        //    Debug.Log("Directory does not Exists");
        //}


    }

    private void Start()
    {
      
 
    }

    private void GenerateWorld(Texture2D image)
    {
        //image = images[Random.Range(0, images.Length)];

        Color[] pix = image.GetPixels();

        int worldx = image.width;
        int worldz = image.height;

        


        Vector3[] spawnPositions = new Vector3[pix.Length];
        Vector3 startingSpawnPosition = new Vector3(-Mathf.Round(worldx/2), 0, -Mathf.Round(worldz/2));
        Vector3 currentSpawnPos = startingSpawnPosition;

       

        int counter = 0;
        
        for (int z = 0; z < worldz; z++)
        {

            for (int x = 0; x < worldx; x++)
            {

                spawnPositions[counter] = currentSpawnPos;
                counter++;
                currentSpawnPos.x++;

            }
            currentSpawnPos.y = 1;
            currentSpawnPos.x = startingSpawnPosition.x;
            currentSpawnPos.z++;
            
        }
        

        counter = 0;
        foreach (Vector3 pos in spawnPositions)
        {
            Color c = pix[counter];

            if (c !=(Color.white))
            {
                Instantiate(groundObject, pos, Quaternion.Euler(90, 0, 0));
                //Instantiate(groundObject, pos, Quaternion.identity);
            }
            else if (c.Equals(Color.black))
            {
                //Instantiate(wallObject, pos, Quaternion.Euler(90,0,0));
                //Instantiate(wallObject, pos, Quaternion.identity);
            }

            counter++;
        }
//        int black = 0;
//        int white = 0;

//        foreach (Color c in pix)
//        {
//            if (c.Equals(Color.white))
//            {
//                white++;
//            }
//            else if (c.Equals(Color.black))
//            {
//                black++;
//            }
//#if DEBUG

//            Debug.Log("Black = " + black);
//            Debug.Log("White = " + white);


//#endif
//        }
    }



        // Update is called once per frame
        void Update()
    {
        
    }
}
