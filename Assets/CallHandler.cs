using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHandler : MonoBehaviour {

    public Ball theBall;

    public void callBall()
    {
        if (theBall.isStrike())
        {
            Debug.Log("WRONG");
            theBall.newPitch();
        }
    }
    public void callStrike()
    {
        if (theBall.isStrike())
        {
            Debug.Log("CORRECT");
            theBall.newPitch();
        }
    }
}
