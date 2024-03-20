using Tobii.Gaming;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    public string color;
    GazeAware gazeAware = null;
    public bool isSelected = false;
    private Timer timer;
    private Renderer renderer;
    private Color originalColor;

    private void Awake()
    {
        gazeAware = GetComponent<GazeAware>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Überprüfe, ob der Blick auf das Objekt gerichtet ist
        if (gazeAware.HasGazeFocus)
        {
            Select();
        }
        else
        {
            // Debug.Log("no GazeAware");
            // Deselect();
            isSelected = false;
        }
    }

    public void checkResult()
    {
        // Debug.Log("isSelected: " + isSelected);
        if (isSelected)
        {
            if (color == RNG.colorText)
            {
                Debug.Log("Gewonnen");
            }
            else
            {
                Debug.Log("Nicht gewonnen");
            }
            // Debug.Log("COLOR: " + this.color);
            // Debug.Log("COLORTEXT: " + RNG3D.colorText);
            // timer.ResetTimer();
            timer.ResetTimer();
        }
        isSelected = false;
    }

    // private void TimerExpiredHandler()
    // {
    //     checkResult(); // checkResult() aufrufen, wenn der Timer abgelaufen ist
    //     timer.ResetTimer();
    //     timer.StartTimer();
    // }

    private void Select()
    {
        // if (isSelected)
        // {
        //     return;
        // }

        // originalColor = renderer.material.GetColor("_EmissionColor");
        // originalColor.r += 0.3f;
        // originalColor.g += 0.3f;
        // originalColor.b += 0.3f;
        // renderer.material.SetColor("_EmissionColor", originalColor);

        isSelected = true;
        checkResult();
    }

    // private void Deselect()
    // {
    //     if (!isSelected)
    //     {
    //         return;
    //     }
    //
    //     originalColor.r -= 0.3f;
    //     originalColor.g -= 0.3f;
    //     originalColor.b -= 0.3f;
    //     renderer.material.SetColor("_EmissionColor", originalColor);
    //
    //     isSelected = false;
    // }
}