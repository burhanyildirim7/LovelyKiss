using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameActive;
    public static int collectedDiamondNumber=0, collectedLipstickNumber=0;

    void Start()
    {
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
