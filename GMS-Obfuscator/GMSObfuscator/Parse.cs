using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMSObfuscator
{
    class Parse //Class for tokenization and code interpreting, used for complex obfuscation.
    {
        public static List<Command> getCommands(Token[] toks)
        {
            List<Token> tokens = new List<Token>();
            List<Command> cmds = new List<Command>();

            ////
            // script();
            // x = y;
            // var x = y;
            // var z;
            // if(x == y)     (ALSO while,for,etc.)
            ////


            return cmds;
        }

        public static List<Token> Tokenize(string input)
        {
            List<Token> toks = new List<Token>();
            Token.TokenType t;
            int i = 0,z = 0;
            char[] ch = input.ToCharArray();
            while (i < input.Length)
            {
                t = Token.TokenType.None;
                char c = ch[i];
                if(i != input.Length - 1 && c == '/' && ch[i+1] == '*')
                {
                    z = input.IndexOf("*/");
                    if(z != -1)
                    {
                        z += 2;
                    }
                    t = Token.TokenType.Comment;
                } else
                if (i != input.Length - 1 && c == '/' && ch[i + 1] == '/')
                {
                    z = input.IndexOf(Environment.NewLine);
                    z += Environment.NewLine.Length;
                    t = Token.TokenType.Comment;
                }
                toks.Add(new Token(t, input.Substring(i, z)));
                i = z;
            }
            return toks;
        }
        
    }
}
