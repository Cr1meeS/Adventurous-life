using System.Collections;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public delegate void PlayerJump();
    public event PlayerJump OnLanded;

    private IEnumerator JumpByTime(float duration, Rigidbody rigidbody, float jumpHeight, AnimationCurve yAnimation)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        Vector3 startPosirion = rigidbody.position;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            Vector3 currentposition = rigidbody.position;
            Vector3 jumpDirection = new Vector3(currentposition.x, startPosirion.y, currentposition.z) + new Vector3(0, yAnimation.Evaluate(progress) * jumpHeight, 0);
            rigidbody.MovePosition(jumpDirection);
            yield return null;
        }

    }

    public void Jump(float duraction, Rigidbody rigidbody, float jumpHeight, AnimationCurve yAnimation)
    {
        StartCoroutine(JumpByTime(duraction, rigidbody, jumpHeight, yAnimation));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnLanded?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {

        }
    }
}
