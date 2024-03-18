using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour, IGazeableObject
{
    SpriteRenderer spriteRenderer;
    private Color color;
    public string colorTexts;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void gazeAction()
    {
        color = spriteRenderer.color;
        color.a = 0.69f;
        spriteRenderer.color = color;
        Debug.Log("Gazed at " + colorTexts);
    }

    public void currentlyGazing()
    {
    }

    public void stoppedGazing()
    {
        color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }

    public float getGazeTime()
    {
        return 0.1f;
    }
}