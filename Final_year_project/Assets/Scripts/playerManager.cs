﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {


    public static playerManager playerMan;

    GMScript.Target player1Target;
    GMScript.Target player2Target;
    int player1Score = 0;
    int player2Score = 0;

    private void Awake()
    {
        if(playerMan == null)
        {
            playerMan = this;
        } else
        {
            Destroy(this);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlayer1Target(GMScript.Target newTarget)
    {
        player1Target = newTarget;
    }

    public void SetPlayer2Target(GMScript.Target newTarget)
    {
        player2Target = newTarget;
    }

    public GMScript.Target GetPlayer1Target()
    {
        return player1Target;
    }

    public void SetPlayer1Score(int score)
    {
        player1Score = score;
    }

    public int GetPlayer1Score()
    {
        return player1Score;
    }

    public void SetPlayer2Score(int score)
    {
        player2Score = score;
    }

    public int GetPlayer2Score()
    {
        return player2Score;
    }

    public void AddPlayer1Score(int score)
    {
        player1Score += score;
    }

    public void AddPlayer2Score(int score)
    {
        player2Score += score;
    }

}