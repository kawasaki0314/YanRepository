using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCount : MonoBehaviour
{
    
   
    [SerializeField] private float timeRemaining = 90f;
    [SerializeField] private float timeRemaining2 = 90f;
    [SerializeField] private float timeRemaining3 = 90f;
    bool isDay1 = false;
    bool isDay2 = false;
    bool isDay3 = false;

    int frameCount = 0;
    const int time = 60;
    [SerializeField] private TextMeshProUGUI CountDown;
    [SerializeField] private TextMeshProUGUI DAY;

    [SerializeField] private GameObject sun;
   // [SerializeField] private float timeR = 90f;
    private bool isTimerRun = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDay1 = true;
    }

    private void Update()
    {
        frameCount++;
        if (isDay1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int sec = Mathf.FloorToInt(timeRemaining % 90f);
                CountDown.text = $"Day 1 Ends in : {sec:00}";

                //if(sun.transform.)
            }
            else
            {
                isDay1 = false;
                isDay2 = true;
            }
        }
       

      
        
        //if (timeRemaining > 0)
        //{
        //    timeRemaining -= Time.deltaTime;
        //    int dsec = Mathf.FloorToInt(timeRemaining % 60f);

        //}
        //else
        //{

        //    isDay1 = false;
        //    isDay2 = true;

        //    //   SceneManager.LoadScene("End Scene");

        //}
        if (isDay2)
        {
            if (timeRemaining2 > 0)
            {
                timeRemaining2 -= Time.deltaTime;
                int dsec2 = Mathf.FloorToInt(timeRemaining2 % 90f);

                CountDown.text = $"Day 2 Ends in : {dsec2:00}";
                DAY.text = $"DAY 2 / 3";


            }
            else
            {

                //timeR -= Time.deltaTime;


                //int sec2 = Mathf.FloorToInt(timeR % 90f);


                
                isDay2 = false;
                isDay3 = true;

            }
        }
        if (isDay3)
        {
            if (timeRemaining3 > 0)
            {
                timeRemaining3 -= Time.deltaTime;
                int dsec3 = Mathf.FloorToInt(timeRemaining3 % 90f);
                CountDown.text = $"Day 3 Ends in : {dsec3:00}";
                DAY.text = $"DAY 3 / 3";

            }
            else
            {
                //timeR -= Time.deltaTime;


                //int sec3 = Mathf.FloorToInt(timeR % 90f);


               
                SceneManager.LoadScene("End Scene");
            }
        }

        // Update is called once per frame
    }

}
