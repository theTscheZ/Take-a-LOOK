using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    public float time = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (stats.health > 0)
            {
                Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
                timer.StartTimer();
            }else{
                Text replaceThisWithABetterGameoverScreenOrSomething = GameObject.Find("objectiveText").GetComponent<Text>();
                replaceThisWithABetterGameoverScreenOrSomething.text = "GAME OVER";
            }
            Destroy(this.gameObject);
        }
    }
}
