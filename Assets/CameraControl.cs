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

    
    private void FixedUpdate()
    {
        Refresh();
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
}
