using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinPartida : MonoBehaviour
{
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoDificultad;

    // Start is called before the first frame update
    void Start()
    {
        textoPuntos.text = $"Puntos: {PlayerController.instance.puntuacion}";
        textoDificultad.text = $"Dificultad: {ControlDificultad.instance.TextoDificultad()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
