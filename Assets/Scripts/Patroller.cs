using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform[] Waypoints;
    [SerializeField] private int _speed;

    private int _waypointIndex;
    private float _distance;
    void Start()
    {
        _waypointIndex = 0;
        transform.LookAt(Waypoints[_waypointIndex].position, Vector3.zero);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<EnemyController>()._isKissed)
        {
            if (!GetComponent<Animator>().GetBool("isWalk"))
            {
                GetComponent<Animator>().SetBool("isIdle", false);
                GetComponent<Animator>().SetBool("isWalk", true);
            }
            _distance = Vector3.Distance(transform.position, Waypoints[_waypointIndex].position);
            if (_distance < 1.5f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalk", false);
            GetComponent<Animator>().SetBool("isHit", true);
            GetComponent<Animator>().SetBool("isHappy", true);
            //GetComponent<Animator>().SetBool("isIdle", true);
        }
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    void IncreaseIndex()
    {
        _waypointIndex++;
        if (_waypointIndex >= Waypoints.Length)
        {
            _waypointIndex = 0;
        }
        transform.LookAt(Waypoints[_waypointIndex].position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
   
}
