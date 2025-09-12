using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibujar : MonoBehaviour
{
    [Header("Prefabs de Lineas")]
    public GameObject lineaRojaPrefab;
    public GameObject lineaAzulPrefab;

    [Header("Prefabs de Poderes")]
    public GameObject fuegoPrefab;
    public GameObject lluviaPrefab;

    [Header("Dibujo")]
    public float distanciaMinPunto = 0.08f; // trazo mínimo
    public int maxPuntos = 500;

    private LineRenderer lineaActual;
    private readonly List<Vector3> puntos = new List<Vector3>();

    void Update()
    {
        if (GameManager.instance == null || GameManager.instance.poderselec == Poder.Ninguno) return;
    

        // Iniciar línea
        if (Input.GetMouseButtonDown(0))
        {
            if (ClickSobreLata()) return;
            GameObject prefabLinea = null;

            switch (GameManager.instance.poderselec)
            {
                case Poder.Fuego:
                    prefabLinea = lineaRojaPrefab;
                    break;
                
                case Poder.Lluvia:
                    prefabLinea = lineaAzulPrefab;
                    break;
            }

            if (prefabLinea != null)
            {
                var go = Instantiate(prefabLinea);
                lineaActual = go.GetComponent<LineRenderer>();
                puntos.Clear();
            }
        }

        // Dibujar mientras mantengo clic
        if (Input.GetMouseButton(0) && lineaActual != null)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0f;

            if (puntos.Count == 0 || (puntos.Count < maxPuntos && Vector3.Distance(puntos[puntos.Count - 1], mouse) > distanciaMinPunto))
            {
                puntos.Add(mouse);
                lineaActual.positionCount = puntos.Count;
                lineaActual.SetPositions(puntos.ToArray());
            }
        }

        // Al soltar el clic, crear efectos y destruir madera si corresponde
        if (Input.GetMouseButtonUp(0) && lineaActual != null)
        {
            Debug.Log("Solté el clic — se van a procesar " + puntos.Count + " puntos. Poder: " + GameManager.instance.poderselec);
            CrearLineas(GameManager.instance.poderselec);

            Destroy(lineaActual.gameObject, 2f);
            lineaActual = null;
            puntos.Clear();
        }
    }

    bool ClickSobreLata()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 p2 = new Vector2(mp.x, mp.y);
        var hit = Physics2D.OverlapPoint(p2);

        if (hit == null) return false;
        return hit.GetComponent<Lata>() != null;
    }

    void CrearLineas(Poder poder)
    {
        if (puntos.Count == 0) return;

        switch (poder)
        {
            case Poder.Fuego:
                foreach (var p in puntos)
                {
                    var f = Instantiate(fuegoPrefab, p, Quaternion.identity);
                    Collider2D hit = Physics2D.OverlapCircle(p, 0.5f);
                    if (hit != null)
                    {
                        Debug.Log("Detecté: " + hit.gameObject.name + " con tag " + hit.tag);
                        if (hit.CompareTag("Madera"))
                        {
                            Destroy(hit.gameObject);
                            Debug.Log("Madera destruida");
                        }
                    }
                    Destroy(f, 2f);
                }
                break;

            case Poder.Lluvia:
                foreach (var p in puntos)
                    Instantiate(lluviaPrefab, p + Vector3.up * 2f, Quaternion.identity);
                break;
        }
    }
}
