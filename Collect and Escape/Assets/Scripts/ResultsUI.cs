using UnityEngine;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;

    private void Start()
    {
        float lastRun = SceneFlowManager.LastRunTime;

        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (lastRun < bestTime)
        {
            bestTime = lastRun;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
        }

        currentTimeText.text = "Your Time: " + FormatTime(lastRun);
        bestTimeText.text = "Best Time: " + (bestTime == float.MaxValue ? "N/A" : FormatTime(bestTime));
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }
}
