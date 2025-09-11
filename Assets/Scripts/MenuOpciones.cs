using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuOpciones : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelMenu;
    public GameObject panelOpciones;
    public GameObject panelControles;

    [Header("UI Opciones")]
    public TMP_Dropdown dropdownResoluciones;

    private Resolution[] resoluciones;

    void Start()
    {
        //Inicializar Resoluciones en Dropdown 
        if (dropdownResoluciones != null)
        {
            resoluciones = Screen.resolutions;
            dropdownResoluciones.ClearOptions();

            var opciones = new System.Collections.Generic.List<string>();
            int resolucionActualIndex = 0;

            for (int i = 0; i < resoluciones.Length; i++)
            {
                string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
                opciones.Add(opcion);

                if (resoluciones[i].width == Screen.currentResolution.width &&
                    resoluciones[i].height == Screen.currentResolution.height)
                {
                    resolucionActualIndex = i;
                }
            }

            dropdownResoluciones.AddOptions(opciones);
            dropdownResoluciones.value = resolucionActualIndex;
            dropdownResoluciones.RefreshShownValue();

            dropdownResoluciones.onValueChanged.AddListener(CambiarResolucion);
        }

        // Al iniciar: solo el menú principal está activo
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
        panelControles.SetActive(false);
    }

    //MENÚ PRINCIPAL 
    public void Jugar()
    {

        SceneManager.LoadScene("Pizarra");
    }

    public void Opciones()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // OPCIONES
    public void CambiarResolucion(int indice)
    {
        Resolution resolucion = resoluciones[indice];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        Debug.Log("Resolución cambiada a: " + resolucion.width + "x" + resolucion.height);
    }

    public void AbrirControles()
    {
        panelOpciones.SetActive(false);
        panelControles.SetActive(true);
    }

    public void VolverAOpciones()
    {
        panelControles.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void VolverAMenu()
    {
        panelOpciones.SetActive(false);
        panelMenu.SetActive(true);
    }
}