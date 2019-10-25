using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football
{
    public partial class DefenseCreator : Form
    {
        public DefenseCreator()
        {
            InitializeComponent();
            SizeColumns();
            for (int i = 0; i < 45; i++ )
                dataGridView1.Rows.Add();
        }

       
        private void SizeColumns()
        {
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
            }
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            SizeColumns();
        }
    }
}
