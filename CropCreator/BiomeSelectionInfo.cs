using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CropCreator
{
    public partial class BiomeSelectionInfo : Form
    {
        public bool OkPressed { get; set; }
        public string Result { get; set; }

        public BiomeSelectionInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OkPressed = true;
            this.Result = this.comboBox1.SelectedItem.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
