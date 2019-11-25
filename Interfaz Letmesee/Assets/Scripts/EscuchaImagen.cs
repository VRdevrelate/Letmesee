using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using UnityEngine.AI;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;


public class EscuchaImagen : ReadImage
{
    
    public GameObject rostro;
    public GameObject hablando;
    public Text registra;
    public GameObject escucha;
   

    public string[] revisar;

    private string dialogo;
    int materialCase = 0;
    int contador = 0;

    public void Escuchar(string text)
    {


        if (text.Contains("volver al menú"))
        {
            DestroyImmediate(escucha);
            SceneManager.LoadScene(0);

        }
        if (text.Contains("siguiente imagen"))
        {
            DestroyImmediate(escucha);
            SceneManager.LoadScene(0);
            contador++;
            SceneManager.LoadScene(1);
        }
        if (text.Contains("salir"))
        {
            Application.Quit();

        }
    }







    public void Boton_CambiarMaterial()
    {
        if (materialCase == 6)
        {
            materialCase = 0;
        }
        else
        {
            materialCase++;
        }
        
    
    }

    // Start is called before the first frame update
    void Start()
    {
        ImageLoad(contador);


    }

    // Update is called once per frame
    void Update()
    {
        string valor = registra.text;


        Escuchar(valor);
        Debug.Log(registra.text);
    }
}
