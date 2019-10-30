using System;
using System.IO;

namespace cscat
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        CopyStandardInputToOutput();
      }

      foreach (var path in args)
      {
        if (path == "-")
        {
          CopyStandardInputToOutput();
        }
        else
        {
          try
          {
            using (StreamReader sr = new StreamReader(path))
            {
              String line = sr.ReadToEnd();
              Console.WriteLine(line);
            }
          }
          catch (Exception)
          {
            Console.WriteLine("cat: {0:G}: No such file or directory", path);
          }
        }
      }
    }

    static void CopyStandardInputToOutput() {
      Console.OpenStandardInput().CopyTo(Console.OpenStandardOutput());
    }
  }
}
