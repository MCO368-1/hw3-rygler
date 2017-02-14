using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEventExample
{
    public partial class SimpleEventExampleForm : Form
    {
        public SimpleEventExampleForm()
        {
            InitializeComponent();
        }

        private void clickButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button was clicked");
        }
    }
}
