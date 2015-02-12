using System;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            Console.WriteLine("Hello World" + GetType().AssemblyQualifiedName);
            Console.ReadLine();
        }
    }
}
