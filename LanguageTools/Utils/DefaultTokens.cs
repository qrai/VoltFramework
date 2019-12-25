using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Utils
{
    public static class DefaultTokens
    {
        public static Token NumberToken(string name)
        {
            Token res = new Token(name, new
                RegexTokenMarker(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b"));
            return res;
        }
        public static Token NameToken(string name)
        {
            Token res = new Token(name, new
                RegexTokenMarker(@"^[a-zA-Z0-9_]+$"));
            return res;
        }
        /// <summary>
        /// Not done
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Token StringToken(string name)
        {
            //TODO:
            Token res = new Token(name, new RegexTokenMarker(@"
                            # Character definitions:
                            '
                            (?> # disable backtracking
                              (?:
                                \\[^\r\n]|    # escaped meta char
                                [^'\r\n]      # any character except '
                              )*
                            )
                            '?
                            |
                            # Normal string & verbatim strings definitions:
                            (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string
                            ""
                            (?> # disable backtracking
                              (?:
                                # match and consume an escaped character including escaped double quote ("") char
                                (?(verbatimIdentifier)        # if it is a verbatim string ...
                                  """"|                         #   then: only match an escaped double quote ("") char
                                  \\.                         #   else: match an escaped sequence
                                )
                                | # OR
            
                                # match any char except double quote char ("")
                                [^""]
                              )*
                            )
                            ""
                        "));
            return res;
        }
        /// <summary>
        /// Not done
        /// </summary>
        /// <param name="name"></param>
        /// <param name="commentIdentifier"></param>
        /// <returns></returns>
        public static Token CommentToken(string name, string commentIdentifier)
        {
            //TODO: 
            Token res = new Token(name, new RegexTokenMarker("r"));
            return res;
        }
    }
}
