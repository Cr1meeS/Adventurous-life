using UnityEngine;

public class PlayerRotating
{
    public void Rotate(Vector2 viewDirection, Transform camera, Transform player, float rotateSpeed)
    {
        float currentRotationAngle = ComputeCurrentRotationAngle(viewDirection);
        Quaternion currentDirection = Quaternion.Euler(new Quaternion(player.rotation.x, camera.rotation.y, player.rotation.z, camera.rotation.w).eulerAngles - Quaternion.Euler(0f, currentRotationAngle, 0f).eulerAngles);

        player.rotation = Quaternion.Slerp(player.rotation, currentDirection, Time.deltaTime * rotateSpeed);
    }

    private float ComputeCurrentRotationAngle(Vector2 viewDirection)
    {
        if (viewDirection == Vector2.zero)
        {
            return 0f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(0f, 1f)) == 0f)
        {
            return 0f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(0f, -1f)) == 0f)
        {
            return 180f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(-1f, 0f)) == 0f)
        {
            return 90f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(1f, 0f)) == 0f)
        {
            return 270f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(-0.71f, 0.71f)) == 0f)
        {
            return 45f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(0.71f, 0.71f)) == 0f)
        {
            return 315f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(-0.71f, -0.71f)) == 0f)
        {
            return 135f;
        }
        else if (Vector2.Angle(viewDirection, new Vector2(0.71f, -0.71f)) == 0f)
        {
            return 225f;
        }
        else
        {
            return 0f;
        }
    }
}
