using System;
using System.IO;
using IronPython.Hosting;
using System.Collections.Generic;

namespace JoinMarketTest.JoinMarket
{
    internal class Wallet
    {
        private static readonly string WalletToolPath = Path.Combine(Environment.CurrentDirectory, @"JoinMarket/wallet-tool.py");

        /// <summary>
        /// Generates a wallet.json without password.
        /// </summary>
        /// <returns>JoinMarket console response</returns>
        internal string Generate()
        {
            IDictionary<string, object> options = new Dictionary<string, object>();
            options["Arguments"] = new[] { "method", "generate" };

            var pythonEngine = Python.CreateEngine(options);

            var pythonScript = pythonEngine.CreateScriptSourceFromFile(WalletToolPath);

            pythonScript.Execute();

            return "";
        }
    }
}