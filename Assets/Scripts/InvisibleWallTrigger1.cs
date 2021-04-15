using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallTrigger1 : MonoBehaviour
{
    public GameObject player;
    public GameObject invisibleWall;

    void Start()
    {
        invisibleWall.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            invisibleWall.SetActive(true);
            
        }

    }
}
