using Tobii.Gaming;
using UnityEngine;

public class LookTarget3D : MonoBehaviour
{
    public string color;
    GazeAware gazeAware = null;
    public bool isSelected = false;
    private Timer timer;
    private Renderer renderer;
    // private Color highlightColor;

    private void Awake()
    {
        gazeAware = GetComponent<GazeAware>();
        timer = new Timer(5f); // Timer mit einer Dauer von 5 Sekunden initialisieren
        timer.TimerExpired += TimerExpiredHandler; // Ereignisbehandlungsmethode abonnieren
        renderer = GetComponent<Renderer>();
        // highlightColor = renderer.material.GetColor("_EmissionColor");
        // highlightColor.a = 0.69f;
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
            Deselect();
        }
    }

    public void checkResult()
    {
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
            // Debug.Log("COLOR: " + this.color);
            // Debug.Log("COLORTEXT: " + RNG3D.colorText);

            GameObject.Find("RNG").GetComponent<RNG3D>().Randomize();
        }

        // highlightColor = renderer.material.GetColor("_EmissionColor");
        // highlightColor.a = 0.69f;
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

        // renderer.material.SetColor("_EmissionColor", highlightColor);
        
        isSelected = true;
    }
    
    private void Deselect()
    {
        // highlightColor.a = 1;
        // renderer.material.SetColor("_EmissionColor", highlightColor);
        
        isSelected = false;
    }
}