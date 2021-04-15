using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTexts : MonoBehaviour
{
    public Text infoText;
    public GameObject player;

    void Start()
    {
        infoText.text = "spacesta hyppää, c on turbo!";
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) 
        { 
        infoText.text = "Varo punaista seinää!!";
        StartCoroutine(ClearInfoText());
        }
    }

    IEnumerator ClearInfoText()
    {

        yield return new WaitForSecondsRealtime(4);
        infoText.text = "";

    }
}
