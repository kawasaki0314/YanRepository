using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCount : MonoBehaviour
{
    int frameCount = 0;
    const int time = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        frameCount++;
        if (frameCount >= time*2000)
        {
            SceneManager.LoadScene("End Scene");
        }
    }
    // Update is called once per frame
 
}
