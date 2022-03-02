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
            Document mypdfresume = new Document();
            PdfWriter.GetInstance(mypdfresume, new FileStream("FLORES_MHARSYDNEY.pdf", FileMode.Create));
            mypdfresume.Open();
            Paragraph name = new Paragraph(output.FullName);
            Paragraph Address = new Paragraph(output.Age);
            Paragraph age = new Paragraph(output.Address);

            mypdfresume.Add(name);
            mypdfresume.Add(Address);
            mypdfresume.Add(Address);

            mypdfresume.Close();
        }
        public class mypdfInfo
        {
            public string FullName { get; set; }
            public string Age { get; set; }
            public string Address { get; set; }
        }
    }
}
