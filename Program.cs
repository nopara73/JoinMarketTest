/*
 * Add to post build event: 
 * echo d | xcopy "$(ProjectDir)PostBuildEventFiles\JoinMarket" "$(TargetDir)JoinMarket" /Y/E/I/D
 * echo d | xcopy "$(ProjectDir)PostBuildEventFiles\libsodium.dll" "$(TargetDir)JoinMarket" /Y/E/I/D
 * echo d | xcopy "$(ProjectDir)Lib" "$(TargetDir)Lib" /Y/E/I/D
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

            Console.WriteLine(w.Generate());

            Console.ReadLine();
        }
    }
}
