using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
public class U_Save
{
    public static void U_Save_2Array_Int(String name,int[,] date)
    {
        String path = Application.streamingAssetsPath + @"/MapReady/" + name+".txt";
        String out_s="";
        for (int y = date.GetLength(1) - 1; y >= 0; y--)
        {
            String line = "";
            for (int x = 0; x < date.GetLength(0); x++)
            {
                line+=(date[x,y])+",";
            }
            out_s += line += "\n";
        }
        Console.WriteLine(out_s);
        File.WriteAllText(path,out_s);
        
    }

    public static int[,] U_Load_2Array_Int(String name)
    {

        String path = Application.streamingAssetsPath + @"/MapReady/" + name + ".txt";
        Debug.Log(path);
        int[,] temple = null;
        if(File.Exists(path))
        {
            string[] contante = File.ReadAllLines(path);
            for (int y = 0; y< contante.Length; y++)
            {
                String[] lings = contante[y].Split(',');
                for (int x = 0;x< lings.Length-1; x++)
                {
                    if(temple==null)
                    {
                        temple = new int[lings.Length - 1, contante.Length];
                    }
                    try
                    {
                        temple[x, contante.Length - 1 - y] = Convert.ToInt32(lings[x]);
                    }
                    catch
                    {
                        throw new Exception(name + "格式有问题或者不存在");
                    }
                    
                }
            }
        }

        return temple;
    }

    public static string[] Get_names(String name)
    {
        List<string> temple =new List<string>();
        String path = Application.streamingAssetsPath + @"/"+ name ;
        DirectoryInfo di = new DirectoryInfo(path);
        FileInfo[] fis = di.GetFiles();
        for (int i = 0; i < fis.Length; i++)
        {
            string temple_name = fis[i].Name;
            string[] temple_names = temple_name.Split('.');
            string end_name = temple_names[temple_names.Length - 1];
            
            if (end_name=="txt")
            {
                temple.Add(temple_names[0]);
            }
           
        }
        return temple.ToArray();
    }

    public static int Get_Int(String name)
    {
        String path = Application.streamingAssetsPath + @"/" + name;

        string str1 = File.ReadAllText(path);
        int result = Convert.ToInt32(str1);
        return result;
    }
}

