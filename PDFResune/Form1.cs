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
            Paragraph age = new Paragraph(output.Age);
            Paragraph address = new Paragraph(output.Address);
            Paragraph contactnumber = new Paragraph(output.ContactNumber);
            Paragraph emailaddress = new Paragraph(output.EmailAddress +"\n\n\n");
            Paragraph objective = new Paragraph("OBJECTIVE\n"+output.Objective);
            Paragraph skills = new Paragraph("SKILLS\n" + output.Skills);
            Paragraph workexperience = new Paragraph("EXPERIENCE\n" + output.WorkExperience);
            Paragraph education = new Paragraph("EDUCATION\n" + output.Education);
            Paragraph certification = new Paragraph("CERTIFICATION\n" + output.Certification);

            name.Font.Size = 20;
            name.Alignment = Element.ALIGN_CENTER;
            age.Alignment = Element.ALIGN_CENTER;
            address.Alignment = Element.ALIGN_CENTER;
            contactnumber.Alignment = Element.ALIGN_CENTER;
            emailaddress.Alignment = Element.ALIGN_CENTER;


            mypdfresume.Add(name);
            mypdfresume.Add(age);
            mypdfresume.Add(address);
            mypdfresume.Add(contactnumber);
            mypdfresume.Add(emailaddress);
            mypdfresume.Add(objective);
            mypdfresume.Add(skills);
            mypdfresume.Add(workexperience);
            mypdfresume.Add(education);
            mypdfresume.Add(certification);

            mypdfresume.Close();
            MessageBox.Show("Successfuly");
        }
        public class mypdfInfo
        {
            public string FullName { get; set; }
            public string Age { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
            public string EmailAddress { get; set; }
            public string Objective { get; set; }
            public string Skills { get; set; }
            public string WorkExperience { get; set; }
            public string Education { get; set; }
            public string Certification { get; set; }


        }
    }
}
