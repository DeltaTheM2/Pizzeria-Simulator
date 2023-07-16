using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Day;
    public float timeLeft, timeOfDay;
    public bool isWorkHour;
    public Player player;
    public float dayIncome, dayRevenue;


    private void Start()
    {
        Day = 1;
        timeLeft = 8f;
        isWorkHour = true;
    }
    private void Update()
    {
        if (isWorkHour)
        {
            RunBusiness();
        }
        else
        {
            Close();
        }
    }
    public void RunBusiness()
    {
        if (timeOfDay >= 1)
        {
            timeOfDay = 0;
            Day++;
            isWorkHour = false;
            Close();

        }
        isWorkHour = true;
    }
    public void Close()
    {
        isWorkHour = false;
        player.currentMoney += dayRevenue;
    }
}
