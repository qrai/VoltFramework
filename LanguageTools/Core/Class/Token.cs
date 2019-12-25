using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public interface IToken
    {
        string Name { get; set; }
        TokenMarker Marker { get; set; }
    }

    public class Token : IToken
    {
        /// <summary>
        /// Token name(any)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Marker of the token
        /// </summary>
        public TokenMarker Marker { get; set; }
        /// <summary>
        /// Token array is all tokens in code, int is current token index
        /// </summary>
        public Action<Token[], int> StepExecute = null;

        public bool Used = false;

        private string _Text = null;
        /// <summary>
        /// Text that found by marker in code
        /// </summary>
        public string Text { get { return _Text.Replace("\r", ""); } set { _Text = value; } }

        public Token(string name, TokenMarker marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}
