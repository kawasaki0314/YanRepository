using UnityEngine;

public class sun : MonoBehaviour
{
    public ClearCount clearCount;

    float drota = 90f; // Set the desired frame rate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 360f / drota;
        transform.Rotate(Vector3.right, speed * Time.deltaTime,Space.World);
    }
}
