using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator.Model
{
    class Operations
    {
        public string DoOperation(string first,string second,string op)
        {
            if (first != "" && second != "")
            {
                switch (op)
                {
                    case "+":
                        return (Convert.ToInt32(first) + Convert.ToInt32(second)).ToString();
                    case "-":
                        return (Convert.ToInt32(second) - Convert.ToInt32(first)).ToString();
                    case "*":
                        return (Convert.ToInt32(first)*Convert.ToInt32(second)).ToString();
                    case "/":
                        return (Convert.ToInt32(second)/Convert.ToInt32(first)).ToString();
                }
            }
            return second;
        }
    }
}
