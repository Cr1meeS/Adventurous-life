using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public void Jump(Rigidbody rigidbody, Vector3 jumpDirection)
    {
        rigidbody.MovePosition(jumpDirection);
    }
}
