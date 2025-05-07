using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Project
{

    internal class fourbase
    {
        public double x, y, result;
        public char operation;
        public bool Calculate()
        {
            switch (operation)
            {
                case ('+'):
                    result = x + y;
                    break;
                case ('-'):
                    result = x - y;
                    break;
                case ('x'):
                    result = x * y;
                    break;
                case ('/'):
                    if (y == 0)
                    {
                        return false;
                    }
                    result = x / y;
                    break;
                default:
                    return false;
            }
            return true;
        }

        
    }
}
