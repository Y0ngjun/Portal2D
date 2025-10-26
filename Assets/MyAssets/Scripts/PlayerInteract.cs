using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform interactPoint;
    public PlayerInput playerInput;
    public float detectionRadius;

    private SpriteRenderer spriteRenderer;
    private GameObject heldObject;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePoint();
        Interact();
    }

    private void MovePoint()
    {
        if (spriteRenderer.flipX)
        {
            interactPoint.localPosition = new Vector3(-Mathf.Abs(interactPoint.localPosition.x), 0, 0);
        }
        else
        {
            interactPoint.localPosition = new Vector3(Mathf.Abs(interactPoint.localPosition.x), 0, 0);
        }
    }

    private void Interact()
    {
        if (playerInput.interact)
        {
            if (heldObject == null)
            {
                TryGrabObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    private void TryGrabObject()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(interactPoint.position, detectionRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Interactive"))
            {
                GrabObject(hitCollider.gameObject);
                return;
            }
        }
    }

    private void GrabObject(GameObject go)
    {
        heldObject = go;

        Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            heldObject.transform.SetParent(interactPoint);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
        }
    }

    private void DropObject()
    {
        Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            heldObject.transform.SetParent(null);
            rb.isKinematic = false;
        }

        heldObject = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, detectionRadius);
    }
}
