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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerOneIsReady && playerTwoIsReady)
        {
            Application.LoadLevel(nextSceneName);
        }
        else
        {
            if (!playerOneIsReady && (InputManager.Devices[0].MenuWasPressed || Input.GetKeyDown(KeyCode.S)))
            {
                playerOneReadyText.text = "Player One is ready";
                playerOneIsReady = true;
            }
            if (!playerTwoIsReady && (InputManager.Devices[1].MenuWasPressed || Input.GetKeyDown(KeyCode.K)))
            {
                playerTwoReadyText.text = "Player Two is ready";
                playerTwoIsReady = true;
            }
        }
	}
}
