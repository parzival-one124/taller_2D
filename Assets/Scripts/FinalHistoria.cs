using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalHistoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public TMP_Text textoVictoria;
    public GameObject BtnMenu;

    [TextArea(3, 5)]
    public string[] lineas; // frases del final

    private int indice = 0;

    void Start()
    {
        Time.timeScale = 0f; // Pausar el juego
        MostrarLinea();

        if (BtnMenu != null)
            BtnMenu.SetActive(false);
        
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SiguienteLinea();
        }
    }

    void MostrarLinea()
    {
        if (indice < lineas.Length)
        {
            textoVictoria.text = lineas[indice];
        }
        
    }

    void SiguienteLinea()
    {
        indice++;
        if (indice < lineas.Length)
        {
            MostrarLinea();
        }
        else
        {
            if (BtnMenu != null)
                BtnMenu.SetActive(true); 
        }
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

