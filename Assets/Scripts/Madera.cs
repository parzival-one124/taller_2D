using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madera : MonoBehaviour
{
    public float tiempoQuemarse = 1.5f; // segundos antes de desaparecer

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si toca un objeto que tenga el tag "Fuego"
        if (other.CompareTag("Fuego"))
        {
            Debug.Log("La madera se está quemando");
            Destroy(gameObject, tiempoQuemarse); // la madera desaparece después de un rato
        }
        if (other.CompareTag("LLuvia"))
        {
            Debug.Log("fuego muere");
            Destroy(gameObject, tiempoQuemarse);
        }
    }
}
