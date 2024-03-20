using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float duration = 5;
    private float elapsedTime = 0;
    private bool isRunning = false;
    private Image image;
    private float timeRemaining = 0;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Start()
    {
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= duration)
            {
                isRunning = false;
                ResetTimer();
                // StartTimer();
            }

            timeRemaining = duration - elapsedTime;
            image.fillAmount = timeRemaining / duration;
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = false;
        // Show Win Screen
        GameObject myPrefab = Resources.Load("winscreen") as GameObject;
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.Euler(90, 180, 0));
        //Timer
        //StartTimer();
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
        GameObject.Find("RNG").GetComponent<RNG>().Randomize();
    }
}