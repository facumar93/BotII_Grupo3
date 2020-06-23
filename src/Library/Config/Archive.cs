using System;
using System.Collections.Generic;
using System.IO;
public class Archive
{
    public static List<string> Read(string path)
    {
        List<string> response=new List<string>();
        using(StreamReader streamReader=new StreamReader(path))
        {
            	String linea=streamReader.ReadLine();
                while(linea!=null)
                {
                    response.Add(linea);
                    linea=streamReader.ReadLine();
                }
                return response;

        }
    }
}