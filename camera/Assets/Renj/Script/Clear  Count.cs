using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCount : MonoBehaviour
{
    int frameCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        frameCount++;
        if (frameCount >=2200 )
        {
            SceneManager.LoadScene("End Scene");
        }
    }
    // Update is called once per frame
 
}
