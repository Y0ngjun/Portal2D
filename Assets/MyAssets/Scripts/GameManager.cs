// 게임 매니저
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject portal1;
    public GameObject portal2;
    public TextMeshProUGUI timerUI;
    public bool isGameOver;

    public float CurrentTime { get; private set; }
    private bool isTimerRunning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        isGameOver = false;
        CurrentTime = 0f;
        isTimerRunning = false;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            CurrentTime += Time.deltaTime;
        }

        if (timerUI != null)
        {
            timerUI.text = FormatTime(CurrentTime);
        }
    }

    public void StartTimer()
    {
        CurrentTime = 0f;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void SetPortal1(GameObject gameObject)
    {
        if (portal1 != null)
        {
            Destroy(portal1);
        }

        portal1 = gameObject;
        UpdatePortalLink();
    }

    public void SetPortal2(GameObject gameObject)
    {
        if (portal2 != null)
        {
            Destroy(portal2);
        }

        portal2 = gameObject;
        UpdatePortalLink();
    }

    private void UpdatePortalLink()
    {
        if (portal1 == null || portal2 == null)
        {
            return;
        }

        Portal p1 = portal1.GetComponent<Portal>();
        Portal p2 = portal2.GetComponent<Portal>();

        p1.linkedPortal = p2;
        p2.linkedPortal = p1;
    }

    public void RegisterTimerText(TextMeshProUGUI timerText)
    {
        timerUI = timerText;
    }

    public void LoadSceneByName(string sceneName)
    {
        if (sceneName == "MainMenu" || sceneName == "EndingScene")
        {
            timerUI = null;
        }

        if (sceneName == "Stage0")
        {
            StartTimer();
        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    private string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int milliseconds = (int)(time * 1000) % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
