using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CallHandler : MonoBehaviour {

    public Ball theBall;

    public Text ballText;
    public Text strikeText;
    public Text outText;
    public Text inningText;

    public EventTextHandler eventHandler;

    public int balls, strikes, outs = 0;
    public int inning = 1;

    public int totalCalls = 0;
    public int correctCalls = 0;
    
    public void Start()
    {
        PlayerPrefs.SetInt("correctCalls",0);
        PlayerPrefs.SetInt("totalCalls",0);
    }

    public void callBall()
    {
        totalCalls += 1;
        updateBalls(balls + 1);

        if (!theBall.isStrike())
        {
            Debug.Log("Correct - Ball");
            correctCalls += 1;
        }
        else
        {
            Debug.Log("Incorrect - Strike");
        }

        if(balls == 4)
        {
            eventHandler.eventWalk();
            updateBalls(0);
            updateStrikes(0);
            //New batter
            //Decide whether or not to keep track of base runners.
        }

        theBall.waitingCall = false;
        theBall.newPitch();
    }
    public void callStrike()
    {
        totalCalls += 1;
        updateStrikes(strikes + 1);

        if (theBall.isStrike())
        {
            Debug.Log("Correct - Strike");
            correctCalls += 1;
        }
        else
        {
            Debug.Log("Incorrect - Ball");
        }

        if (strikes == 3)
        {
            eventHandler.eventStrikeOut();
            updateStrikes(0);
            updateBalls(0);
            updateOuts(outs + 1);
            //new batter
            if(outs == 3)
            {
                nextInning();
            }
        }

        theBall.waitingCall = false;
        theBall.newPitch();
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
        if(inning!=3)
        {
            updateInning(inning + 1);

            updateBalls(0);
            updateStrikes(0);
            updateOuts(0);
        }
        else
        {
            endGame();
        }
    }

    public void endGame()
    {
        PlayerPrefs.SetInt("correctCalls", correctCalls);
        PlayerPrefs.SetInt("totalCalls", totalCalls);
        SceneManager.LoadScene(2);
    }

}
