using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RNG3D : MonoBehaviour
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

    private lookTarget3D[] targets;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType(typeof(lookTarget3D)) as lookTarget3D[];
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Randomize()
    {
        //randomize colors:
        List<lookTarget3D> randomTargets = new List<lookTarget3D>();
        lookTarget3D randomTarget = targets[Random.Range(0, targets.Length)];
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
            randomTargets[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", colors[i]);
            randomTargets[i].color = colorTexts[i];
        }

        //randomize text:
        colorText = colorTexts[Random.Range(0, colorTexts.Length)];
        text.text = "Look at " + colorText + ".";

    }
}
