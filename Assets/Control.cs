using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Vector3 growthValue=new Vector3(0.2f, 0.2f, 0f);
    [SerializeField] private float _swipeSpeed = 10f;
    [SerializeField] private float _runSpeed = 5f;
    [Header("Karakterin kenarlardan düþmemesi için gerekli yarýçap")]
    [SerializeField] private float _radius=2f;
    void Start()
    {
        //growthValue = new Vector3(0.2f, 0.2f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _runSpeed);
        SwipeMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag=="Ruj")
        {
            transform.localScale += growthValue;
            Destroy(other.gameObject);
        }
    }

    private void SwipeMovement()
    {
        Vector3 centerPosition = transform.position;
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                float distance = Vector3.Distance(transform.position, centerPosition);
                if (distance > _radius)
                {
                    Vector3 fromOriginToObject = transform.position - centerPosition;
                    fromOriginToObject *= _radius / distance;
                    transform.position = centerPosition + fromOriginToObject;
                }
                else
                {

                }
                transform.position = new Vector3(
                     transform.position.x + Input.touches[0].deltaPosition.x * _swipeSpeed * 0.24f * Time.deltaTime,
                     transform.position.y,
                     transform.position.z);
            }
        }
    }
}
