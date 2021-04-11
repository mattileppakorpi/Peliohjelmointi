using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    public bool playerIsOnTheground = true;
    private float movementX;
    private float movementY;
    private float movementZ;
    public Text infoText;
    public Text penaltyText;

    

    IEnumerator WaitSeconds()
    {
        
        yield return new WaitForSeconds(5);
        penaltyText.text = "";

    }
    void Update()
    {
        
    }
    void HideText()
    {
        //StartCoroutine(WaitSeconds(5));
        //infoText.text = "";
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        penaltyText.text = "";
        infoText.text = "spacesta hyppää!";
       // HideText();

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
            infoText.text = "";
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
    public void ShowPenaltyText()
    { 

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
            penaltyText.text = "Penalttia +2s!";
            //ShowPenaltyText();
            StartCoroutine(WaitSeconds());
        }

    }

    

   
}
