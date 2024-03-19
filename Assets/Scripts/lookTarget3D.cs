using System;
using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.UI;

public class LookTarget3D : MonoBehaviour
{
    public string color;
    GazeAware gazeAware = null;
    public bool isSelected = false;
    

    private void Awake()
    {
        gazeAware = GetComponent<GazeAware>();
        // Debug.Log("GazeAware");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gazeAware.HasGazeFocus);
        if (gazeAware.HasGazeFocus)
        {
            Selected();
        }
        else
        {
            isSelected = false;
        }
    }

    public void checkResult()
    {
        Debug.Log("Check Result");
        if (this.color == RNG3D.colorText)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Not Win");
        }
    }

    public virtual void Selected()
    {
        if (isSelected)
        {
            return;
        }
        isSelected = true;
        
        checkResult();
    }
}