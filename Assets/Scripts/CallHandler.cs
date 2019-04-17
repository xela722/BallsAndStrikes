﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHandler : MonoBehaviour {

    public Ball theBall;

    public Text ballText;
    public Text strikeText;
    public Text outText;
    public Text inningText;

    public EventTextHandler eventHandler;

    public int balls, strikes, outs = 0;
    public int inning = 1;

    public void callBall()
    {
        theBall.newPitch();
        updateBalls(balls + 1);

        if(balls == 4)
        {
            eventHandler.eventWalk();
            updateBalls(0);
            updateStrikes(0);
            //New batter
            //Decide whether or not to keep track of base runners.
        }
    }
    public void callStrike()
    {
        theBall.newPitch();
        updateStrikes(strikes + 1);

        if (strikes == 3)
        {
            eventHandler.eventStrikeOut();
            updateStrikes(0);
            updateBalls(0);
            updateOuts(outs + 1);
            if(outs == 3)
            {
                nextInning();
            }
        }
    }

    void updateBalls(int ballCount)
    {
        balls = ballCount;
        ballText.text = string.Format("Balls: {0}", balls);
    }
    void updateStrikes(int strikeCount)
    {
        strikes = strikeCount;
        strikeText.text = string.Format("Strikes: {0}", strikes);
    }
    void updateOuts(int outCount)
    {
        outs = outCount;
        outText.text = string.Format("Outs: {0}", outs);
    }
    void updateInning(int inningCount)
    {
        inning = inningCount;
        inningText.text = string.Format("Inning: {0}", inning);
    }

    public void nextInning()
    {
        updateInning(inning + 1);

        updateBalls(0);
        updateStrikes(0);
        updateOuts(0);
    }
}
