using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Este m�todo carga la escena del juego
    public void Jugar()
    {
        // Cambia "Juego" por el nombre de tu escena principal
        SceneManager.LoadScene("Pizarra");
    }

    // Este m�todo abre opciones (puede ser otro men� o panel)
    public void Opciones()
    {
        Debug.Log("Abrir opciones...");
        // Aqu� puedes activar un panel de opciones o cambiar de escena
    }

    // Este m�todo cierra el juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
