using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer<T> : MonoBehaviour
{
    private float TimeFromStart;
    private float TimeLeft;
    private float TimeInterval;
    private float TimeBetweenInteval;

    private T ObjectForTimer = default(T);

    public bool IsTimeElapsed = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeFromStart = 0;
        TimeBetweenInteval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeFromStart += Time.deltaTime;

        if (TimeLeft > 0 && IsTimeElapsed == false)
        {
            if(TimeBetweenInteval >= TimeInterval)
            {
                //TetrisBlock.BlockFall();
                TimeLeft -= Time.deltaTime;
                TimeBetweenInteval = 0;
            } else
            {
                TimeBetweenInteval += Time.deltaTime;
            }
        }
        else
        {
            IsTimeElapsed = true;
        }
    }

    private void SetTimer(float timeInterval, float timeLeft)
    {
        TimeLeft = timeLeft;
        TimeInterval = timeInterval;
        TimeBetweenInteval = 0;
    }

    public void ResetTimer()
    {
        TimeLeft = 0;
        TimeInterval = 0;
        TimeBetweenInteval = 0;
    }

    public void AddToTimer(T objectForTimer, float timeInterval = 0, float timeLeft = float.MaxValue)
    {
        SetTimer(timeInterval, timeLeft);
        ObjectForTimer = objectForTimer;
    }
}
