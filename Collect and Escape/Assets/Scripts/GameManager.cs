using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalCollectables;
    private int collected = 0, minutes, seconds;

    public DoorController door;

    public TextMeshProUGUI collectableText;
    public TextMeshProUGUI timerText;

    private float timer = 0f;
    private bool isPaused = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        UpdateCollectableUI();
    }

    void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    public void Collect()
    {
        collected++;

        UpdateCollectableUI();

        if (collected >= totalCollectables)
        {
            door.UnlockDoor();
        }
    }

    private void UpdateCollectableUI()
    {
        collectableText.text = collected + " / " + totalCollectables;
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            minutes = Mathf.FloorToInt(timer / 60);
            seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void PauseGame(bool pause)
    {
        isPaused = pause;
        Time.timeScale = pause ? 0 : 1;
    }

    public void FinishLevel()
    {
        SceneFlowManager.LastRunTime = timer;
    }
}
