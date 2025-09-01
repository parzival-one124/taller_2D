using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector2 direccion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) 
        {
            direccion.y += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direccion.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direccion.x += 1f;
        }

    }

    void FixedUpdate()
    {
        if (direccion != Vector2.zero )
        {
            if (rb != null)
            {
                rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
            }
        }
    }
}
