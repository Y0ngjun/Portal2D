// 플레이어의 슈팅 애니메이션 실행 여부
using UnityEngine;

public class PlayerShootingBehaviour : StateMachineBehaviour
{
    private PlayerMovement playerMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerMovement == null)
        {
            playerMovement = animator.GetComponent<PlayerMovement>();
        }

        if (playerMovement != null)
        {
            playerMovement.SetShootingState(true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerMovement != null)
        {
            playerMovement.SetShootingState(false);
        }
    }
}
