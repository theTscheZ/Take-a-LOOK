using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameoverscreen : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
    scoreText.text = "Score: " + Stats.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
