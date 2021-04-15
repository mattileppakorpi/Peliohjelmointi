using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText3 : MonoBehaviour
{
    public Text infoText;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            infoText.text = "Varo, liikkuva seinä heittää takaspäin!";
            StartCoroutine(ClearInfoText());
        }
    }

    IEnumerator ClearInfoText()
    {

        yield return new WaitForSeconds(5);
        infoText.text = "";

    }
}
