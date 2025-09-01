using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    public float duracion = 2f;

    private void Start()
    {
        Destroy(gameObject, duracion);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Madera"))
        {
            Destroy(col.gameObject);
        }
    }
}
