using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController: MonoBehaviour
{
    public void ResetTime()
    {
        Time.timeScale = 1.0f;
    }
    public void SetTime(float needTime) {
        Time.timeScale = needTime;
    }
    public void TurnOff() { Time.timeScale = 0; }
}
