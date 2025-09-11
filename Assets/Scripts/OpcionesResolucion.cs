using UnityEngine;
using TMPro;

public class OpcionesResolucion : MonoBehaviour
{
    public TMP_Dropdown dropdownResoluciones;

    private Resolution[] resoluciones;

    void Start()
    {
        // Obtener todas las resoluciones soportadas por la pantalla
        resoluciones = Screen.resolutions;

        // Limpiar opciones actuales del dropdown
        dropdownResoluciones.ClearOptions();

        // Crear una lista de strings para mostrar
        var opciones = new System.Collections.Generic.List<string>();
        int resolucionActualIndex = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            // Marcar la resolución actual
            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActualIndex = i;
            }
        }

        // Asignar opciones al dropdown
        dropdownResoluciones.AddOptions(opciones);

        // Mostrar como seleccionada la resolución actual
        dropdownResoluciones.value = resolucionActualIndex;
        dropdownResoluciones.RefreshShownValue();

        // Escuchar cuando el jugador cambia la resolución
        dropdownResoluciones.onValueChanged.AddListener(CambiarResolucion);
    }

    public void CambiarResolucion(int indice)
    {
        Resolution resolucion = resoluciones[indice];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        Debug.Log("Resolución cambiada a: " + resolucion.width + " x " + resolucion.height);
    }
}
