using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Accounting
{
    class ManageCsv: MyInterface
    {
        String[] strlist;
        public String[] Import()
        { 
            OpenFileDialog result = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false };
            if (result.ShowDialog() == DialogResult.OK)
            {
          
                String[] hello = ReadCsv(result.FileName);
                this.strlist = hello;
                return hello;
            }
            return null;
            
          
        }
        private String[] ReadCsv(string filename)
        {
            string readText = File.ReadAllText(filename);
            char[] seperator = { ',' ,'\n'};

            String[] strlist = readText.Split(seperator);

            return strlist;
        }
        public string Validate()
        {

            for (int i = 0; i < strlist.Length - 2; i += 3)
            {
                if ( !(strlist[i].Equals("C") ||   strlist[i].Equals("D")))
                {
                   string error= "line" + " " + (i/3 + 1) + " has a problem of type ";
                    return error;
                }
                
            }
            for(int i=0; i < strlist.Length - 2; i += 3)
            {
                if (System.Convert.ToDecimal(strlist[i + 1]) < 0)
                {
                    string error = "line" + " " + (i / 3 + 1) + "has a Amount that is negative"; 
                    return error;
                }
                else if (System.Convert.ToDecimal(strlist[i + 1]) == 0)
                {
                    string error = "line " + (i / 3 + 1) + " has a zero Amount";
                }
            }
            for(int i=0; i < strlist.Length - 2; i += 3)
            {
                Console.WriteLine("hey this is {0}" ,strlist[i + 2]);
                if (String.IsNullOrEmpty(strlist[i+2])){
                    string error = "This description is empty";
                    return error;
                }
                    
            }

            return strlist[strlist.Length-1];
        }
        public bool isBalanced()
        {
            decimal credit = 0;
            decimal debit = 0;
            for(int i=0; i < strlist.Length - 2; i += 3)
            {
                if (strlist[i].Equals("C"))
                {
                    credit += System.Convert.ToDecimal(strlist[i + 1]);
                }
                else if (strlist[i].Equals("D"))
                {
                    debit += System.Convert.ToDecimal(strlist[i + 1]);
                }
                
            }
            if (debit == credit)
            {
                return true;
            }
            return false;
        }
    }
}
