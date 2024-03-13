using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RNG : MonoBehaviour
{
    private Color[] colors = {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow
    };

    private string[] colorTexts = {
        "red",
        "blue",
        "green",
        "yellow"
    };

    private lookTarget[] targets;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType(typeof(lookTarget)) as lookTarget[];
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Randomize()
    {
        //randomize colors:
        List<lookTarget> randomTargets = new List<lookTarget>();
        lookTarget randomTarget = targets[Random.Range(0, targets.Length)];
        for (int i = 0; i < targets.Length; i++)
        {
            while (randomTargets.Contains(randomTarget))
            {
                randomTarget = targets[Random.Range(0, targets.Length)];
            }
            randomTargets.Add(randomTarget);
        }
        for (int i = 0; i < randomTargets.Count; i++)
        {
            randomTargets[i].GetComponent<Image>().color = colors[i];
            randomTargets[i].color = colors[i];
        }

        //randomize text:
        string colorText = colorTexts[Random.Range(0, colorTexts.Length)];
        text.text = "Look at " + colorText + ".";

    }
}
