// 게임 매니저
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject portal1;
    public GameObject portal2;
    public bool isGameOver;

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
        isGameOver = false;
    }

    void Update()
    {

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
}
