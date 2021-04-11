using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text counterText;
   
   
    public float seconds, minutes;
    public static Timer instance { get; private set; }
    private float penaltySeconds;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        counterText = GetComponent<Text>() as Text;
       
        
    }

    public void AddSeconds(float penalty)
    {
        penaltySeconds+=penalty;
       
    }

  
    void Update()
    {
        var time = Time.time + penaltySeconds;
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    
}
