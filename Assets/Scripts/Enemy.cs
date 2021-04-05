using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    
    public PlayerController player;
    public float MoveSpeed = 5f;

   

    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        
        Vector3 directionVector = player.transform.position - transform.position;

        //etaisyys
        float distanceToPlayer = directionVector.magnitude;

        
        if (distanceToPlayer >= 1.5f & distanceToPlayer <= 10f)
        {
            
            targetPosition = new Vector3(
                directionVector.normalized.x * Time.deltaTime * MoveSpeed,
                0f,
                directionVector.normalized.z * Time.deltaTime * MoveSpeed);

            
            transform.position += targetPosition;
        }
        else
        {
            Debug.Log("At attack range!");

            
            Quaternion enemysNewRotation = Quaternion.LookRotation(directionVector, Vector3.up);

            
            float rotSpeed = 5f;
            transform.rotation = Quaternion.Lerp(transform.rotation, enemysNewRotation, Time.deltaTime * rotSpeed);
        }
    }
}
