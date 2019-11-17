using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    interface MyInterface
    {
        String[] Import();
        string Validate();
        bool isBalanced();
    }
}
