using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningObject : MonoBehaviour
{
    [SerializeField] public float _speed = 5f;

    public float defaultSpeed;
    public Vector3 defaultScale;
    private void Start()
    {
        defaultSpeed = _speed;
        defaultScale = transform.GetChild(0).GetChild(0).localScale;
    }
    void Update()
    {
        if (GameController.isGameActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
    }

    public void ResetCharacterTransform()
    {
        transform.position = new Vector3(0f, 4f, 0f);
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(0).GetChild(0).localScale = defaultScale;
        _speed = defaultSpeed;
    }
}
