using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class U_Array_String
{
    public static string ArrayToString<T>(T[,] temple)
    {
        string out_s = "";
        for (int y = temple.GetLength(1)-1; y >=0 ; y--)
        {
            string ous_one = "";
            for (int x = 0; x < temple.GetLength(0); x++)
            {
                ous_one += temple[x, y].ToString();
            }
            out_s += (ous_one + "\n");
        }
        return out_s;
    }

    public static string ArrayToString<T>(T[] temple)
    {
        string out_s = "";
        foreach (var item in temple)
        {
            out_s += item.ToString();
        }
        return out_s;
    }
}

