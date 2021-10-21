using System;
using DL;
using Models;
using StoreBL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuFactory.GetMenu("login").Start();
        }
    }
}
