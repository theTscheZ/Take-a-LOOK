using System;
using UnityEngine;

public class Timer
{
    public event Action TimerExpired; // Ereignis für Timerablauf
    public event Action TimerUpdated; // Ereignis für Timeraktualisierung
    public float duration = 5;
    private float elapsedTime;
    private bool isRunning;

    public Timer(float duration)
    {
        this.duration = duration;
        this.elapsedTime = 0f;
        this.isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void UpdateTimer()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= duration)
            {
                isRunning = false;
                if (TimerExpired != null)
                {
                    TimerExpired(); // Ereignis auslösen
                }
            }

            if (TimerUpdated != null)
            {
                TimerUpdated(); // Ereignis auslösen
            }
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = false;
    }

    // getter for elapsedTime and duration
    public float getElapsedTime()
    {
        return elapsedTime;
    }

    public float getDuration()
    {
        return duration;
    }
}