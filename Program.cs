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
                Console.WriteLine("Error: no args");
                return;
            }

            foreach (var path in args)
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
}
