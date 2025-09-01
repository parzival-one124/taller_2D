using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Poder {Ninguno, Fuego, Lluvia, Rayo }
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Poder poderselec = Poder.Ninguno;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void seleccinarpoder(Poder p)
    {
        poderselec = p;
        Debug.Log("lata Seleccinada: " + p);
    }
}
