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

    public static string colorText = "red";

    private LookTarget[] targets;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType(typeof(LookTarget)) as LookTarget[];
        Randomize();
    }

    public void Randomize()
    {
        //randomize colors:
        List<LookTarget> randomTargets = new List<LookTarget>();
        LookTarget randomTarget = targets[Random.Range(0, targets.Length)];
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
            randomTargets[i].GetComponent<SpriteRenderer>().color = colors[i % colors.Length];
            randomTargets[i].colorTexts = colorTexts[i % colors.Length];
        }

        //randomize text:
        colorText = colorTexts[Random.Range(0, colorTexts.Length)];
        text.text = "Look at " + colorText + ".";

    }
}