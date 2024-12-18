using Tobii.Gaming;
using UnityEngine;
using UnityEngine.UI;

public class LookTarget : MonoBehaviour
{
    public string color;
    GazeAware gazeAware = null;
    public bool isSelected = false;
    private Timer timer;
    // private Renderer renderer;
    private Color originalColor;
    private float selectionTimer = 0.2f;
    private Sprite eyesOpen;
    private Sprite eyesClosed;
    private SpriteRenderer eyes;

    private void Awake()
    {
        gazeAware = GetComponent<GazeAware>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        // renderer = GetComponent<Renderer>();
        eyesClosed = Resources.Load("Images/Eye_Closed", typeof(Sprite)) as Sprite;
        eyesOpen = Resources.Load("Images/Eye_Open", typeof(Sprite)) as Sprite;
        eyes = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Überprüfe, ob der Blick auf das Objekt gerichtet ist
        if (gazeAware.HasGazeFocus)
        {
            eyes.sprite = eyesOpen;
            selectionTimer -= Time.deltaTime;
            if (selectionTimer <= 0)
            {
                checkResult();
            }
            Select();
        }
        else
        {
            eyes.sprite = eyesClosed;
            // Debug.Log("no GazeAware");
            Deselect();
            selectionTimer = 0.2f;
            // isSelected = false;
        }
    }

    public void checkResult()
    {
        // Debug.Log("isSelected: " + isSelected);
        if (isSelected)
        {
            if (color == RNG.colorText == Stats.objectiveTruth)
            {
                Debug.Log("Gewonnen");
                Stats.score++;
                Text scoreText = GameObject.Find("scoreText").GetComponent<Text>();
                scoreText.text = "Score: " + Stats.score;
                // Show Win Screen
                GameObject canvas = GameObject.Find("Canvas");
                GameObject myPrefab = Resources.Load("winscreen") as GameObject;
                Instantiate(myPrefab, canvas.transform);

            }
            else
            {
                Debug.Log("Nicht gewonnen");
                Stats.health--;
                Slider healthSlider = GameObject.Find("healthSlider").GetComponent<Slider>();
                healthSlider.value = Stats.health;
                // Show Lose Screen
                GameObject canvas = GameObject.Find("Canvas");
                GameObject myPrefab = Resources.Load("losescreen") as GameObject;
                Instantiate(myPrefab, canvas.transform);

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
        if (isSelected)
        {
            return;
        }

        // originalColor = renderer.material.GetColor("_EmissionColor");
        // originalColor.r += 0.3f;
        // originalColor.g += 0.3f;
        // originalColor.b += 0.3f;
        // renderer.material.SetColor("_EmissionColor", originalColor);

        isSelected = true;
    }

    private void Deselect()
    {
        if (!isSelected)
        {
            return;
        }

        // originalColor.r -= 0.3f;
        // originalColor.g -= 0.3f;
        // originalColor.b -= 0.3f;
        // renderer.material.SetColor("_EmissionColor", originalColor);

        isSelected = false;
    }
}