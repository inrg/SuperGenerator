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

        #region config
        static string _registryBasePath = "Software\\SuperGenerator";
        static string _registryNameRule = "Rules";
        static string _defaultPattern = "__[0-9a-z]{32}__";
        static int _defaultCount = 1;
        static bool _enableHistory = true;
        static bool _useLastHistory = true;
        static int _historyNumber = 10;
        #endregion

        static RegistryKey _registryRulesKey, _registryConfigKey;

        static void Main(string[] args) {
            TryReadConfig();
            TryReadCustomRules();

            bool enablePause = false;
            for (int i = 0; i < args.Length; i++) {
                if (args[i].StartsWith("-")) {
                    if (args[i].TrimStart('-').Equals("p"/*pause*/, StringComparison.OrdinalIgnoreCase)) {
                        enablePause = true;
                    } else if (args[i].TrimStart('-').Equals("c"/*generator count*/, StringComparison.OrdinalIgnoreCase)) {
                        if ((i + 1) > args.Length || !int.TryParse(args[i + 1].Trim(), out _defaultCount)) {
                            Console.WriteLine("ERROR: Invalid parameter '-c'.");
                            return;
                        }

                        i += 1;
                    } else if (args[i].TrimStart('-').Equals("a"/*add/modify pattern to register*/, StringComparison.OrdinalIgnoreCase)) {
                        while (true) {
                            Console.WriteLine("Please input rule name(Enter empty modify default rule):");
                            string name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name?.Trim()))
                                break;

                            Console.WriteLine("Please input rule string(Enter empty exit):");
                            string rule = Console.ReadLine();
                            if (string.IsNullOrEmpty(rule?.Trim()))
                                break;

                            _registryRulesKey.SetValue(name ?? "", rule);

                            Console.WriteLine("Success! Do you want to continue(Exit press ESC/n)?");
                            switch (Console.ReadKey(false).Key) {
                                case ConsoleKey.N:
                                case ConsoleKey.Escape:
                                    goto _app_end_;
                            }
                        }
                    }
                } else {
                    _ruleList.Add(args[i].Trim());
                }
            }

            if (!_ruleList.Any()) {
                _ruleList.Add(_defaultPattern);
            }

            _defaultCount |= 1;
            for (int i = 0; i < _defaultCount; i++) {
                foreach (var rule in _ruleList) {
                    Console.WriteLine(SuperGenerator.From(rule).Make());
                }
            }

            _app_end_:
            TryRefreshConfig();

            _registryConfigKey?.Close();
            _registryRulesKey?.Close();

            if (enablePause)
                system("pause");
        }

        static RegistryKey TryReadConfig(string configNodeName = "Config") {
            _registryConfigKey = Registry.CurrentUser.OpenSubKey($"{_registryBasePath}\\{configNodeName}", true);
            if (_registryConfigKey == null) {
                _registryConfigKey = Registry.CurrentUser.CreateSubKey($"{_registryBasePath}\\{configNodeName}", RegistryKeyPermissionCheck.ReadWriteSubTree);

                //default config
                _registryConfigKey?.SetValue("RegistryBasePath", _registryBasePath);
                _registryConfigKey?.SetValue("DefaultPattern", _defaultPattern);
                _registryConfigKey?.SetValue("EnableHistory", _enableHistory);
                _registryConfigKey?.SetValue("UseLastHistory", _useLastHistory);
                _registryConfigKey?.SetValue("DefaultCount", _defaultCount);
                _registryConfigKey?.SetValue("HistoryCount", _historyNumber);
                return _registryConfigKey;
            }

            _registryBasePath = _registryConfigKey.GetValue("RegistryBasePath").ToString();
            _defaultPattern = _registryConfigKey.GetValue("DefaultPattern").ToString();
            bool.TryParse(_registryConfigKey.GetValue("EnableHistory").ToString(), out _enableHistory);
            bool.TryParse(_registryConfigKey.GetValue("UseLastHistory").ToString(), out _useLastHistory);
            int.TryParse(_registryConfigKey.GetValue("DefaultCount").ToString(), out _defaultCount);
            int.TryParse(_registryConfigKey.GetValue("HistoryCount").ToString(), out _historyNumber);
            return _registryConfigKey;
        }

        static bool TryRefreshConfig() {
            if (_registryConfigKey == null)
                return false;

            string dpOld = _registryConfigKey.GetValue("DefaultPattern")?.ToString();
            string dpNew = _registryRulesKey.GetValue("")?.ToString();
            if (!string.IsNullOrEmpty(dpNew)) {
                if (string.IsNullOrEmpty(dpOld) || !dpNew.Equals(dpOld)) {
                    _registryConfigKey.SetValue("DefaultPattern", dpNew);
                }
            }

            return true;
        }

        static RegistryKey TryReadCustomRules() {
            _registryRulesKey = Registry.CurrentUser.OpenSubKey($"{_registryBasePath}\\{_registryNameRule}", true);
            if (_registryRulesKey == null) {
                _registryRulesKey = Registry.CurrentUser.CreateSubKey($"{_registryBasePath}\\{_registryNameRule}", RegistryKeyPermissionCheck.ReadWriteSubTree);

                _registryRulesKey?.SetValue("", _defaultPattern);
            } else {
                _defaultPattern = _registryRulesKey?.GetValue("").ToString();
            }

            return _registryRulesKey;
        }

        [System.Runtime.InteropServices.DllImport("msvcrt.dll")]
        public static extern bool system(string str);
    }


}
