using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class kissAtma : MonoBehaviour
{

    //[SerializeField] GameObject KissObject;
    Animator OpmeAnimatoru;


    
    void Start()
    {
       // OpmeAnimatoru.SetBool("OP",false);
        OpmeAnimatoru = GetComponent<Animator>();
    }

    public void KissAt()
    {
        OpmeAnimatoru.SetBool("isKiss", true);
    }

  
}
