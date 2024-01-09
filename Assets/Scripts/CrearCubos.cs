using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCubos : MonoBehaviour
{
    public GameObject cubo;
    public float tiempoGeneracion;

    private int limiteX = 10;
    private int limiteY = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generarCubo()
    {
        System.Random random = new System.Random();

        float posicionX = random.Next(-limiteX, limiteX + 1);

        cubo.transform.position = new Vector3(posicionX, limiteY, transform.position.z);
        Instantiate(cubo);
    }
}
