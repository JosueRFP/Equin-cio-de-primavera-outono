using UnityEngine;

public class AnimatorController : MonoBehaviour, IMonstable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MonsterAnimationChange(MonsterStates state)
    {
        switch (state)
        {
            case MonsterStates.Wait:
                animator.SetBool("isRunning", false);
                break;
            case MonsterStates.Patrol:
            case MonsterStates.Chase:
            case MonsterStates.Search:
                animator.SetBool("isRunning", true);
                break;
        }
    }
}
