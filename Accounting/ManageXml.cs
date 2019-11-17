using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Accounting
{
    class ManageXml:MyInterface
    {
        public String[] strlist;
        public String[] myValue;
        public String[] Import()
        {
            OpenFileDialog result = new OpenFileDialog() { Filter = "XML|*.xml", ValidateNames = true, Multiselect = false };
            if (result.ShowDialog() == DialogResult.OK)
            {

                String[] hello = ReadXml(result.FileName);
                this.strlist = hello;
                return hello;
            }
            return null;


        }
        public String[] ReadXml(string filename)
        {
            
            XmlDocument doc = new XmlDocument();
            XmlNodeList xmlnode;
            doc.Load(filename);
            xmlnode = doc.GetElementsByTagName("Transaction");
            Console.WriteLine(xmlnode.Count);
            myValue = new string[xmlnode.Count*3];
            int j = 0;
            for (int i=0; i < xmlnode.Count; i++)
            {
                
                myValue.SetValue(xmlnode[i].Attributes[0].InnerText,j);
                myValue.SetValue(xmlnode[i].Attributes[1].InnerText,j+1);
                myValue.SetValue(xmlnode[i].Attributes[2].InnerText, j+2);
                j += 3;
                
            }
            return myValue;
        }

        public string Validate()
        {

            for (int i = 0; i < strlist.Length - 2; i += 3)
            {
                if (!(strlist[i].Equals("C") || strlist[i].Equals("D")))
                {
                    string error = "line" + " " + (i / 3 + 1) + " has a problem of type ";
                    return error;
                }

            }
            for (int i = 0; i < strlist.Length - 2; i += 3)
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
            for (int i = 0; i < strlist.Length - 2; i += 3)
            {
                Console.WriteLine("hey this is {0}", strlist[i + 2]);
                if (String.IsNullOrEmpty(strlist[i + 2]))
                {
                    string error = "This description is empty";
                    return error;
                }

            }

            return "Done Checking";
        }
        public bool isBalanced()
        {
            decimal credit = 0;
            decimal debit = 0;
            for (int i = 0; i < strlist.Length - 2; i += 3)
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
