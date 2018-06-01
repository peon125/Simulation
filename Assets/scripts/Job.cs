using System;
using UnityEngine;

public delegate void StopWorking();
public delegate void StartWorking();

[Serializable]
public class Job
{
    public event StopWorking StopWork;
    public event StartWorking StartWork;

    public Person person;

    [SerializeField]
    Workplace place;
    [SerializeField]
    Time_Contr.DAYS[] workingDays;
    [SerializeField]
    int[] workSince = { 8 };
    [SerializeField]
    int[] workTo = { 16 };
    [SerializeField]
    float salary;

    //przekazywać Person w atrybucie?
    protected void SubscribeEvents()
    {
        Time_Contr.HourCame += Time_Contr_HourCame;
    }

    void Time_Contr_HourCame(int hour)
    {
        foreach (int w in workSince)
        {
            if (hour == w)
            {
                if (StartWork != null) { StartWork(); }
            }
        }

        foreach (int w in workTo)
        {
            if (hour == w)
            {
                if (StopWork != null) { StopWork(); }
            }
        }
    }
}