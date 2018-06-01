using UnityEngine;

public class Time_Contr : MonoBehaviour
{
    public static Time_Contr ciop;

    public delegate void HourComing(int hour);
    public static event HourComing HourCame;
    public delegate void DayComing(int day);
    public static event DayComing DayCame;
    public delegate void MonthComing(int month);
    public static event HourComing MonthCame;
    public delegate void YearComing(int year);
    public static event HourComing YearCame;

    public enum DAYS { MONDAY = 1, TUESDAY = 2, WEDNESDAY = 3, THURSDAY = 4, FRIDAY = 5, SATURDAY = 6, SUNDAY = 7 }
    public DAYS Day
    {
        get
        {
            return (DAYS)day_time;
        }
    }

    public enum MONTHS { JANUARY = 1, FEBRUARY = 2, MARCH = 3, APRIL = 4, MAY = 5, JUNE = 6, JULY = 7, AUGUST = 8, SEPTEMBER = 9, OCTOBER = 10, NOVEMBER = 11, DECEMBER = 12 }
    public MONTHS Month
    {
        get
        {
            return (MONTHS)month_time;
        }
    }

    int NumberOfDays
    {
        get
        {
            MONTHS month = Month;

            if (month == MONTHS.APRIL || month == MONTHS.JUNE ||
                month == MONTHS.SEPTEMBER || month == MONTHS.NOVEMBER)
            {
                return 30;
            }
            else if (month == MONTHS.FEBRUARY)
            {
                if (year_time % 4 == 0)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            else
            {
                return 31;
            }
        }
    }

    public int year_time = 1814;
    public int month_time = 1;
    public int day_time = 0;
    public int hour_time = 0;
    public int minute_time = 0;
    public int second_time = 0;
    public float milisecond_time = 0;

    [SerializeField]
    float timeSpeed = 1;

    void Awake()
    {
        if (!ciop)
        {
            ciop = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        CountTime();
    }

    void CountTime()
    {
        milisecond_time += timeSpeed * Time.fixedDeltaTime;

        if (milisecond_time >= 1)
        {
            milisecond_time -= 1;
            second_time++;

            if (second_time >= 60)
            {
                second_time -= 60;
                minute_time++;

                if (minute_time >= 60)
                {
                    minute_time -= 60;
                    hour_time++;

                    if (HourCame != null) { HourCame(hour_time); }

                    if (hour_time > 24)
                    {
                        hour_time -= 24;
                        day_time++;

                        if (DayCame != null) { DayCame(day_time); }

                        if (day_time > NumberOfDays)
                        {
                            day_time -= NumberOfDays;
                            month_time++;

                            if (MonthCame != null) { MonthCame(month_time); }

                            if (month_time > 12)
                            {
                                month_time -= 12;
                                year_time++;

                                if (YearCame != null) { YearCame(year_time); }
                            }
                        }
                    }
                }
            }
        }
    }
}