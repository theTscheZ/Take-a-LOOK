using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookTarget : MonoBehaviour
{
    public string color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkResult()
    {
        if (this.color == RNG.colorText)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Not Win");
        }
    }
}
