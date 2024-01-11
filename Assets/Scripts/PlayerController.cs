using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int vidas;
    public int puntuacion;

    public TMP_Text textoPuntuacion;
    public TMP_Text textoVidasRestantes;
    private Rigidbody playerRb;

    private float horizontalInput;
    private float horizontalBound = 10f;
    //    private float verticalInput;
    //    private float verticalBound = 7f;

    private string PLAYER_GAMEOBJECT_NAME = "Esfera";

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GameObject.Find(PLAYER_GAMEOBJECT_NAME).GetComponent<Rigidbody>();       
        instance = this;
        ActualizarVidas(vidas);
        ActualizarPuntuacion(puntuacion);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //      verticalInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //      playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        ConstrainPlayerPosition();
    }

    private void ConstrainPlayerPosition()
    {

        if (transform.position.x > horizontalBound)
        {
            transform.position = new Vector3(horizontalBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -horizontalBound)
        {
            transform.position = new Vector3(-horizontalBound, transform.position.y, transform.position.z);
        }
        /*        if (transform.position.z > verticalBound)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, verticalBound);
                }
                if (transform.position.z < -verticalBound)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -verticalBound);
                }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        vidas--;
        ActualizarVidas(vidas);
    }

    public void ActualizarVidas(int vidasActuales)
    {
        textoVidasRestantes.text = "Vidas: " + vidasActuales;
    }
    public void ActualizarPuntuacion(int puntuacionActual)
    {
        textoPuntuacion.text = "Puntuación: " + puntuacionActual;
    }
}
