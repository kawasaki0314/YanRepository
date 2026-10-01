using UnityEngine;

public class Enemy_1_MoveCtrl : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
