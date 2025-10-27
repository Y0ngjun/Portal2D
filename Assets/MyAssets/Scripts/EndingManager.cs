using UnityEngine;
using TMPro;

public class EndingManager : MonoBehaviour
{
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI yourTimeText;
    public GameObject newRecordText;

    void Start()
    {
        GameManager.Instance.StopTimer();
        float yourTime = GameManager.Instance.CurrentTime;
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (yourTime < bestTime)
        {
            bestTime = yourTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            newRecordText.SetActive(true);
        }
        else
        {
            newRecordText.SetActive(false);
        }

        bestTimeText.text = "Best Time: " + FormatTime(bestTime);
        yourTimeText.text = "Your Time: " + FormatTime(yourTime);
    }

    public void PlayAgain()
    {
        GameManager.Instance.LoadSceneByName("Stage0");
    }

    public void Quit()
    {
        GameManager.Instance.QuitGame();
    }

    private string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int milliseconds = (int)(time * 1000) % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
