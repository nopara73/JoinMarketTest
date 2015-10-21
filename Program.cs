/*
 * Add to post build event: 
 * echo d | xcopy "$(ProjectDir)Lib" "$(TargetDir)StdLib" /Y/E/I/D
 * echo d | xcopy "$(ProjectDir)PostBuildEventFiles\JoinMarketForHiddenWallet" "$(TargetDir)" /Y/E/I/D
 * echo d | xcopy "$(ProjectDir)PostBuildEventFiles\libsodium.dll" "$(TargetDir)" /Y/E/I/D
 */

using System;
using JoinMarketTest.JoinMarket;

namespace JoinMarketTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Here I start...");

            //Console.WriteLine(Wallet.Generate());
            //Console.WriteLine(Wallet.Sweep("14ChPPM8rPYJeHnw6kMVUDnNNKx1KnjYW4"));
            Wallet.EncWrapper();

            Console.WriteLine("Here I end...");
            Console.ReadLine();
        }
    }
}
