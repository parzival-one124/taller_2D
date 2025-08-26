using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibujar : MonoBehaviour
{
    [Header ("Prefabs")]
    public GameObject lineaPrefab;
    public GameObject fuegoPrefab;
    public GameObject lluviaPrefab;
    public GameObject rayoPrefab;

    [Header("Dibujo")]
    public float distanciaMinPunto = 0.08f; //trazo 
    public int maxPuntos = 500; 

    private LineRenderer lineaActual;
    private readonly List<Vector3> puntos = new List<Vector3>();

    void Update()
    {
        if (GameManager.instance == null || GameManager.instance.poderselec == Poder.Ninguno) return;
        {
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (ClickSobreLata()) return;

            var go = Instantiate(lineaPrefab);
            lineaActual = go.GetComponent<LineRenderer>();
            puntos.Clear();
        }

        if (Input.GetMouseButtonDown(0) && lineaActual != null)
        {
            Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            mouse.z = 0f;

            if (puntos.Count == 0 || (puntos.Count < maxPuntos && Vector3.Distance(puntos[puntos.Count - 1], mouse) > distanciaMinPunto))
            {
                puntos.Add(mouse);
                lineaActual.positionCount = puntos.Count;
                lineaActual.SetPositions(puntos.ToArray());
            }
        }

        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0))
        {
            CrearLineas(GameManager.instance.poderselec);
            Destroy(lineaActual.gameObject);
            lineaActual = null;
        }
    }

    bool ClickSobreLata()
    {
        Vector3 mp = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 p2 = new Vector2(mp.x, mp.y);
        var hit = Physics2D.OverlapPoint(p2);

        if (hit == null) return false;
        {
        }
        return hit.GetComponent<Lata>() != null;
    }

    bool CrearLineas() // terminar...
    {

    }
}
