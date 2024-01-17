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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarCubo", 2, tiempoGeneracion * ((PlayerController.instance.puntuacion / 100) + 1));
        InvokeRepeating("GenerarVida", 20, tiempoGeneracion * 10);
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

        cubo.transform.position = new Vector3(posicionX, 0, limiteZ);
        cubo.transform.localScale *= tamanosCubo[tamano];

        Instantiate(cubo);
    }

    private void GenerarVida()
    {
        System.Random random = new System.Random();

        float posicionX = random.Next(-limiteX, limiteX + 1);

        vida.transform.position = new Vector3(posicionX, 0, 0);
        Instantiate(vida);

    }
}
