using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition = new Vector3(0, 5, -12);

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    public static bool cameraFinish;

    private GameObject _targetObject;

    private void Start()
    {
        cameraFinish = false;
    }
    private void Update()
    {
        if (GameController.isGameActive == true)
        {
            if (!cameraFinish)
                Refresh();
            else
            {
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                transform.LookAt(target);
            }
        }
       
    }
    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

    public void CameraSetTarget()
    {
        _targetObject = GameObject.FindGameObjectWithTag("Player");
        target = _targetObject.transform;
    }

    public void CameraResetPosition()
    {
        transform.position = new Vector3(0f, 11, -14);
        transform.rotation = Quaternion.Euler(23, 0, 0);
    }
}
