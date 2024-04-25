using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    public float time = 2;
    //private GameObject threeD;
    private LookTarget[] gazeAwares;

    void Start()
    {
        //threeD = GameObject.Find("3D");
        //threeD.SetActive(false);
        gazeAwares = FindObjectsOfType(typeof(LookTarget)) as LookTarget[];
        foreach (LookTarget gazeAware in gazeAwares)
        {
            gazeAware.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (Stats.health > 0)
            {
                Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
                timer.StartTimer();
                //threeD.SetActive(true);
                foreach (LookTarget gazeAware in gazeAwares)
                {
                    gazeAware.enabled = true;
                }
            }
            else
            {
                GameObject canvas = GameObject.Find("Canvas");
                GameObject myPrefab = Resources.Load("gameoverscreen") as GameObject;
                Instantiate(myPrefab, canvas.transform);
            }
            Destroy(this.gameObject);
        }
    }
}
