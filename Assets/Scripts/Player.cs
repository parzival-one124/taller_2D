using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private bool enSuelo = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Congelar rotación para que no se voltee
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Movimiento horizontal (A y D o flechas izquierda/derecha)
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * velocidad, rb.velocity.y);

        // Saltar (una vez, solo si está en el suelo)
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
    }

    // Detectar si está tocando el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            enSuelo = true;
        }
    }
}
