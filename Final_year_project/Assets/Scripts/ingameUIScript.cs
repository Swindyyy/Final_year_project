﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ingameUIScript : MonoBehaviour {

    public static ingameUIScript ingameUISingleton;
    GMScript gameManager;    
    playerManager playerMan;
    turnManagerScript tm;

    string player1Target;
    string player2Target;

    [SerializeField]
    private Text targetText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text endGameText;
    [SerializeField]
    private Text turnText;
    [SerializeField]
    private GameObject ingameTextObject;
    [SerializeField]
    private GameObject colourSelectObject;

    private void Awake()
    {
        if(ingameUISingleton == null)
        {
            ingameUISingleton = this;
        } else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start () {
        gameManager = GMScript.gameMan;
        playerMan = playerManager.playerMan;
        tm = turnManagerScript.turnManager;
        gameManager.SetUIObject(this);

        GMScript.potBallEvent += GetTargets;
        GMScript.potBallEvent += UpdateScoreText;
        GMScript.potBallEvent += UpdateTargetText;
        
        GetTargets();
        UpdateTargetText();
        UpdateScoreText();
        UpdateTurnText();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScoreText();
        UpdateTurnText();
        UpdateTargetText();
        
	}

    public void UpdateTargetText()
    {
        if (targetText != null)
        {
            if ((playerManager.playerMan.GetPlayer1Target() == GMScript.Target.Black) && GMScript.gameMan.GetIsPlayer1())
            {
                targetText.text = "You must pot the black ball";
            } else if ((playerManager.playerMan.GetPlayer2Target() == GMScript.Target.Black) && !GMScript.gameMan.GetIsPlayer1())
            {
                targetText.text = "They must pot the black ball";
            }
            else
            {
                if ((turnManagerScript.turnManager.GetIsPlayer1Turn() && GMScript.gameMan.GetIsPlayer1()) || (!turnManagerScript.turnManager.GetIsPlayer1Turn() && !GMScript.gameMan.GetIsPlayer1()))
                {
                    targetText.text = "You must pot " + GetLocalPlayerTarget();
                } else
                {
                    targetText.text = "They must pot " + GetOtherPlayerTarget();
                }
            }
        }
    }

    private string GetLocalPlayerTarget()
    {
        if(GMScript.gameMan.GetIsPlayer1())
        {
            GMScript.Target targ = playerManager.playerMan.GetPlayer1Target();

            if(targ == GMScript.Target.Spots)
            {
                return "spots";
            } else if(targ == GMScript.Target.Stripes)
            {
                return "stripes";
            } else
            {
                return "either";
            }


        } else
        {
            GMScript.Target targ = playerManager.playerMan.GetPlayer2Target();

            if (targ == GMScript.Target.Spots)
            {
                return "spots";
            }
            else if (targ == GMScript.Target.Stripes)
            {
                return "stripes";
            }
            else
            {
                return "either";
            }
        }

    }

    string GetOtherPlayerTarget()
    {
        if (GMScript.gameMan.GetIsPlayer1())
        {
            GMScript.Target targ = playerManager.playerMan.GetPlayer1Target();

            if (targ == GMScript.Target.Spots)
            {
                return "stripes";
            }
            else if (targ == GMScript.Target.Stripes)
            {
                return "spots";
            }
            else
            {
                return "either";
            }


        }
        else
        {
            GMScript.Target targ = playerManager.playerMan.GetPlayer2Target();

            if (targ == GMScript.Target.Spots)
            {
                return "stripes";
            }
            else if (targ == GMScript.Target.Stripes)
            {
                return "spots";
            }
            else
            {
                return "either";
            }
        }
    }

    public void UpdateScoreText()
    {
        Vector2 ballsRemaining = turnManagerScript.turnManager.GetBallsRemaining();
        if(scoreText != null)
        {
            scoreText.text = "Spots - " + (int)ballsRemaining.x + " : " + (int)ballsRemaining.y + " - Stripes"; 
        }
    }

    void GetTargets()
    {
        GMScript.Target p1Target = playerMan.GetPlayer1Target();
        if (p1Target == GMScript.Target.None)
        {
            player1Target = "either";
            player2Target = "either";
        }
        else if (p1Target == GMScript.Target.Spots)
        {
            player1Target = "spots";
            player2Target = "stripes";
        }
        else
        {
            player1Target = "stripes";
            player2Target = "spots";
        }
    }

    public void EndGameUI(bool isWin)
    {
        if(isWin)
        {
            endGameText.text = "You win, congratulations!";
        } else
        {
            endGameText.text = "You lose! :(";
        }

        GMScript.gameMan.SetGameEnded(true);
        endGameText.gameObject.SetActive(true);
    }

    public void UpdateTurnText()
    {
        try
        {
            if ((turnManagerScript.turnManager.GetIsPlayer1Turn() && GMScript.gameMan.GetIsPlayer1()) || (!turnManagerScript.turnManager.GetIsPlayer1Turn() && !GMScript.gameMan.GetIsPlayer1()))
            {
                turnText.text = "It is your turn!";
            }
            else
            {
                turnText.text = "Waiting for other player to take turn";
            }
        }
        catch 
        {
            Debug.Log("Can't find game managers. Maybe they haven't been spawned yet?");
        }
    }

    public void EnableColourSelectText()
    {
        ingameTextObject.SetActive(false);
        colourSelectObject.SetActive(true);
    }

    public void DisableColourSelectText()
    {
        ingameTextObject.SetActive(true);
        colourSelectObject.SetActive(false);
    }



}
