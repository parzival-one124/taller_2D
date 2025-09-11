using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lluvia : MonoBehaviour
{
    public float duracion = 3f;

    void Start()
    {
        Destroy(gameObject, duracion);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Apaga fuego
        if (col.CompareTag("Fuego"))
        {
            Destroy(col.gameObject);
        }
    }
}

