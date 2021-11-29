using System;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
        }
        static void Setup()
        {
            RestService rest = new RestService("http://localhost:21980");
            MenuClass menu = new MenuClass();

            menu.clear += Clear;
            menu.input += Input;
            menu.write += Write;
            menu.writeline += WriteLine;

            menu.Start(rest);
        }
        static void Clear()
        {
            Console.Clear();
        }
        static string Input()
        {
            return Console.ReadLine();
        }
        static void Write(string s)
        {
            Console.Write(s);
        }
        static void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

    }
}
