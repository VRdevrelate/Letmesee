using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using UnityEngine.AI;
using UnityEngine.Video;
using UnityEngine.UI;


public class TemperamentoEscucha : MonoBehaviour
{

    public Button button;
    public GameObject rostro;
    public GameObject hablando;
    public Material apatia;
    public Material cansado;
    public Material desinteres;
    public Material enojado;
    public Material feliz;
    public Material sorprendido;
    public Material sueno;
    public Text registra;
    public GameObject escucha;

    public string[] revisar; 

    private string dialogo;
    int materialCase = 0;

    public void Escuchar(string text)
    {


        if (text.Contains("empezar la experiencia"))
        {
            DestroyImmediate(escucha);
            SceneManager.LoadScene(1);

        }
        if (text.Contains("salir")) 
        {
            Application.Quit();

        }
    }


    public void CambiarVideo(int materialCase)
    {
        Renderer rend = rostro.GetComponent<Renderer>();

        switch (materialCase)

        {
            case 0:
                rend.material = apatia;
                break;
            case 1:
                rend.material = cansado;
                break;
            case 2:
                rend.material = desinteres;
                break;
            case 3:
                rend.material = enojado;
                break;
            case 4:
                rend.material = feliz;
                break;
            case 5:
                rend.material = sorprendido;
                break;
            case 6:
                rend.material = sueno;
                break;


        }

    }


    public void CambiarRostro(int materialCase)
    {
        Renderer rend = rostro.GetComponent<Renderer>();

        switch (materialCase)

        {
            case 0:
                rend.material = apatia;
                break;
            case 1:
                rend.material = cansado;
                break;
            case 2:
                rend.material = desinteres;
                break;
            case 3:
                rend.material = enojado;
                break;
            case 4:
                rend.material = feliz;
                break;
            case 5:
                rend.material = sorprendido;
                break;
            case 6:
                rend.material = sueno;
                break;


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
            materialCase ++;
        }
        CambiarRostro(materialCase);
        CambiarVideo(materialCase);
    }

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        string valor = registra.text;

        
        Escuchar(valor);
        Debug.Log(registra.text);
    }
}
