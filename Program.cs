using System;

namespace cscat
{
    class Program
    {
        static void Main(string[] args)
        {
          // Run through the arguments and check
          foreach (string a in args) {
            Console.WriteLine(a);
          }

          Console.WriteLine("Hello World!");
        }
    }
}
