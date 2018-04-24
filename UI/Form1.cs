using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace PharmaCool
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pcdbDataSet.SALES' table. You can move, or remove it, as needed.
            this.sALESTableAdapter.Fill(this.pcdbDataSet.SALES);
            // TODO: This line of code loads data into the 'pcdbDataSet.PRODUCTS' table. You can move, or remove it, as needed.
            this.pRODUCTSTableAdapter.Fill(this.pcdbDataSet.PRODUCTS);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
