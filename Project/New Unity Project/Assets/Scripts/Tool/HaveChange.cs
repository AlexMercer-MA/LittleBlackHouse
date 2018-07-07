using System.Collections;
using System;
public class HaveChange<T> where T:ICloneable
{
    T now_ed;
    T now;
    public Action Change_Handle;


    public HaveChange(T now)
    {
        this.now = now;
        now_ed = (T)now.Clone();
    }
    public bool IsChange
    {
        get
        {
            if(!now_ed.Equals(now) )
            {
                Change_Handle();
                now_ed = (T)now.Clone();           
                return true;
            }
            return false;
        }
    }

}

