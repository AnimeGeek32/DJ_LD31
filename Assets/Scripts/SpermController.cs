using UnityEngine;
using System.Collections;

public class SpermController : MonoBehaviour {
    public float speed = 3.0f;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = transform.up * speed;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerOne")
        {
            Debug.Log("Hit player 1.");
            while (transform.rotation.eulerAngles.z < 90 && transform.rotation.eulerAngles.z > -90)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            }
        }
        else if (collision.collider.tag == "PlayerTwo")
        {
            Debug.Log("Hit player 2.");
            while ((transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z <= 180) || (transform.rotation.eulerAngles.z < -90 && transform.rotation.eulerAngles.z >= -180))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -transform.rotation.eulerAngles.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "P1Goal")
        {
            Debug.Log("Player Two Wins!");
            playerController.AddScorePlayerTwo(1);
            playerController.UpdateScore();
            Respawn();
        }
        else if (collider.tag == "P2Goal")
        {
            Debug.Log("Player One Wins!");
            playerController.AddScorePlayerOne(1);
            playerController.UpdateScore();
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
    }
}
