using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroJuego : MonoBehaviour
{
    public GameObject TextoJuego;
    public GameObject panelIntro;
    public TMP_Text textoHistoria;

    [TextArea(3, 5)]
    public string[] lineas; // aquí escribes tu historia por partes

    private int indice = 0;

    void Start()
    {
        Time.timeScale = 0f; // Pausar el juego
        MostrarLinea();

        if (TextoJuego != null )
            TextoJuego.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown) // cualquier tecla
        {
            SiguienteLinea();
        }
    }

    void MostrarLinea()
    {
        if (indice < lineas.Length)
        {
            textoHistoria.text = lineas[indice];
        }
    }

    void SiguienteLinea()
    {
        indice++;
        if (indice < lineas.Length)
        {
            MostrarLinea();
        }
        else
        {
            // Termina la intro
            panelIntro.SetActive(false);
            if (TextoJuego != null )
                TextoJuego.SetActive(true);
            Time.timeScale = 1f; // Reanudar juego
        }
    }
}


