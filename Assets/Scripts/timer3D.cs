using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer3D : MonoBehaviour
{
    public float time = 5;
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = time;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        gameObject.GetComponent<Image>().fillAmount = timeRemaining / time;

        if (timeRemaining <= 0)
        {
            GameObject.Find("RNG").GetComponent<RNG3D>().Randomize();
            timeRemaining = time;
        }
    }
}
