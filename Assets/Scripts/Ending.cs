﻿using System.Collections;
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
    
    
    

    void Start()
    {
        endText.text = "";
        time.text = "";
    }

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
        string aika = Timer.instance.counterText.text;
        string firstAndSecond = aika.Substring(0, 2);

        if (firstAndSecond == "00")
        {
            endText.text = "Alle minuuttiin, ei oo todellista!!!";
        }
        else { endText.text = "Hienosti pelattu, onnea!!!"; }
        
        Timer.instance.enabled = false;
        time.text = "aika:" + aika;
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration)
        {
            Restart.instance.PauseGame();
            //Application.Quit();
        }
    }

    


}
