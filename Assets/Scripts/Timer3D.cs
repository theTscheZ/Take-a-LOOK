using UnityEngine;
using UnityEngine.UI;

public class Timer3D : MonoBehaviour
{
    public Timer timer;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        timer = new Timer(5f); // Timer mit einer Dauer von 5 Sekunden initialisieren
        timer.TimerExpired += TimerExpiredHandler; // Ereignisbehandlungsmethode abonnieren
        timer.TimerUpdated += TimerUpdatedHandler;
    }

    void Start()
    {
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer.UpdateTimer(); // Timer aktualisieren
    }

    private void TimerExpiredHandler()
    {
        timer.ResetTimer();
        timer.StartTimer();
    }

    private void TimerUpdatedHandler()
    {
        float timeRemaining = timer.getDuration() - timer.getElapsedTime();
        image.fillAmount = timeRemaining / timer.getDuration();
    }
}