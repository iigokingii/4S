using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Invalid : Form
    {
        public Invalid()
        {
            InitializeComponent();
        }
        public Invalid(List<ValidationResult> list)
        {
            InitializeComponent();
            string s="";
            foreach (var error in list)
            {
                s = s + " " + error.ErrorMessage;
            }
            textBox1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
