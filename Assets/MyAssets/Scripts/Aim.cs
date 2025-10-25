using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform playerTransform;
    public float dotsPerUnit;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        bool isInsideScreen = mouseScreenPos.x >= 0 && mouseScreenPos.x <= Screen.width &&
                              mouseScreenPos.y >= 0 && mouseScreenPos.y <= Screen.height;

        if (isInsideScreen)
        {
            Cursor.visible = false;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0;
            transform.position = mouseWorldPos;
        }
        else
        {
            Cursor.visible = true;
        }

        if(playerTransform == null)
        {
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, playerTransform.position);
        lineRenderer.SetPosition(1, transform.position);

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        lineRenderer.material.mainTextureScale = new Vector2(distance * dotsPerUnit, 1f);
    }
}
