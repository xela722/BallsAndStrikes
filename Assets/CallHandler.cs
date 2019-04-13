using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHandler : MonoBehaviour {

    public Ball theBall;

    public Text ballText;
    public Text strikeText;
    public Text outText;

    public int balls, strikes, outs = 0;

    public void callBall()
    {
        if (theBall.isStrike())
        {
            theBall.newPitch();
        }
        balls += 1;
        ballText.text = string.Format("Balls: {0}", balls);
    }
    public void callStrike()
    {
        if (theBall.isStrike())
        {
            
            theBall.newPitch();
        }
        strikes += 1;
        strikeText.text = string.Format("Strikes: {0}", strikes);
    }
}
