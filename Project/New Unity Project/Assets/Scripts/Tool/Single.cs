using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Single<T>  where T:new()
{
    private static T obj;
    public static T Get
    {
        get
        {
            if(obj==null)
            {
                obj = new T();
            }
            return obj;
        }
    }
}

