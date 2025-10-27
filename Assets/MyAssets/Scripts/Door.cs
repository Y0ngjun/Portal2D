using UnityEngine;

public class Door : MonoBehaviour
{
    public Trigger trigger;

    private Animator animator;
    private BoxCollider2D boxCollider2d;
    private bool open;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        open = false;
    }

    void Update()
    {
        if (trigger == null)
        {
            return;
        }

        if (open && !trigger.IsActive)
        {
            animator.SetBool("Open", false);
            open = false;
        }
        else if (!open && trigger.IsActive)
        {
            animator.SetBool("Open", true);
            open = true;
        }
    }

    public void SetCollider()
    {
        if (open)
        {
            boxCollider2d.enabled = false;
        }
        else
        {
            boxCollider2d.enabled = true;
        }
    }
}
