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
    public partial class Us_Add : UserControl
    {
        public Us_Add()
        {
            InitializeComponent();
          /*  dataGridView1.Rows.Clear();
            XmlDocument document = new XmlDocument();
            document.Load("Data.xml");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Column = textBox1.Text;
            dataGridView1.Columns.Add(Column, Column);
            textBox1.Clear();
        }

        private void SearchTable_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Data.xml");
            XmlNodeList List = doc.GetElementsByTagName("Table");
            XmlNodeList childrens=null;
             for(int i=0;i<List.Count;i++)
             {
                 if(List[i].Attributes[0].Value==TableName.Text)
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
             //string[] Data=null;
             List<String[]> row = new List<String[]>();
             for (int i = 0; i < childrens[0].ChildNodes.Count; i++)
             {
                 dataGridView1.Columns.Add(childrens[0].ChildNodes[i].Name, childrens[0].ChildNodes[i].Name);

             }

            for (int i = 0; i < childrens.Count;i++ )
             {
                
                    
                    
                 XmlNodeList x = childrens[i].ChildNodes;
                 string[] Row=new string[x.Count];
                 for (int j = 0; j < x.Count; j++)
                     Row[j] = x[j].InnerText;
                 row.Add(Row);
             }
             for (int i = 0; i < childrens.Count;i++ )
             {
                
                     dataGridView1.Rows.Add(row.ElementAt(i));
                 
                 
             }
            
           

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
              




            /*dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            TableName.Clear();
            MessageBox.Show("Done");*/
        }
    }
}
