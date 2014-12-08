using UnityEngine;
using System.Collections;

public class SpermController : MonoBehaviour {
    public float speed = 60.0f;
    public float defaultSpeed = 60.0f;
    public PlayerController playerController;

    public AudioClip wallHitSound;
    public AudioClip paddleHitSound;
    public AudioClip goalSound;
    public AudioClip powerupSound;

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = transform.up * speed * Time.deltaTime;
	}

    // Used to calculate the direction of the sperm after collision with the paddles
    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (paddlePos.x - ballPos.x) / paddleWidth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerOne")
        {
            Debug.Log("Hit player 1.");
            audio.PlayOneShot(paddleHitSound);
            /*
            if (collision.rigidbody.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 135.0f * (Mathf.Abs(collision.rigidbody.velocity.x) / (playerController.playerOneSpeed * Time.deltaTime)));
            }
            else if (collision.rigidbody.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -135.0f * (Mathf.Abs(collision.rigidbody.velocity.x) / (playerController.playerOneSpeed * Time.deltaTime)));
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180.0f);
            }
             */
            float hitX = HitFactor(new Vector2(transform.position.x, transform.position.y), new Vector2(collision.transform.position.x, collision.transform.position.y), ((BoxCollider2D)collision.collider).size.x);
            transform.rotation = Quaternion.Euler(0, 0, 180 - (45.0f * hitX));
        }
        else if (collision.collider.tag == "PlayerTwo")
        {
            Debug.Log("Hit player 2.");
            audio.PlayOneShot(paddleHitSound);
            /*
            if (collision.rigidbody.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45.0f * (Mathf.Abs(collision.rigidbody.velocity.x) / (playerController.playerTwoSpeed * Time.deltaTime)));
            }
            else if (collision.rigidbody.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45.0f * (Mathf.Abs(collision.rigidbody.velocity.x) / (playerController.playerTwoSpeed * Time.deltaTime)));
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0.0f);
            }
             */
            float hitX = HitFactor(new Vector2(transform.position.x, transform.position.y), new Vector2(collision.transform.position.x, collision.transform.position.y), ((BoxCollider2D)collision.collider).size.x);
            transform.rotation = Quaternion.Euler(0, 0, 45.0f * hitX);
        }
        else
        {
            audio.PlayOneShot(wallHitSound);
            transform.rotation = Quaternion.Euler(0, 0, -transform.rotation.eulerAngles.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "P1Goal")
        {
            Debug.Log("Player Two Wins!");
            audio.PlayOneShot(goalSound);
            playerController.AddScorePlayerTwo(1);
            playerController.UpdateScore();
            Respawn();
        }
        else if (collider.tag == "P2Goal")
        {
            Debug.Log("Player One Wins!");
            audio.PlayOneShot(goalSound);
            playerController.AddScorePlayerOne(1);
            playerController.UpdateScore();
            Respawn();
        }
        else if (collider.tag == "SpeedUp")
        {
            audio.PlayOneShot(powerupSound);
            speed += 10.0f;
            Destroy(collider.gameObject);
        }
        else if (collider.tag == "SpeedDown")
        {
            audio.PlayOneShot(powerupSound);
            speed -= 10.0f;
            Destroy(collider.gameObject);
        }
    }

    public void Respawn()
    {
        speed = defaultSpeed;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
    }
}
