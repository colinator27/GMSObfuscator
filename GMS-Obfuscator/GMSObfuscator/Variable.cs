using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMSObfuscator
{
    class Variable
    {

        private VariableType.VarType type;
        private object var;
        private string name;
        public string Name;

        public Variable(string name, object value, VariableType.VarType type)
        {
            this.type = type;
            this.name = name;
            Name = name;
            var = value;
        }

        public VariableType.VarType GetVarType()
        {
            return type;
        }

        public object GetValue()
        {
            return var;
        }

        public object GetName()
        {
            return name;
        }

        public void SetType(VariableType.VarType type)
        {
            this.type = type;
        }

        public void SetValue(object val)
        {
            var = val;
        }

    }
}
