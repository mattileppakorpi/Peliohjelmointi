using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text infoText;

    public void RestartGame()
    {
        infoText.text = "nappia painettu";
        SceneManager.LoadScene("Palloralli");
    }
}
