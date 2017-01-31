using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMSObfuscator
{
    class VariableType
    {

        public enum VarType {

            String,
            Real,
            Boolean,
            Undefined,
            Unknown

        };

        public static VarType GetType(object input)
        {
            VarType type = VarType.Unknown;
            if (input.Equals(typeof(float)) || input.Equals(typeof(double)) || input.Equals(typeof(int)))
            {
                type = VarType.Real;
            }
            if (input.Equals(typeof(string)))
            {
                type = VarType.String;
            }
            if (input.Equals(typeof(bool)))
            {
                type = VarType.Boolean;
            }
            if (input == null)
            {
                type = VarType.Undefined;
            }
            return type;
        }

    }
}
