using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _cameraRotateSpeed, _cameraMoveSpeed, _cameraDistance, _smoth;
    [SerializeField] GameObject _player;
    [SerializeField] Transform target;
    [SerializeField] Transform parent;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        target.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 1f, _player.transform.position.z);

        float horizontalAxis = Input.GetAxis("Mouse X");
        float verticalAxis = Input.GetAxis("Mouse Y");

        parent.transform.RotateAround(target.transform.position, -Vector3.up, -horizontalAxis * _cameraRotateSpeed);

        if (parent.transform.rotation.eulerAngles.x > 30 && parent.transform.rotation.eulerAngles.x < 35 && verticalAxis > 0)
        {
            parent.transform.RotateAround(target.transform.position, -transform.right, verticalAxis * _cameraRotateSpeed);
        }
        else if (parent.transform.rotation.eulerAngles.x > 30 && parent.transform.rotation.eulerAngles.x < 35 && verticalAxis < 0)
        {
        }
        else if (parent.transform.rotation.eulerAngles.x < 350 && parent.transform.rotation.eulerAngles.x > 300 && verticalAxis < 0)
        {
            parent.transform.RotateAround(target.transform.position, -transform.right, verticalAxis * _cameraRotateSpeed);
        }
        else if (parent.transform.rotation.eulerAngles.x < 350 && parent.transform.rotation.eulerAngles.x > 300 && verticalAxis > 0)    
        {
        }
        else
        {
            parent.transform.RotateAround(target.transform.position, -transform.right, verticalAxis * _cameraRotateSpeed);
        }
        ControlPosition();
        ControlRotation();
    }

    private void ControlRotation()
    {
        transform.LookAt(target);
    }

    private void ControlPosition()
    {
        parent.position = target.position;
    }
}
