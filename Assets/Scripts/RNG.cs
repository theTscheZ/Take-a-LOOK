using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNG : MonoBehaviour
{
    public int[] difficultyMilestones = { 5, 10, 15 };
    private Color[] colors =
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow
    };

    private string[] colorTexts =
    {
        "red",
        "blue",
        "green",
        "yellow"
    };

    public static string colorText = "red";

    private LookTarget[] targets;

    public Text objectiveText;
    public Text objectiveTextColor;

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
            randomTargets[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", colors[i]);
            randomTargets[i].color = colorTexts[i];
        }

        //randomize text:
        int randomInt = Random.Range(0, colorTexts.Length);
        colorText = colorTexts[randomInt];
        objectiveText.text = "Look at";
        objectiveTextColor.text = colorText;
        if (Stats.score >= difficultyMilestones[0])
        {
            objectiveTextColor.color = colors[Random.Range(0, colorTexts.Length)];
        }
        else
        {
            objectiveTextColor.color = colors[randomInt];
        }
        if (Stats.score >= difficultyMilestones[1])
        {
            Stats.objectiveTruth = Random.Range(0, 2) == 0;
            if (Stats.objectiveTruth)
            {
                if (Stats.score >= difficultyMilestones[2])
                {
                    int rando = Random.Range(0, 3);
                    objectiveText.text = rando switch
                    {
                        0 => "Do look at",
                        1 => "Don't not look at",
                        _ => "Look at",
                    };
                }
                else
                {
                    objectiveText.text = "Look at";
                }
            }
            else
            {
                if (Stats.score >= difficultyMilestones[2])
                {
                    int rando = Random.Range(0, 2);
                    objectiveText.text = rando switch
                    {
                        0 => "Do not look at",
                        _ => "Don't look at",
                    };
                }
                else
                {
                    objectiveText.text = "Don't look at";
                }
            }

        }
        else
        {
            Stats.objectiveTruth = true;
            objectiveText.text = "Look at";
        }
    }
}