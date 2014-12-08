using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;

public class MainMenuController : MonoBehaviour {
    public string nextSceneName;
    public Text playerOneReadyText;
    public Text playerTwoReadyText;

    public bool playerOneIsReady = false;
    public bool playerTwoIsReady = false;

    private InputDevice playerOneDevice;
    private InputDevice playerTwoDevice;

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
	}
	
	// Update is called once per frame
	void Update () {
        if (playerOneIsReady && playerTwoIsReady)
        {
            Application.LoadLevel(nextSceneName);
        }
        else
        {
            if (!playerOneIsReady && ((playerOneDevice != null && playerOneDevice.MenuWasPressed) || Input.GetKeyDown(KeyCode.S)))
            {
                playerOneReadyText.text = "Player One is ready";
                playerOneIsReady = true;
            }
            if (!playerTwoIsReady && ((playerTwoDevice != null && playerTwoDevice.MenuWasPressed) || Input.GetKeyDown(KeyCode.K)))
            {
                playerTwoReadyText.text = "Player Two is ready";
                playerTwoIsReady = true;
            }
        }
	}
}
