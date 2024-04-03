using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    public float time = 2;
    private GameObject threeD;

    void Start()
    {
        threeD = GameObject.Find("3D");
        threeD.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (Stats.health > 0)
            {
                Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
                timer.StartTimer();
                threeD.SetActive(true);
            }else{
                Text replaceThisWithABetterGameoverScreenOrSomething = GameObject.Find("objectiveText").GetComponent<Text>();
                replaceThisWithABetterGameoverScreenOrSomething.text = "GAME OVER";
            }
            Destroy(this.gameObject);
        }
    }
}
