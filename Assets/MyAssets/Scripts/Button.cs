using System.Runtime.InteropServices;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool IsActive
    {
        get
        {
            return count > 0;
        }
    }

    private Animator animator;
    private int count;

    void Start()
    {
        animator = GetComponent<Animator>();
        count = 0;
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (count == 0)
        {
            animator.SetBool("Active", true);
        }
        count++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (count == 1)
        {
            animator.SetBool("Active", false);
        }
        count--;
    }
}
