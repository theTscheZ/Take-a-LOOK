﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour, IGazeableObject
{
    SpriteRenderer spriteRenderer;
    Color originalColor;
    private Color color;
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    public void gazeAction()
    {
        color = spriteRenderer.color;
        color.a = 0.75f;
        spriteRenderer.color = color;
    }

    public void currentlyGazing() {}

    public void stoppedGazing() {
        spriteRenderer.color = originalColor;
    }
    
    public float getGazeTime() {
        return 0.1f;
    }
}
