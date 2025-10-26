// 문이 열렸음을 알려주는 역할
using UnityEngine;

public class DoorBehaviour : StateMachineBehaviour
{
    private Door door;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (door == null)
        {
            door = animator.GetComponent<Door>();
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (door != null)
        {
            door.SetCollider();
        }
    }
}
