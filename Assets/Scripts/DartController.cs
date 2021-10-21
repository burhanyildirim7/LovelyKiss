using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    [SerializeField] private GameObject konfetiPackage;

    private void Start()
    {
        konfetiPackage.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.tag=="Kiss")
        {
            konfetiPackage.SetActive(true);
        }
    }
}
