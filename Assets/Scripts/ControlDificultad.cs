using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlDificultad : MonoBehaviour
{
    public int dificultad = 0;
    public static ControlDificultad instance;
    [SerializeField] private Button[] botones;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CambiarDificultad(1); // Normal por defecto
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CambiarDificultad(int num)
    {
        dificultad = num;
        foreach (Button boton in botones)
        {
            boton.interactable = true;
        }
        botones[dificultad].interactable = false;
    }

    public void Facil() { CambiarDificultad(0); }
    public void Normal() { CambiarDificultad(1); }
    public void Dificil() { CambiarDificultad(2); }

    public string TextoDificultad()
    {
        switch (dificultad)
        {
            case 0: return "Facil";
            case 1: return "Normal";
            case 2: return "Dificil";
            default: return "";
        }
    }


}
