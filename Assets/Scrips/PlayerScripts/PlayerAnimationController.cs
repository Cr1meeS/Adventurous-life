using UnityEngine;

public class PlayerAnimationController
{
    public Animator _animator;

    public PlayerAnimationController(Animator animator)
    {
        _animator = animator;
    }

    public void SetAnimationBool(string boolName, bool value)
    {
        _animator.SetBool(boolName, value);
    }
}
