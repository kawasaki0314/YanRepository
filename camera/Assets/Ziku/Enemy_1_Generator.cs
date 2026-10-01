using UnityEngine;

public class Enemy_1_Generator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDistance = 10f;

    [SerializeField] private float spawnInterval = 60f;

    private float spawnTimer = 0f;

    private Transform player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0f)
        {
            spawnTimer = spawnInterval;
        }
        else
        {
            return;
        }

        if (player == null)
        {
            return;
        }

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector3 direction = new Vector3(
            randomDirection.x,
            0f,
            randomDirection.y
        );

        Vector3 spawnPosition =
            player.position + direction * spawnDistance;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
