using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDatabase
{
    public partial class MainForm : Form
    {
        public CarInfoDatabase MainCarDatabase;
        public MainForm()
        {
            this.MainCarDatabase = new CarInfoDatabase();
            MainCarDatabase.UpdateInfo();
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.SaveChanges())
                MessageBox.Show(ProjectStrings.WasSaved);
            else
                MessageBox.Show(ProjectStrings.WasNotSaved);

        }

        
    }
}
