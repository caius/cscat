using System;
using System.IO;

namespace cscat
{
  class Program
  {
    static int Main(string[] args)
    {
      int exitCode = 0;

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
              Console.Write(line);
            }
          }
          catch (Exception)
          {
            Console.WriteLine("cat: {0:G}: No such file or directory", path);
            exitCode = 1;
          }
        }
      }

      return exitCode;
    }

    static void CopyStandardInputToOutput() {
      Console.OpenStandardInput().CopyTo(Console.OpenStandardOutput());
    }
  }
}
