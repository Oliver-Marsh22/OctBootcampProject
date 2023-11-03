using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    
    private int totalScore;
    
    private bool isSpare = false;
    private bool isStrike = false;

    private int[] frames = new int[10];

    public int currentThrow {  get; private set; }
    public int currentFrame { get; private set; }

    private void Start()
    {
             ResetScore();
    }

    //set value for our frame score each time we throw the ball
    public void SetFrameScore(int score)
    {
        //ball1
        if(currentThrow == 1)
        {

            frames[currentFrame - 1] += score; //setting the right frame index and adding the score value from the parameter passed
            
            //parallel process to check if spare
            if(isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            //-----------------------

            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++; //wait for ball 2
                }else
                {
                    isStrike = true;
                    currentFrame++; //move to next frame since full marks obtained
                }

                //todo gamemanager to reset pins
                gameManager.ResetAllPins();
            }
            else
            {
                currentThrow++; // wait for ball 2
            }

            return;
        }

        //ball2
        if(currentThrow == 2)
        {
            frames[currentFrame] += score;

            //parallel process check if strike
            if(isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            //----------------------------------------------

            if (frames[currentFrame - 1] == 10) //istotalframescore10?
            {
                if (currentFrame == 10)
                { currentThrow++; } //wait for ball 3
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;
                }
            } 
            else
            {
                if (currentFrame == 10)
                {
                    //end of all throws
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            gameManager.ResetAllPins();
            return;
        }

        //ball 3 only frame 10
        if (currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;
            //end of all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }

    }

    public int CalculateTotalScore()
    {
    totalScore = 0;
        foreach (var frame in frames)
        {
            totalScore += frame;
        }

        return totalScore;
    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }

}
