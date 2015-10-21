using System;
using System.IO;
using IronPython.Hosting;
using System.Collections.Generic;
using System.Text;

namespace JoinMarketTest.JoinMarket
{
    internal static class Wallet
    {
        private static readonly string WalletToolPath = Path.Combine(Environment.CurrentDirectory, @"wallet-tool.py");
        private static readonly string SendpaymentPath = Path.Combine(Environment.CurrentDirectory, @"sendpayment.py");
        private static readonly string EncWrapperPath = Path.Combine(Environment.CurrentDirectory, @"lib\enc_wrapper.py");

        private const string WalletFileName = "HiddenWallet.json";

        

        /// <summary>
        /// Generates a HiddenWallet.json without password
        /// </summary>
        /// <returns>JoinMarket console response</returns>
        internal static string Generate()
        {
            var options = new Dictionary<string, object> {["Arguments"] = new[] { "" , "generate"}};

            var engine = Python.CreateEngine(options);

            var searchPaths = engine.GetSearchPaths();
            searchPaths.Add(@"StdLib");
            engine.SetSearchPaths(searchPaths);
            
            var script = engine.CreateScriptSourceFromFile(WalletToolPath);

            var scope = engine.CreateScope();
            scope.SetVariable("password", "");
            scope.SetVariable("walletname", WalletFileName);

            string ret;
            using (var ms = new MemoryStream())
            {
                engine.Runtime.IO.SetOutput(ms, new StreamWriter(ms));

                script.Execute(scope);

                ret = ReadFromStream(ms);
            }

            return ret;
        }


        /// <summary>
        /// Sweep out the wallet
        /// </summary>
        /// <returns>JoinMarket console response</returns>
        internal static string Sweep(string address)
        {
            var trimmedAddress = address.Trim();
            var options = new Dictionary<string, object>
            {
                ["Arguments"] = new[]
                {
                    "",
                    WalletFileName,
                    "0",
                    trimmedAddress
                }
            };

            var engine = Python.CreateEngine(options);

            var searchPaths = engine.GetSearchPaths();
            searchPaths.Add(@"StdLib");
            engine.SetSearchPaths(searchPaths);

            var script = engine.CreateScriptSourceFromFile(SendpaymentPath);
            
            string ret;
            using (var ms = new MemoryStream())
            {
                engine.Runtime.IO.SetOutput(ms, new StreamWriter(ms));

                script.Execute();

                ret = ReadFromStream(ms);
            }

            return ret;
        }

        /// <summary>
        /// For libsodium testing
        /// </summary>
        /// <returns></returns>
        internal static void EncWrapper()
        {
            var engine = Python.CreateEngine();

            var searchPaths = engine.GetSearchPaths();
            searchPaths.Add(@"StdLib");
            engine.SetSearchPaths(searchPaths);

            var script = engine.CreateScriptSourceFromFile(EncWrapperPath);

            script.Execute();
        }

        private static string ReadFromStream(Stream ms)
        {
            var length = (int)ms.Length;
            var bytes = new byte[length];

            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bytes, 0, (int)ms.Length);

            return Encoding.GetEncoding("utf-8").GetString(bytes, 0, (int)ms.Length);
        }
    }
}