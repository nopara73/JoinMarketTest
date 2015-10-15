/*
 * Add to post build event: 
 * xcopy "$(ProjectDir)PostBuildEventFiles" "$(TargetDir)" /Y/E/I
 */

using System;
using JoinMarketTest.JoinMarket;

namespace JoinMarketTest
{
    class Program
    {
        static void Main()
        {
            var w = new Wallet();
            Console.Write(w.Generate());

            Console.ReadLine();
        }
    }
}
