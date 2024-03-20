using Tobii.Gaming;
using UnityEngine;

public class LookTarget3D : MonoBehaviour
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
        timer = new Timer(5f); // Timer mit einer Dauer von 5 Sekunden initialisieren
        timer.TimerExpired += TimerExpiredHandler; // Ereignisbehandlungsmethode abonnieren
        renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        timer.StartTimer();
    }

    void Update()
    {
        timer.UpdateTimer(); // Timer aktualisieren

        // Überprüfe, ob der Blick auf das Objekt gerichtet ist
        if (gazeAware.HasGazeFocus)
        {
            Select();
        }
        else
        {
            // Debug.Log("no GazeAware");
            Deselect();
        }
    }

    public void checkResult()
    {
        Debug.Log("isSelected: " + isSelected);
        if (isSelected)
        {
            if (color == RNG3D.colorText)
            {
                Debug.Log("Gewonnen");
            }
            else
            {
                Debug.Log("Nicht gewonnen");
            }
            Debug.Log("COLOR: " + this.color);
            Debug.Log("COLORTEXT: " + RNG3D.colorText);
        }
        GameObject.Find("RNG").GetComponent<RNG3D>().Randomize();
        isSelected = false;
    }

    private void TimerExpiredHandler()
    {
        checkResult(); // checkResult() aufrufen, wenn der Timer abgelaufen ist
        timer.ResetTimer();
        timer.StartTimer();
    }

    private void Select()
    {
        if (isSelected)
        {
            return;
        }
        
        originalColor = renderer.material.GetColor("_EmissionColor");
        originalColor.r += 0.3f;
        originalColor.g += 0.3f; 
        originalColor.b += 0.3f; 
        renderer.material.SetColor("_EmissionColor", originalColor);
        
        isSelected = true;
    }
    
    private void Deselect()
    {
        if (!isSelected)
        {
            return;
        }
        
        originalColor.r -= 0.3f; 
        originalColor.g -= 0.3f; 
        originalColor.b -= 0.3f;
        renderer.material.SetColor("_EmissionColor", originalColor);
        
        isSelected = false;
    }
}