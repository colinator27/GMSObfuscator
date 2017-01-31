using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMSObfuscator
{
    class Command //Pretty much a line of code, but can extend to multiple. Helps contain Token[].
    {
        public Token[] tokens;

        public Command(Token[] tokens)
        {
            this.tokens = tokens;
        }

        public Token[] GetTokens() //Just an alternative way to access the tokens
        {
            return tokens;
        }
    }
}
