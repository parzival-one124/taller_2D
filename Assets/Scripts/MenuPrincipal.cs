using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Este método carga la escena del juego
    public void Jugar()
    {
        // Cambia "Juego" por el nombre de tu escena principal
        SceneManager.LoadScene("Pizarra");
    }

    // Este método abre opciones (puede ser otro menú o panel)
    public void Opciones()
    {
        Debug.Log("Abrir opciones...");
        // Aquí puedes activar un panel de opciones o cambiar de escena
    }

    // Este método cierra el juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
