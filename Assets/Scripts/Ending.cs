using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    bool m_IsPlayerAtExit;
    float m_Timer;
    public Text endText;
    public Text time;
    //public Timer timer;


    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        //endText = GetComponent<Text3>() as Text;
        endText.text = "Hienosti pelattu, onnea!!!";
        string aika = Timer.instance.counterText.text;
        Timer.instance.enabled = false;
        time.text = "aika:" + aika;
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration)
        {
            Application.Quit();
        }
    }

    void Start()
    {
        endText.text = "";
        time.text = "";
    }


}
