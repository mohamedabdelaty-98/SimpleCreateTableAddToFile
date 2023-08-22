using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace Project_Fill
{
    public partial class Us_Create : UserControl
    {
        public Us_Create()
        {
            InitializeComponent();
        }

        private void Us_Create_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string Column = textBox1.Text;
            dataGridView1.Columns.Add(Column, Column);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.Columns[0].HeaderText);
            if(!File.Exists("Data.xml"))
            {
                XmlWriter Writer = XmlWriter.Create("Data.xml");
                
                Writer.WriteStartDocument();
                Writer.WriteStartElement("Tables");
                Writer.WriteStartElement("Table");
                Writer.WriteAttributeString("Name", TableName.Text);
                for(int i =0;i<dataGridView1.Rows.Count-1;i++)
                {
                Writer.WriteStartElement("Row");
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Writer.WriteStartElement(dataGridView1.Columns[j].HeaderText);
                    Writer.WriteString(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    Writer.WriteEndElement();
                }
                Writer.WriteEndElement();

                }
                Writer.WriteEndElement();
                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Close();
                MessageBox.Show("Done");

            }
            else
            {
                
                XmlDocument doc = new XmlDocument();
                XmlElement Head;
                XmlElement Head2=null ;
                XmlElement node;
                Head = doc.CreateElement("Table");
                Head.SetAttribute("Name2", TableName.Text);
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                   
                    Head2 = doc.CreateElement("Row");
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        node = doc.CreateElement(dataGridView1.Columns[j].HeaderText);
                        node.InnerText = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        Head2.AppendChild(node);
                    }
                    doc.Load("Data.xml");
                    Head.AppendChild(Head2);
                }
                

                XmlElement Root = doc.DocumentElement;
                Root.AppendChild(Head);
                doc.Save("Data.xml");
                TableName.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                MessageBox.Show("Done");


            }
        }
    }
}
