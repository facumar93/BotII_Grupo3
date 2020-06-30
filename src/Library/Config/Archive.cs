using System;
using System.Collections.Generic;
using System.IO;
public class Archive
{
    public static List<string> Read(string path)
    {
        List<string> listGenerated = new List<string>();
        
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                String line = sr.ReadLine();
                while (line != null)
                {
                    listGenerated.Add(line);
                    line = sr.ReadLine();
                }
                return listGenerated;
            }
        }
        catch (FileNotFoundException e)
        {
            throw new FileNotFoundException("No se encontró el archivo", e);
        }

        catch (IOException e)
        {
           throw new IOException("No se pudo abrir el archivo", e); 
        }
    }
}