using UnityEngine;
using System.Collections;

public class SpermController : MonoBehaviour {
    public float speed = 3.0f;

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
        if (collision.collider.tag == "PlayerOne" || collision.collider.tag == "PlayerTwo")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180 + transform.rotation.eulerAngles.z);
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
            Debug.Log("Player One Wins!");
            Respawn();
        }
        else if (collider.tag == "P2Goal")
        {
            Debug.Log("Player Two Wins!");
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360.0f));
    }
}
