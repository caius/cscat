using System;
using System.IO;

namespace cscat
{
  class Program
  {
    static void Main(string[] args)
    {
      bool exit_with_error = false;

      // If there are no arguments, read from stdin
      // If there are arguments:
      //   - Read from stdin for "-"
      //   - Check if argument string exists on filesystem as a file
      //   - If it does, copy to stdout
      //   - If not, output error to stderr & set exit value

      // When there are no arguments, inject "-" to trigger reading from stdin
      if (args.Length == 0)
      {
        // https://stackoverflow.com/a/1440325/50708
        Array.Resize(ref args, args.Length + 1);
        args[args.Length - 1] = "-";
      }

      // Run through arguments
      foreach (string filename in args)
      {
        if (filename == "-")
        {
          Console.OpenStandardInput().CopyTo(Console.OpenStandardOutput());
        }
        else
        {
          // Check file exists before we attempt to read it
          if (!File.Exists(filename))
          {
            Console.Error.WriteLine($"cat: {filename}: No such file or directory");
            exit_with_error = true;
          }
          else
          {
            // Copy file contents to stdout
            using (StreamReader sr = new StreamReader(filename))
            {
              string line;
              while ((line = sr.ReadLine()) != null)
              {
                Console.WriteLine(line);
              }
            }
          }
        }
      }

      // If we errored reading paths at any point we need to exit(1)
      if (exit_with_error == true)
      {
        Environment.ExitCode = 1;
      }
    }
  }
}
