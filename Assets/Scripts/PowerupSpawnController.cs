using UnityEngine;
using System.Collections;

public class PowerupSpawnController : MonoBehaviour {
    public GameObject[] powerups;
    public float minX = -1.4f;
    public float maxX = 1.4f;
    public float minY = -0.7f;
    public float maxY = 0.7f;

    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 10.0f;

    private float currentSpawnTime = 1.0f;

	// Use this for initialization
	void Start () {
        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        StartCoroutine("WaitForSpawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPowerup()
    {
        int powerupNumber = Random.Range(0, powerups.Length);
        float targetX = Random.Range(minX, maxY);
        float targetY = Random.Range(minY, maxY);
        Instantiate(powerups[powerupNumber], new Vector3(targetX, targetY, 0), Quaternion.identity);
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(currentSpawnTime);
        SpawnPowerup();
        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return StartCoroutine("WaitForSpawn");
    }
}
