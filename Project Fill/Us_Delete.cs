using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Project_Fill
{
    public partial class Us_Delete : UserControl
    {
        public Us_Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Data.xml");
            XmlNodeList List = doc.GetElementsByTagName("Table");
            XmlNodeList childrens = null;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Attributes[0].Value == textBox1.Text)
                {
                    childrens = List[i].ChildNodes;
                    break;
                }
                else
                {
                    MessageBox.Show("The Name Doesnt Exsist");
                    break;
                }
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Data.xml");
            XmlNodeList List = doc.GetElementsByTagName("Table");
            XmlNodeList childrens = null;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Attributes[0].Value == textBox1.Text)
                {
                    childrens = List[i].ChildNodes;
                    break;
                }
            }
            for (int i = 0; i < childrens[0].ChildNodes.Count; i++)
            {
                if (childrens[0].ChildNodes[i].Name == textBox2.Text)
                {
                    
                    XmlNodeList nodes = doc.SelectNodes(childrens[0].ChildNodes[i].Name);
                    for (int j = nodes.Count - 1; j >= 0; j--)
                    {
                        nodes[j].ParentNode.RemoveChild(nodes[j]);
                    }
                    doc.Save("Data.xml");
                    MessageBox.Show("Done");
                   
                }
            }
            
        }
    }
}
