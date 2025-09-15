using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puerta"))
        {
            // Cargar la siguiente escena por índice
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Pizarra 2");
        }
        if (SceneManager.GetActiveScene().name == "Pizarra 2")
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}

