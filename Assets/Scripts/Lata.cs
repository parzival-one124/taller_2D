using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lata : MonoBehaviour
{
    public Poder poder = Poder.Fuego;

    private void OnMouseDown()
    {
        GameManager.instance.seleccinarpoder(poder);
    }

}
