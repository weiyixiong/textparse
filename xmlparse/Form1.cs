using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xmlparse
{
    public partial class Form1 : Form
    {
        Boolean deveMode = true;
        public static string templateFilePath = Application.StartupPath + "\\template.xml";
        public static string docconfigFilePath = Application.StartupPath + "\\doc.config";

        private ParseEngine par_engine;

        string template = "";
        string docconfig = "";
        public Form1()
        {
            InitializeComponent();
            docconfig = Read(docconfigFilePath);
            template = Read(templateFilePath);
            par_engine = new ParseEngine(template, docconfig);

        }

        private void btn_parse_Click(object sender, EventArgs e)
        {
            if (Filepath.Text.Trim().Length<=0)
            {
                MessageBox.Show("先选择目录文件");
            }
            else
            {

                TB_parsed_text.Text += par_engine.ParseText(Read(Filepath.Text));
                
                //TB_parsed_text.Text = par_engine.ParseText(Read(Filepath.Text)).Count+"";
              
            }
       
        }
        public string Read(string path)
        {
            string result = "";
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    result += line.ToString();
                }
            }
            catch (IOException e)
            {
                if (deveMode)
                    MessageBox.Show(e.ToString());
                else
                    MessageBox.Show("如下文件path不存在");
            }
            return result;
        }

        private void choiceFile_Click(object sender, EventArgs e)
        {
            string fName="";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openFileDialog.FileName;
                Filepath.Text = fName;
            }
        }
       
      



    }
}
