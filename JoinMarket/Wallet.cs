using System;
using System.Diagnostics;
using System.IO;

namespace JoinMarketTest.JoinMarket
{
    internal class Wallet
    {
        private readonly string _pythonPath = Path.Combine(Environment.CurrentDirectory, @"Python27/python.exe");
        private readonly string _walletToolPath = Path.Combine(Environment.CurrentDirectory, @"JoinMarket/wallet-tool.py");

        /// <summary>
        /// Generates a wallet.json without password.
        /// </summary>
        /// <returns>JoinMarket console response</returns>
        internal string Generate()
        {
            return RunPython(_walletToolPath, "generate");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        /// <returns>Console response.</returns>
        private string RunPython(string cmd, string args)
        {
            var start = new ProcessStartInfo
            {
                FileName = _pythonPath,
                Arguments = string.Format("{0} {1}", cmd, args),
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            using (var process = Process.Start(start))
            {
                if (process == null) return String.Empty;
                using (var reader = process.StandardOutput)
                {
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}