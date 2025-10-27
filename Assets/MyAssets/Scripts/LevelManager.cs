// 레벨의 진행을 담당
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Text instruction;
    public GameObject checkPoint;
    [TextArea(2, 5)]
    public List<string> comment;
    public List<Vector3> pos;
    public TextMeshProUGUI timerText;
    public int maxStep;
    public string nextSceneName;

    private int step;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        step = 0;
        UpdateInstruction();
        UpdatePos();
        GameManager.Instance.RegisterTimerText(timerText);
    }

    public void NextStep()
    {
        step += 1;

        if (step == maxStep)
        {
            if (nextSceneName != null)
            {
                GameManager.Instance.LoadSceneByName(nextSceneName);
            }
            return;
        }

        UpdateInstruction();
        UpdatePos();
    }

    private void UpdateInstruction()
    {
        if (comment != null && step < comment.Count)
        {
            instruction.text = comment[step];
        }
    }

    private void UpdatePos()
    {
        if (pos != null && step < pos.Count)
        {
            checkPoint.transform.position = pos[step];
        }
    }

    public void StartTimer()
    {
        GameManager.Instance.StartTimer();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
