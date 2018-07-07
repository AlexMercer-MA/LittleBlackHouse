using UnityEngine;
using System.Collections;

public class Time_Box
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



	public Time_Box(float time)
	{
		now = Time.time;
		next_now = Time.time;
		max = time;
	}

	public void ReCd()
	{
		next_now = Time.time;
	}

	public float now_time()
	{
		now = Time.time;
		return now - next_now;
	}

	public float progress()
	{
		now = Time.time - next_now;
		return now / max;
	}
}

