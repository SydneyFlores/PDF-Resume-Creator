using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace PDFResune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            mypdfInfo output = JsonConvert.DeserializeObject<mypdfInfo>(File.ReadAllText("Resume.json"));
            MessageBox.Show(output.FullName.ToString());
        }
        public class mypdfInfo
        {
            public string FullName { get; set; }
        }
    }
}
