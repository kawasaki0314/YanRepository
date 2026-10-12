using System;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    int dtimer = 0;
    [SerializeField] private TextMeshProUGUI timerD;
    private float Etimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       dtimer++;
        Etimer += Time.deltaTime;

        int min = Mathf. FloorToInt(Etimer / 60f);
        int sec = Mathf. FloorToInt(Etimer %60f);


        timerD.text = $"{min:00}:{sec:00}";



    }
}
