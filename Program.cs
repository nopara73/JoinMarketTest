/*
 * Add to post build event: 
 * xcopy "$(ProjectDir)PostBuildEventFiles\JoinMarket" "$(TargetDir)JoinMarket" /Y/E/I
 * xcopy "$(ProjectDir)PostBuildEventFiles\Python27" "$(TargetDir)Python27" /Y/E/I
 * xcopy "$(ProjectDir)PostBuildEventFiles\libsodium.dll" "$(TargetDir)JoinMarket" /Y/E/I
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
