using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrearCubos : MonoBehaviour
{
    public GameObject cubo;
    public float tiempoGeneracion;

    private int limiteX = 10;
    private int limiteY = 10;
    private int limiteZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarCubo", 2, tiempoGeneracion);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.vidas <= 0)
        {
            CancelInvoke();
        }
    }

    private void GenerarCubo()
    {
        System.Random random = new System.Random();

        float posicionX = random.Next(-limiteX, limiteX + 1);

        cubo.transform.position = new Vector3(posicionX, 0, limiteZ);
        Instantiate(cubo);
    }
}
