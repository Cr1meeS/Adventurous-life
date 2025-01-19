using UnityEngine;

public class PlayerMoving
{
    Vector3 currentMoveDirection;

    public void Move(Vector2 moveDirection, Transform camera,Rigidbody rigidbody , float speed)
    {
        currentMoveDirection = ComputeCurrentMoveDirection(moveDirection, camera);

        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * currentMoveDirection);
    }

    private Vector3 ComputeCurrentMoveDirection(Vector2 moveDirection, Transform camera)
    {
        Vector3 currentPlayerMoveDirection = new Vector3(moveDirection.x, 0f, moveDirection.y);
        Vector3 transformedCameraZoneDirection = camera.TransformDirection(currentPlayerMoveDirection);
        Vector3 currentMoveDirection = new Vector3(transformedCameraZoneDirection.x, 0f, transformedCameraZoneDirection.z);

        return currentMoveDirection;
    }
}
