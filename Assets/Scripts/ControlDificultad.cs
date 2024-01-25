using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDificultad : MonoBehaviour
{
    public int dificultad = 0;
    public static ControlDificultad instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CambiarDificultad(int num)
    {
        dificultad = num;
    }

    public void Facil() { CambiarDificultad(0); }
    public void Normal() { CambiarDificultad(1); }
    public void Dificil() { CambiarDificultad(2); }

    public string TextoDificultad()
    {
        switch (dificultad)
        {
            case 0: return "Fácil";
            case 1: return "Normal";
            case 2: return "Difícil";
            default: return "";
        }
    }


}
