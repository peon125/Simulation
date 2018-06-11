using System;
using System.Linq;
using UnityEngine;

public delegate void StopWorking();
public delegate void StartWorking();

[Serializable]
public class Job
{
    public event StopWorking StopWork;
    public event StartWorking StartWork;
    
    public Vector3 Position
    {
        get
        {
            return workplace.transform.position;
        }

        set
        {
            Debug.LogError("ZMIENIONO POZYCJĘ DOMU");
            workplace.transform.position = value;
        }
    }

    public Person person;
    public Workplace workplace;

    [SerializeField]
    Time_Ctrlr.DAYS[] workingDays;
    [SerializeField]
    int[] workSince = { 8 };
    [SerializeField]
    int[] workTo = { 16 };
    [SerializeField]
    float salary;

    //przekazywać Person w atrybucie?
    public void SubscribeEvents()
    {
        Time_Ctrlr.HourCame += Time_Contr_HourCame;
    }

    void Time_Contr_HourCame(int hour)
    {
        Debug.Log(0);
        if (workingDays.Contains((Time_Ctrlr.DAYS)Time_Ctrlr.ciop.day_time))
        {
            foreach (int w in workSince)
            {
                if (hour == w)
                {
                    if (StartWork != null) { Debug.Log(1); StartWork(); }
                }
            }
        }

        if (workingDays.Contains((Time_Ctrlr.DAYS)Time_Ctrlr.ciop.day_time))
        {
            foreach (int w in workTo)
            {
                if (hour == w)
                {
                    if (StopWork != null) { StopWork(); }
                }
            }
        }
    }
}