using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class kissAtma : MonoBehaviour
{

    [SerializeField] GameObject KissObject;
    [SerializeField] Animator OpmeAnimatoru;


    // Start is called before the first frame update
    void Start()
    {
        OpmeAnimatoru.SetBool("OP",false);
        OpmeAnimatoru = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
