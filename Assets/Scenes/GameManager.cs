using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMisses;
    public int totalMisses;

    public float songLength;

    public double scoreMulti;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missText;
    public TextMeshProUGUI multiText;

    public TextMeshProUGUI resultText;

    public GameObject startButton;

    public float waitTimeL;
    public float waitTimeU;
    public float waitTimeD;
    public float waitTimeR;

    public GameObject leftArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject rightArrow;
    public Transform noteHolder;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        missText.text = "Misses: 0";
        multiText.text = "Multiplier: 0";
        scoreMulti = 1.0;

        waitTimeL = 2;
        waitTimeU = 3;
        waitTimeD = 4;
        waitTimeR = 5;

        theBS.hasStarted = false;
        theBS.hasEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying || theBS.hasEnded)
        {
            if(!startButton.activeSelf && !theBS.hasEnded)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if(waitTimeL > 0)
            {
                waitTimeL -= Time.deltaTime;
            }
            else
            {
                waitTimeL = (float)(Math.Round(UnityEngine.Random.value * 10) / 2.0 + 1);
                if (waitTimeL < songLength - 5)
                {
                    Instantiate(leftArrow, new Vector3(-7.75f, 9.04f, -0.05248405f), Quaternion.identity, noteHolder);
                }
            }
            if (waitTimeU > 0)
            {
                waitTimeU -= Time.deltaTime;
            }
            else
            {
                waitTimeU = (float)(Math.Round(UnityEngine.Random.value * 10) / 2.0 + 1);
                if(waitTimeU < songLength - 5)
                {
                    Instantiate(upArrow, new Vector3(-4.75f, 9.04f, -0.05248405f), Quaternion.identity, noteHolder);
                }
                
            }
            if (waitTimeD > 0)
            {
                waitTimeD -= Time.deltaTime;
            }
            else
            {
                waitTimeD = (float)(Math.Round(UnityEngine.Random.value * 10) / 2.0 + 1);
                if (waitTimeD < songLength - 5)
                {
                    Instantiate(downArrow, new Vector3(-1.75f, 9.04f, -0.05248405f), Quaternion.identity, noteHolder);
                }
            }
            if (waitTimeR > 0)
            {
                waitTimeR -= Time.deltaTime;
            }
            else
            {
                waitTimeR = (float)(Math.Round(UnityEngine.Random.value * 10) / 2.0 + 1);
                if (waitTimeR < songLength - 5)
                {
                    Instantiate(rightArrow, new Vector3(1f, 9.04f, -0.05248405f), Quaternion.identity, noteHolder);
                }
            }
            songLength -= Time.deltaTime;
            if(songLength <= 0)
            {
                startPlaying = false;
                theBS.hasEnded = true;
                startPlaying = false;
                theMusic.Stop();
                resultText.text = "You finished the song\nGame Over";
            }
        }
    }

    public void NoteHit()
    {

        currentScore += Convert.ToInt32(scorePerNote * scoreMulti);
        scoreText.text = "Score: " + currentScore;
        if(scoreMulti < 5)
        {
            scoreMulti += .25;
        }
        multiText.text = "Multiplier: " + scoreMulti;

    }
    public void NoteMissed()
    {

        currentMisses ++;
        missText.text = "Misses: " + currentMisses;
        scoreMulti = 1;
        multiText.text = "Multiplier: 1";

        if(currentMisses >= totalMisses)
        {
            startPlaying = false;
            theBS.hasEnded = true;
            startPlaying = false;
            theMusic.Stop();
            resultText.text = "You missed too many notes\nGame Over";
        }
    }

}
