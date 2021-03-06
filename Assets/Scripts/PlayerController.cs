﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;

public class PlayerController : MonoBehaviour {
    public GameObject playerOnePaddle;
    public GameObject playerTwoPaddle;
    public Text playerOneScoreText;
    public Text playerTwoScoreText;

    public float playerOneSpeed = 30.0f;
    public float playerTwoSpeed = 30.0f;

    private InputDevice playerOneDevice;
    private InputDevice playerTwoDevice;
    private bool playerOneLeftDown = false;
    private bool playerOneRightDown = false;
    private bool playerTwoLeftDown = false;
    private bool playerTwoRightDown = false;
    private int playerOneScore;
    private int playerTwoScore;

	// Use this for initialization
	void Start () {
        if (InputManager.Devices.Count >= 1)
        {
            if (InputManager.Devices.Count == 1)
            {
                playerOneDevice = InputManager.ActiveDevice;
            }
            else
            {
                playerOneDevice = InputManager.Devices[0];
            }
        }
        if (InputManager.Devices.Count >= 2)
        {
            playerTwoDevice = InputManager.Devices[1];
        }
        playerOneScore = 0;
        playerTwoScore = 0;
        playerOneScoreText.text = "0";
        playerTwoScoreText.text = "0";

        playerOneLeftDown = false;
        playerOneRightDown = false;
        playerTwoLeftDown = false;
        playerTwoRightDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        // Obtain gamepads' controls
        Vector2 playerOneMovement = Vector2.zero;
        Vector2 playerTwoMovement = Vector2.zero;

        if (playerOneDevice != null)
        {
            playerOneMovement.x = playerOneDevice.LeftStickX.Value * playerOneSpeed * Time.deltaTime;
        }
        if (playerTwoDevice != null)
        {
            playerTwoMovement.x = playerTwoDevice.LeftStickX.Value * playerTwoSpeed * Time.deltaTime;
        }

        // Key Ups
        // Player One
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerOneLeftDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerOneRightDown = false;
        }
        // Player Two
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerTwoLeftDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            playerTwoRightDown = false;
        }

        // Key Downs
        // Player One
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerOneLeftDown = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerOneRightDown = true;
            
        }
        // Player Two
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerTwoLeftDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            playerTwoRightDown = true;
        }

        // If there are keyboard inputs, then update movements
        if (playerOneLeftDown)
        {
            playerOneMovement.x = -playerOneSpeed * Time.deltaTime;
        }
        else if (playerOneRightDown)
        {
            playerOneMovement.x = playerOneSpeed * Time.deltaTime;
        }
        if (playerTwoLeftDown)
        {
            playerTwoMovement.x = -playerTwoSpeed * Time.deltaTime;
        }
        else if (playerTwoRightDown)
        {
            playerTwoMovement.x = playerTwoSpeed * Time.deltaTime;
        }

        playerOnePaddle.rigidbody2D.velocity = playerOneMovement;
        playerTwoPaddle.rigidbody2D.velocity = playerTwoMovement;
	}

    public void AddScorePlayerOne(int newValue)
    {
        playerOneScore += newValue;
    }

    public void AddScorePlayerTwo(int newValue)
    {
        playerTwoScore += newValue;
    }

    public void UpdateScore()
    {
        playerOneScoreText.text = playerOneScore.ToString();
        playerTwoScoreText.text = playerTwoScore.ToString();
    }
}
