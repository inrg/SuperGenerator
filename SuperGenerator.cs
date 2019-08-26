using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperGeneratorX {
    public interface IV0 {

        string Generate(uint count);

        string ToString();
    }

    public sealed class V0 : IV0 {
        readonly List<char> _charList = new List<char>();
        private string _v0Str;
        public static V0 TryFrom(string v) {
            V0 v0 = new V0();
            v0._charList.Clear();
            v0._charList.AddRange(Parser(v));
            v0._v0Str = v;
            return v0;
        }

        public string Generate(uint count) {
            if (count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            var ssg = new ObjectGenerator(_charList);
            for (int i = 0; i < count; i++) {
                sb.Append((char)ssg.Next());
            }

            return sb.ToString();
        }

        public override string ToString() => _v0Str;

        public static char[] Parser(string v0Str) {
            string rangeRegex = @"(?<number>(?<b>\d)(\s+)?\-(\s+)?(?<e>\d))|(?<letter>((?<b>[A-Z])(\s+)?\-(\s+)?(?<e>[A-Z]))|((?<b>[a-z])(\s+)?\-(\s+)?(?<e>[a-z])))";
            var matches = Regex.Matches(v0Str, rangeRegex);
            char[] v0chs = v0Str.ToCharArray();
            List<char> chars = new List<char>();
            foreach (Match match in matches) {
                if (match.Success) {
                    if (match.Groups["number"].Success || match.Groups["letter"].Success) {
                        char b = char.Parse(match.Groups["b"].Value);
                        char e = char.Parse(match.Groups["e"].Value);
                        for (char s = b; s <= e; s++) {
                            if (!chars.Contains(s))
                                chars.Add(s);
                        }
                    }

                    for (int i = 0; i < match.Length; i++) {
                        v0chs[match.Index + i] = (char)0;
                    }
                }
            }

            foreach (var chr in v0chs) {
                if (chr == 0 || chars.Contains(chr))
                    continue;

                chars.Add(chr);
            }

            return chars.Distinct().ToArray();
        }
    }

    // ReSharper disable InconsistentNaming
    public class E0 {
        public V0 v0 { get; set; }
        public uint v1 { get; set; }
        public uint v2 { get; set; }
        public char v3 { get; set; }

        public static E0 From(string v0, string v1, string v2, string v3) {
            try {
                return new E0 {
                    v1 = string.IsNullOrEmpty(v1) ? 0 : uint.Parse(v1),
                    v2 = string.IsNullOrEmpty(v2) ? 0 : uint.Parse(v2),
                    v3 = string.IsNullOrEmpty(v3) ? (char)0 : char.Parse(v3),
                    v0 = V0.TryFrom(v0)
                };
            } catch {
                // ignored
            }

            return null;
        }

        public string Generate() {
            if (v2 == 0) {
                return v1 == 0 ? string.Empty : v0?.Generate(v1);
            }

            if (v3 == '-') {
                List<uint> counts = new List<uint>();
                for (uint v = v1; v <= v2; v++) { counts.Add(v); }
                ObjectGenerator countGenerator = new ObjectGenerator(counts);
                return v0?.Generate((uint)countGenerator.Next());
            }

            if (v3 == ',') {
                return v0?.Generate((uint)new ObjectGenerator(v1, v2).Next());
            }

            throw new NotImplementedException();
        }
    }

    // ReSharper disable InconsistentNaming
    public sealed class Element {
        private E0 e0 { get; set; }
        private string e1 { get; set; }

        public static Element From(E0 e0) {
            return new Element() { e0 = e0, e1 = null };
        }

        public static Element From(string e1) {
            return new Element() { e0 = null, e1 = e1 };
        }

        public string Generate() {
            if (!string.IsNullOrEmpty(e1))
                return e1;
            return e0?.Generate();
        }

        private Element() { }
    }

    public class SuperGenerator {
        const string RegexPattern = @"(?<e0>\[(?<v0>.+?)\]\{(?<v1>\d+?)((?<v3>[-,])(\s+)?(?<v2>\d+?))?\})|(?<e1>[^\[\]\{\}]+)";

        private readonly List<Element> _childs = new List<Element>();
        private string _pattern = string.Empty;

        private SuperGenerator() { }

        private SuperGenerator(string pattern) {
            _parser(pattern);
        }

        public static SuperGenerator From(string pattern) {
            return new SuperGenerator(pattern);
        }

        public string Make() {
            StringBuilder sb = new StringBuilder();

            foreach (var element in _childs) {
                sb.Append(element.Generate());
            }

            return sb.ToString();
        }

        private void _parser(string pattern) {
            _pattern = pattern;

            _childs.Clear();

            var matches = Regex.Matches(pattern, RegexPattern);

            foreach (Match m in matches) {
                var e0 = m.Groups["e0"];
                var e1 = m.Groups["e1"];

                if (e0.Success) {
                    _childs.Add(Element.From(E0.From(m.Groups["v0"].Value, m.Groups["v1"].Value, m.Groups["v2"].Value, m.Groups["v3"].Value)));
                }

                if (e1.Success) {
                    _childs.Add(Element.From(e1.Value));
                }
            }
        }
    }

    public class ObjectGenerator {
        Random _random;
        readonly ArrayList _ps = new ArrayList();

        public ObjectGenerator(ICollection ps) {
            Reset();
            _ps.AddRange(ps);
        }

        public ObjectGenerator(params object[] ps) {
            Seed();
            _ps.AddRange(ps);
        }

        public object Next() {
            Reset();
            return _ps[_random.Next() % _ps.Count];
        }

        private bool Reset() {
            _random = new Random((int)Seed());
            return true;
        }

        /// <summary>
        ///   Generates a new seed, using all information available, including time.
        /// </summary>
        public static uint Seed() {
            unchecked {
                const uint factor = 19U;
                var seed = 1777771U;

                seed = factor * seed + (uint)Environment.TickCount;

                var guid = Guid.NewGuid().ToByteArray();
                seed = factor * seed + BitConverter.ToUInt32(guid, 0);
                seed = factor * seed + BitConverter.ToUInt32(guid, 8);

#if !NETSTD10
                seed = factor * seed + (uint)System.Threading.Thread.CurrentThread.ManagedThreadId;
                seed = factor * seed + (uint)System.Diagnostics.Process.GetCurrentProcess().Id;
#endif

                return seed;
            }
        }

    }
}