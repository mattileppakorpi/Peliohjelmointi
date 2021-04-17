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
    private float timeCount;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        //timeCount = 0;
       
    }

    public void ClearTimer()
    {
        seconds = 0f;
        minutes = 0f;

    }


    public void AddSeconds(float penalty)
    {
        penaltySeconds+=penalty;
       
    }

  
    void Update()
    {
        var time = Time.timeSinceLevelLoad + penaltySeconds;
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        //timeCount = timeCount + time.deltatime;
    }

    
}
