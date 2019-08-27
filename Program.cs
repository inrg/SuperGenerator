using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using Microsoft.Win32;
using SharedProject;

namespace SuperGen {
    class Program {
        static List<string> _ruleList = new List<string>();
        static int _defaultCount = 1;
        static RegistryKey _registryKey;
        static void Main(string[] args) {
            _registryKey = Registry.CurrentUser.OpenSubKey("Software\\SuperGenerator\\Rules", RegistryRights.FullControl);
            if (_registryKey == null) {
                _registryKey = Registry.CurrentUser.CreateSubKey("Software\\SuperGenerator\\Rules");

                _registryKey?.SetValue("ID32", "__[0-9a-z]{32}__");
            }

            for (int i = 0; i < args.Length; i++) {
                if (args[i].StartsWith("-")) {
                    if (args[i].TrimStart('-').Equals("c", StringComparison.OrdinalIgnoreCase)) {
                        if ((i + 1) > args.Length || !int.TryParse(args[i + 1].Trim(), out _defaultCount)) {
                            Console.WriteLine("ERROR: Invalid parameter '-c'.");
                            return;
                        }
                    }

                    i += 1;
                } else {
                    _ruleList.Add(args[i].Trim());
                }
            }

            ReadConfigAndSet();

            for (int i = 0; i < _defaultCount; i++) {
                foreach (var rule in _ruleList) {
                    Console.WriteLine(SuperGenerator.From(rule).Make());
                }
            }


            _registryKey?.Close();
        }

        static void ReadConfigAndSet() {
            _registryKey = _registryKey ?? Registry.LocalMachine.OpenSubKey("Software\\SuperGenerator\\Rules", RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (_registryKey == null) return;

                var names = _registryKey.GetValueNames();
                for (int i = 0; i < _ruleList.Count; i++)
                {
                    if (names.Contains(_ruleList[i]))
                        _ruleList[i] = _registryKey.GetValue(_ruleList[i])?.ToString();
                }
        }
    }
}
