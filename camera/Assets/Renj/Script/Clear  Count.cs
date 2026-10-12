using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCount : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 90f;
    int frameCount = 0;
    const int time = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        frameCount++;
        
        if (timeRemaining >0)
        {
            timeRemaining -= Time.deltaTime;
            int sec = Mathf.FloorToInt(timeRemaining % 60f);

        }
        else
        {
            SceneManager.LoadScene("End Scene");

        }
    }
    // Update is called once per frame
 
}
