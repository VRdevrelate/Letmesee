﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadImage : MonoBehaviour
{

    [SerializeField]
    private Texture2D[] images;
    private Texture2D image;


    [SerializeField]
    private GameObject groundObject;
    [SerializeField]
    private GameObject wallObject;

    // Start is called before the first frame update
    private void Start()
    {

        image = images[Random.Range(0, images.Length)];

        Color[] pix = image.GetPixels();

        int worldx = image.width;
        int worldz = image.height;

        Vector3[] spawnPositions = new Vector3[pix.Length];
        Vector3 startingSpawnPosition = new Vector3(-Mathf.Round(worldx / 2), 0, -Mathf.Round(worldz / 2));
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

            currentSpawnPos.x = startingSpawnPosition.x;
            currentSpawnPos.z++;

        }

        counter = 0;
        foreach (Vector3 pos in spawnPositions)
        {
            Color c = pix[counter];

            if (c.Equals(Color.white))
            {
                Instantiate(groundObject, pos, Quaternion.identity);
            }
            else if (c.Equals(Color.black))
            {
                Instantiate(wallObject, pos, Quaternion.identity);
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
        //            else if(c.Equals(Color.black))
        //            {
        //                black++;
        //            }
        //#if DEBUG

        //            Debug.Log("Black = " + black);
        //            Debug.Log("White = " + white);


        //#endif
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
