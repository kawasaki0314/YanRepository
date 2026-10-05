using UnityEngine;

public class sun : MonoBehaviour
{

    float frameRate = 0f; // Set the desired frame rate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameRate++;
        transform.Rotate(Vector3.up, (frameRate *0.01f) * Time.deltaTime);
    }
}
