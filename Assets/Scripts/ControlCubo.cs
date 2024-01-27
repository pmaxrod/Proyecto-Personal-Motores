using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubo : MonoBehaviour
{
    public int puntosOtorgados;
    public float velocidad;
    private Rigidbody cuboRb;

    // Start is called before the first frame update
    void Start()
    {
        cuboRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.vidas > 0)
        {
            //cuboRb.AddForce(-Vector3.forward * Time.deltaTime * ((PlayerController.instance.puntuacion / 20) + 1));
            transform.Translate(-Vector3.forward * Time.deltaTime * velocidad);
            if (transform.position.z < -5)
            {
                OtorgarPuntos();
            }

        }
    }

    private void OtorgarPuntos()
    {
        Destroy(gameObject);

        int multi = ControlDificultad.instance.dificultad == 0 ? 2 : 1;

        PlayerController.instance.puntuacion += (multi * puntosOtorgados);
  
        PlayerController.instance.ActualizarPuntuacion(PlayerController.instance.puntuacion);
    }
}
