using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    public bool playerIsOnTheground = true;
    private float movementX;
    private float movementY;
    private float movementZ;

   //Timer timer=Timer;
  

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void OnJump()//hyppynappi
    {
        if (playerIsOnTheground) { 
           
            movementZ = 15.0f;
            playerIsOnTheground = false;
        }
    }

    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementZ, movementY);
        

        rb.AddForce(movement * speed);
       
        if (playerIsOnTheground == false)
        {
            movementZ = 0.0f;
        }
     


    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheground = true;
            //Debug.Log("Test");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Timer.instance.AddSeconds(2.0f);
            Debug.Log("Test");
        }

    }

   
}
