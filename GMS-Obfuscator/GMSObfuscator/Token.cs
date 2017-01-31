using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMSObfuscator
{
    class Token
    {

        public TokenType type; //Access token type + token content here, no functions
        public string token;

        public enum TokenType //The enum for token types.
        {
            Comment,
            String,
            Number,
            Delimiter,
            Operator,
            Identifier,
            None //For errors
        }

        public Token(TokenType type, string token)
        {
            this.type = type;
            this.token = token;
        }
    }
}
