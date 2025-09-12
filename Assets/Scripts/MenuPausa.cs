using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelOpciones; // opcional si usas el mismo de tu menú principal
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f; // congela el juego
        juegoPausado = true;
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f; // reanuda el juego
        juegoPausado = false;
    }

    public void IrAMenuPrincipal()
    {
        Time.timeScale = 1f; // asegúrate de reanudar antes de cambiar escena
        SceneManager.LoadScene("Menu"); // cambia "Menu" por el nombre real de tu escena de menú
    }

    public void AbrirOpciones()
    {
        if (panelOpciones != null)
        {
            panelPausa.SetActive(false);
            panelOpciones.SetActive(true);
        }
    }

    public void SalirJuego()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

