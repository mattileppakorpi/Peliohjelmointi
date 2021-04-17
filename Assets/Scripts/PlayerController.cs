using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int hits = 0;
    public Text hitText;
    public float speed = 0;
    private Rigidbody rb;
    public bool playerIsOnTheground = true;
    private float movementX;
    private float movementY;
    private float movementZ;
    public Text infoText;
    public Text penaltyText;
    public Transform BackToStart;
    public float bounceSpeed = 20f;
    public bool bounce = false;

    public void OnRestartGame()
    {
        
        SceneManager.LoadScene("Palloralli");
        Timer.instance.ClearTimer();
    }

    //tyhjentää penaltytext-kentän
    IEnumerator ClearPenaltyText()
    {
        
        yield return new WaitForSecondsRealtime(2);
        penaltyText.text = "";

    }
    //lopettaa turbonapin
    IEnumerator SpeedToNormal()
    {

        yield return new WaitForSeconds(1);
        speed = speed / 1.5f;

    }
    // lopettaa liikkuvan seinän antaman vauhdin
    IEnumerator StopBounce()
    {

        yield return new WaitForSeconds(1);
        bounce=false;

    }
    // tyhjentää infotekstin
    IEnumerator ClearInfoText()
    {

        yield return new WaitForSecondsRealtime(3);
        infoText.text = "";

    }

    //hidastava seinä
    IEnumerator SlowSpeed()
    {
        float temp = speed;
        speed = speed / 4;

        yield return new WaitForSecondsRealtime(4);
        speed = temp;

    }

    void Update()
    {
        hitText.text = "osumia: "+ hits.ToString();

    }
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        penaltyText.text = "";
        

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
           
            movementZ = 12.0f;
            playerIsOnTheground = false;
            //infoText.text = "";
        }
    }

    void OnTurbo()//turbonappi
    {
        speed = speed * 1.5f;
        StartCoroutine(SpeedToNormal());
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementZ, movementY);
        

        rb.AddForce(movement * speed);

       //ilmassa ollessa hyppynappi ei toimi
        if (playerIsOnTheground == false)
        {
            movementZ = 0.0f;
        }

        //liikkuvan seinän antama tönäisy
        if (bounce == true)
        {
            Vector3 movement2 = new Vector3(-(movementX), 0f, -(movementY));
            rb.AddForce(movement2 * bounceSpeed);
            
        }



    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //hyppynapin onko maassa-tarkistus
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheground = true;
            
        }

        //seinäosumat
        if (collision.gameObject.tag == "Wall")
        {
            Timer.instance.AddSeconds(2.0f);
            hits = hits + 1;
            penaltyText.text = "Penalttia +2s!";
            
            StartCoroutine(ClearPenaltyText());
        }

        //idastava seinä
        if(collision.gameObject.tag == "Slower")
        {
            StartCoroutine(SlowSpeed());
            infoText.text = "Osuit hidastavaan ansaan!";
            StartCoroutine(ClearInfoText());
        }

        //sininen pallo heittää radan alkuun
        if (collision.gameObject.tag == "WorstEnemy")
        {
            transform.position = BackToStart.position;
            infoText.text = "Takaisin lähtöruutuun, pahus vie!";
            StartCoroutine(ClearInfoText());
        }

        //liikkuva seinä tönäisee pelaajan takaspäin
        if (collision.gameObject.tag == "Bouncer")
        {

            bounce = true;
            StartCoroutine(StopBounce());
        }

    }

    

   
}
