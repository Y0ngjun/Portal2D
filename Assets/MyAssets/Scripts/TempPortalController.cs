// 포탈 위치 프리셋 (임시)
using UnityEngine;

public class TempPortalController : MonoBehaviour
{
    public Portal portal1;
    public Portal portal2;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            portal1.transform.position = new Vector3(-8f, -2f, 0);
            portal1.transform.rotation = Quaternion.Euler(0, 0, 180f);
            portal2.transform.position = new Vector3(8f, -2f, 0);
            portal2.transform.rotation = Quaternion.Euler(0, 0, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            portal1.transform.position = new Vector3(6f, 4f, 0);
            portal1.transform.rotation = Quaternion.Euler(0, 0, 90f);
            portal2.transform.position = new Vector3(6f, -4f, 0);
            portal2.transform.rotation = Quaternion.Euler(0, 0, 270f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            portal1.transform.position = new Vector3(-6f, -4f, 0);
            portal1.transform.rotation = Quaternion.Euler(0, 0, 270f);
            portal2.transform.position = new Vector3(6f, -4f, 0);
            portal2.transform.rotation = Quaternion.Euler(0, 0, 270f);
        }
    }
}
