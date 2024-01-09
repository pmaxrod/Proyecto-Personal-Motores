using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
//    private float verticalInput;
//    private float verticalBound = 7f;
    private float horizontalBound = 10f;

    private string PLAYER_GAMEOBJECT_NAME = "Esfera";
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GameObject.Find(PLAYER_GAMEOBJECT_NAME).GetComponent<Rigidbody>();       
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
    }
}
