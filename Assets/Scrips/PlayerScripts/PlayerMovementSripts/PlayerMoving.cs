using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public void Move(Vector3 currentMoveDirection, Transform camera,Rigidbody rigidbody , float speed)
    {
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * currentMoveDirection);
    }
}
