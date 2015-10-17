using System;
using System.Diagnostics;
using System.IO;

namespace JoinMarketTest.JoinMarket
{
    internal class Wallet
    {
        private static readonly string PythonPath = Path.Combine(Environment.CurrentDirectory, @"Python27/python.exe");
        private static readonly string WalletToolPath = Path.Combine(Environment.CurrentDirectory, @"JoinMarket/wallet-tool.py");

        private readonly ProcessStartInfo _defProcInfo = new ProcessStartInfo()
        {
            FileName = PythonPath,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardInput = true
        };

        /// <summary>
        /// Generates a wallet.json without password.
        /// </summary>
        /// <returns>JoinMarket console response</returns>
        internal string Generate()
        {
            var start = _defProcInfo;
            start.Arguments = string.Format("{0} generate", WalletToolPath);

            using (var process = Process.Start(start))
            {
                if (process == null) return String.Empty;
                using (var output = process.StandardOutput)
                {
                    using (var input = process.StandardInput)
                    {
                        // Asks for password.
                        var result = output.ReadToEnd();
                        input.WriteLine("password");
                        // Asks for password confirmation.
                        result += output.ReadToEnd();
                        input.WriteLine("password");
                        // Asks for wallet file name.
                        result += output.ReadToEnd();
                        input.WriteLine("wallet.json");
                        result += output.ReadToEnd();

                        return result;
                    }
                }
            }
        }
    }
}