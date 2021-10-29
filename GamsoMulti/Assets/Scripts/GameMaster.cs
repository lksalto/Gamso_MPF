using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] float totalTime;
    [SerializeField] string timeMinText;
    [SerializeField] string timeSecText;
     float timeMin;
     float timeSec;
    [SerializeField] TMPro.TextMeshProUGUI timeText;
    private void Awake()
    {
        timeMin = totalTime / 60;
        timeSec = totalTime % 60;
        timeSecText = timeSec.ToString("00");
        timeMinText = timeMin.ToString("00");
    }
    void Update()
    {
        
        if (timeSec < -0.5f)
        {
            timeSec = 60f;
            timeMin--;
            timeMinText = timeMin.ToString("00");
        }
        if ((timeSec <= 60f) && (timeSec >= 59.0f))
        {
            timeSecText = "59";
            timeText.text = timeMinText + ":" + timeSecText;
        }
        else
        {
            timeSecText = timeSec.ToString("00");
            timeText.text = timeMinText + ":" + timeSecText;
        }
        timeSec -= Time.deltaTime;
    }
}
