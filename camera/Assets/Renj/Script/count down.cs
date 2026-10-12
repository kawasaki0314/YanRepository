using TMPro;
using UnityEngine;

public class countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerCD;
    [SerializeField] private float timeR = 90f;
    private bool isTimerRun = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeR -= Time.deltaTime;

        
        int sec = Mathf.FloorToInt(timeR % 90f);


        timerCD.text = $"Day 1 Ends in : {sec:00}";

    }
}
