using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject kissFx, kissFxPoint;
    public bool _isKissed;
    private void Start()
    {
        _isKissed = false;
    }
    public void CreateKissFx()
    {
        Destroy(Instantiate(kissFx, kissFxPoint.transform.position, Quaternion.identity),0.5f);
    }
    public void EnemyKissed()
    {
        _isKissed = true;
        transform.eulerAngles = new Vector3(0, 180, 0);
        GetComponent<Animator>().SetBool("isHit", true);
        GetComponent<Animator>().SetBool("isHappy", true);
    }
}
