using UnityEngine;
using System.Collections;
using System;
public class CD_box
{
    float next_now;
    float now;
    float max;

  
    public bool IsOk
    {
        get
        {
            now = Time.time;
            float time_use = now - next_now;
            if (time_use >= max)
            {
                return true;
            }
            else
                return false;
        }
    }

    public float Countdown_ration
    {
        get
        {
            return Countdown / max;
        }
    }

    /// <summary>
    /// 倒计时
    /// </summary>
    public float Countdown
    {
        get
        {
            now = Time.time;
            float time_use = now - next_now;
            return max-time_use;
        }
    }

    /// <summary>
    /// 正计时
    /// </summary>
    public float lastTime
    {
        get
        {
            now = Time.time;
            float time_use = now - next_now;
            return time_use;
        }
    }



    public CD_box(float time)
    {
        now = Time.time;
        next_now = Time.time;
        max = time;
    }
   
    public void ReCd()
    {
        next_now = Time.time;
    }
}

