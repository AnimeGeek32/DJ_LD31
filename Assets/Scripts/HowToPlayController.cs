using UnityEngine;
using System.Collections;
using InControl;

public class HowToPlayController : MonoBehaviour {
    public string nextSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Application.LoadLevel(nextSceneName);
        }
	}
}
