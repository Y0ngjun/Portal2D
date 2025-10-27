// 지연 시간을 두고 플레이어를 추적
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public PlayerInput playerInput;
    public Transform target;
    public Vector3 defaultOffset;
    public float followSpeed;
    public float manualSpeed;
    public float maxCameraOffsetY;
    public float minCameraOffsetY;

    private Vector3 currentOffset;

    private void Start()
    {
        currentOffset = defaultOffset;
    }

    void LateUpdate()
    {
        if (target == null || playerInput == null)
        {
            return;
        }

        Vector2 manualInput = Vector2.zero;
        if (playerInput.cameraUp) manualInput.y += 1;
        if (playerInput.cameraDown) manualInput.y += -1;

        if (manualInput != Vector2.zero)
        {
            currentOffset += (Vector3)manualInput.normalized * manualSpeed * Time.deltaTime;
        }
        else
        {
            currentOffset = Vector3.Lerp(currentOffset, defaultOffset, followSpeed * Time.deltaTime);
        }

        float minY = defaultOffset.y - minCameraOffsetY;
        float maxY = defaultOffset.y + maxCameraOffsetY;
        currentOffset.y = Mathf.Clamp(currentOffset.y, minY, maxY);

        Vector3 desiredPosition = target.position + currentOffset;
        desiredPosition.z = transform.position.z;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
