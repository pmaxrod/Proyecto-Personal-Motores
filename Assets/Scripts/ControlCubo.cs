using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubo : MonoBehaviour
{
    public int puntosOtorgados;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * (PlayerController.instance.puntuacion/10));
        if (transform.position.z < -5 )
        {
            OtorgarPuntos();
        }
    }
    private void OtorgarPuntos()
    {
        Destroy(gameObject);
        PlayerController.instance.puntuacion += puntosOtorgados;
        PlayerController.instance.ActualizarPuntuacion(PlayerController.instance.puntuacion);
    }
}
