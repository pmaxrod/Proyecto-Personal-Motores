using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrearCubos : MonoBehaviour
{
    public GameObject cubo;
    public GameObject vida;
    public float tiempoGeneracion;

    private int limiteX = 10;
    private int limiteZ = 5;
    private float[] tamanosCubo = { 0.4f, 0.6f, 0.8f, 1f, 1.2f, 1.4f };
    private float modificadorTiempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        modificadorTiempo = ModificadorTiempoGeneracion();
        InvokeRepeating("GenerarCubo", 2, tiempoGeneracion / modificadorTiempo);
        InvokeRepeating("GenerarVida", 20, tiempoGeneracion * modificadorTiempo);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.vidas < 1)
        {
            CancelInvoke();
        }
    }

    private void GenerarCubo()
    {
        System.Random random = new System.Random();

        float posicionX = random.Next(-limiteX, limiteX + 1);
        int tamano = random.Next(0, tamanosCubo.Length);

        if (posicionX <= 0)
        {
            posicionX += tamano;
        }
        else
        {
            posicionX -= tamano;

        }

        cubo.transform.position = new Vector3(posicionX, 0, limiteZ);
        cubo.transform.localScale = Vector3.one * tamanosCubo[tamano];

        Instantiate(cubo);
    }

    private void GenerarVida()
    {
        System.Random random = new System.Random();

        float posicionX = random.Next(-limiteX, limiteX + 1);

        vida.transform.position = new Vector3(posicionX, 0, 0);
        Instantiate(vida);

    }

    private float ModificadorTiempoGeneracion()
    {

        switch (ControlDificultad.instance.dificultad)
        {
            case 0:
                return 0.5f;
            case 1:
                return 1f;
            case 2:
                return 2f;
            default: return 1;
        }
    }
}
