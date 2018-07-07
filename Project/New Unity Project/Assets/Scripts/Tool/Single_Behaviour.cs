using UnityEngine;
using System.Collections;

public class  Single_Behaviour<T> : MonoBehaviour where T : Single_Behaviour<T>
{
    protected static T  S_object;

    public static T Get_obj
    {
        get{
            return S_object;
        }
    }

	protected virtual void Awake()
	{
       // Debug.Log("11111");
		S_object = this as T;
	}
	
}
