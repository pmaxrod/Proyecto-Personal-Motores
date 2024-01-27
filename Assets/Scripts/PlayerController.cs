using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int vidas;
    public int puntuacion;

    public TMP_Text textoPuntuacion;
    public TMP_Text textoVidasRestantes;
    public bool invencible;

    private Rigidbody playerRb;
    private Material material;

    // Limites
    private float horizontalInput;
    private float horizontalBound = 10f;
    private float verticalInput;
    private float verticalBound = 5f;

    // Constantes
    private string PLAYER_GAMEOBJECT_NAME = "Esfera";
    private float TOTAL_VIDAS = 5;

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find(PLAYER_GAMEOBJECT_NAME).GetComponent<Rigidbody>();
        material = gameObject.GetComponent<Renderer>().material;
        instance = this;
        ActualizarVidas(vidas);
        ActualizarPuntuacion(puntuacion);
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas > 0)
        {
            MovePlayer();
        }
        else
        {
            SceneManager.LoadScene("FinDeJuego");
        }
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
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
        if (transform.position.z > verticalBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBound);
        }
        if (transform.position.z < -verticalBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -verticalBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo") && !invencible)
        {
            Destroy(other.gameObject);
            vidas--;
            ActualizarVidas(vidas);
        }

        else if (other.gameObject.CompareTag("Vida") && vidas < TOTAL_VIDAS)
        {
            Destroy(other.gameObject);
            vidas++;
            ActualizarVidas(vidas);
        }

        else if (other.gameObject.CompareTag("Invencibilidad") && !invencible)
        {
            Destroy(other.gameObject);
            invencible = true;
            material.SetColor("_Color", Color.yellow);
            StartCoroutine(InvencibleCountdownRoutine());
        }
    }

    public void ActualizarVidas(int vidasActuales)
    {
        textoVidasRestantes.text = $"Vidas: {vidasActuales}/{TOTAL_VIDAS}";
        CambiarColorVidas();
    }

    public void ActualizarPuntuacion(int puntuacionActual)
    {
        textoPuntuacion.text = "Puntos: " + puntuacionActual;
    }

    private void CambiarColorVidas()
    {
        switch (vidas)
        {
            case int n when (n <= 1) && !invencible:
                material.SetColor("_Color", Color.red); break; // _Color es el nombre de la propiedad
            case int n when (n <= 5 && n >= 2) && !invencible:
                material.SetColor("_Color", Color.blue); break;
            default:
                break;
        }
    }

    IEnumerator InvencibleCountdownRoutine()
    {
        yield return new WaitForSeconds(20);
        invencible = false;
        CambiarColorVidas();
    }
}
