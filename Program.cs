/*
 * Add to post build event: 
 * xcopy "$(ProjectDir)PostBuildEventFiles\JoinMarket" "$(TargetDir)JoinMarket" /Y/E/I/D
 * xcopy "$(ProjectDir)PostBuildEventFiles\Python27" "$(TargetDir)Python27" /Y/E/I/D
 * xcopy "$(ProjectDir)PostBuildEventFiles\libsodium.dll" "$(TargetDir)JoinMarket" /Y/E/I/D
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
