using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMSObfuscator
{
    class ObfuscateStrings
    {
        private static readonly Random r = new Random();
        private static List<Variable> vars = new List<Variable>();
        private static List<string> prevars = new List<string>();
        private static List<int> currentchars = new List<int>();
        private static int current = 0;

        private static string turnNumberIntoJumble(int input)
        {
            int which = r.Next(0, 3);
            string str = "";
            switch (which) {
                case 0:
                    int random = r.Next(-10, 10);
                    int random2 = r.Next(-100, 100);
                    int newnum = input - random2;
                    float nnum = newnum;
                    float inp = input;
                    str += Convert.ToString(newnum) + "+" + Convert.ToString(random2);
                    break;
                case 1:
                    int random_1 = r.Next(-10, 10);
                    int random2_1 = r.Next(-100, 100);
                    int newnum_1 = input + random2_1;
                    float nnum_1 = newnum_1;
                    float inp_1 = input;
                    str += Convert.ToString(newnum_1) + "-(" + Convert.ToString(random2_1) + ")";
                    break;
                case 2:
                    int random_2 = r.Next(-10, 10);
                    int random2_2 = r.Next(-100, 100);
                    while (random_2 == 0)
                    {
                        random_2 = r.Next(-10, 10);
                    }
                    while (random2_2 == 0)
                    {
                        random2_2 = r.Next(-100, 100);
                    }
                    int newnum_2 = input * random2_2;
                    float nnum_2 = newnum_2;
                    float inp_2 = input;
                    str += Convert.ToString(newnum_2) + "/" + Convert.ToString(random2_2);
                    break;
                default:
                    str = "0";
                    break;
            }
            bool did = false;
            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "VBScript";
            foreach (Variable var in vars)
            {
                if (var.GetVarType() == VariableType.VarType.String)
                {
                    if (sc.Eval((string)var.GetValue()) == input)
                    {
                        str = var.Name;
                        did = true;
                    }
                }
            }

            if (did == false)
            {
                vars.Add(new Variable("_oStr_" + Convert.ToString(current), str, VariableType.VarType.String));
                prevars.Add("var " + "_oStr_" + Convert.ToString(current) + "=" + str + ";");
                currentchars.Add(input);
                str = "_oStr_" + Convert.ToString(current);
                current++;
            }
            return str;
        }
        public static string[] ObStrings(string input)
        {
            vars = new List<Variable>();
            prevars = new List<string>();
            current = 0;
            string[] delim = new string[] { Environment.NewLine };
            string[] split = input.Split(delim, StringSplitOptions.None);
            currentchars = new List<int>();
            List<string> final = new List<string>();
            bool inString = false;
            string kind = "";
            foreach (string str in split)
            {
                string newstr = "";
                int i = 0;
                foreach(char c in str)
                {
                    i++;
                    if (c == '\"')
                    {
                        if (inString == false)
                        {
                            inString = true;
                            kind = "\"";
                        }
                        else if (kind == "\"")
                        {
                            inString = false;
                            newstr += "\"\"";
                            kind = "";
                        }
                        else
                        {
                            newstr += "chr(";
                            newstr += turnNumberIntoJumble(Convert.ToInt32(c));
                            newstr += ")+";
                        }
                    } else
                    if (c == '\'')
                    {
                        if (inString == false)
                        {
                            inString = true;
                            kind = "'";
                        }
                        else if (kind == "'")
                        {
                            inString = false;
                            newstr += "\'\'";
                            kind = "";
                        }
                        else
                        {
                            newstr += "chr(";
                            newstr += turnNumberIntoJumble(Convert.ToInt32(c));
                            newstr += ")+";
                        }
                    } else if (!inString)
                    {
                        newstr += c;
                    } else if (inString)
                    {
                        newstr += "chr(";
                        newstr += turnNumberIntoJumble(Convert.ToInt32(c));
                        newstr += ")+";
                        if(i == str.Length)
                        {
                            newstr += "\"" + Environment.NewLine + "\"+";
                        }
                    }         
                }
                final.Add(newstr);
            }
            string chars = "";
            foreach (string str in prevars)
                chars += str;
            if (chars != "")
                final.Insert(0,chars);
            return final.ToArray();
        }
    }
}