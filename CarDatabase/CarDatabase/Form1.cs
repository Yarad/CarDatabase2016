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

        public int FactoryIndex;
        public int ModelIndex;
        public int GenerationIndex;

        public MainForm()
        {
            this.MainCarDatabase = new CarInfoDatabase();
            InitializeComponent();
            MainCarDatabase.UpdateInfo();
            LoadFactoriesList(MainCarDatabase);

        }

        public void LoadFactoriesList(CarInfoDatabase CurrDatabase)
        {
            if (comboBox1 != null)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
            }
            //if (CurrDatabase.Factories == null) return;

            for (int i = 0; i < CurrDatabase.Factories.Count; i++)
                comboBox1.Items.Add(CurrDatabase.Factories[i].FactoryName);
            //остально подгружается только в других этапах
        }
        public void LoadFactoryInfo(TFactory CurrFactory)
        {
            if (CurrFactory == null) return;
            textBoxFactoryName.Text = CurrFactory.FactoryName;
            textBoxURL.Text = CurrFactory.AboutInfoURL;
        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            webBrowserFactoryInfo.Navigate(((TextBox)sender).Text);
        }

        public void LoadModelsList(CarInfoDatabase CurrDatabase, TFactory OfThisFactory)
        {
            if (OfThisFactory == null) return;
            for (int i = 0; i < OfThisFactory.Models.Length; i++)
                comboBox1.Items.Add(OfThisFactory.Models[i].ModelName);
            //остально подгружается только в других этапах
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.SaveChanges())
                MessageBox.Show(ProjectStrings.WasSaved);
            else
                MessageBox.Show(ProjectStrings.WasNotSaved);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFactoryName.Clear();
            textBoxURL.Clear();

            if (((ComboBox)sender).SelectedIndex != -1) //если выбрали марку
            {
                FactoryIndex = MainCarDatabase.FindFactory(comboBox1.SelectedItem.ToString());
                if ((FactoryIndex == -1) && !(String.Equals(comboBox1.SelectedItem.ToString(), ProjectStrings.InitFactoryName)))
                    MessageBox.Show(ProjectStrings.CarInfoWasNotFound);

                if (!panelFactoryInfo.Visible)
                {
                    panelModelInfo.Hide();
                    panelCarInfo.Hide();
                    panelFactoryInfo.Show();
                }

                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;

                pictureBoxDelFactory.Enabled = true;

                pictureBoxAddModel.Enabled = true;
                pictureBoxDelModel.Enabled = false;

                pictureBoxAddGeneration.Enabled = false;
                pictureBoxDelGeneration.Enabled = false;
            }
            else
            {
                pictureBoxDelFactory.Enabled = false;

                pictureBoxAddModel.Enabled = false;
                pictureBoxDelModel.Enabled = false;

                pictureBoxAddGeneration.Enabled = false;
                pictureBoxDelGeneration.Enabled = false;
            }
            if ((FactoryIndex != -1) && !(String.Equals(comboBox1.SelectedItem.ToString(), ProjectStrings.InitFactoryName)))
                LoadFactoryInfo(MainCarDatabase.Factories[FactoryIndex]);
        }

        private void pictureBoxAddFactory_Click(object sender, EventArgs e)
        {

            if (MainCarDatabase.AddFactory(ProjectStrings.InitFactoryName)) //добавили в объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Show();

                FactoryIndex = MainCarDatabase.FindFactory(ProjectStrings.InitFactoryName);
                int temp = comboBox1.Items.Add(ProjectStrings.InitFactoryName);
                comboBox1.SelectedIndex = temp;
                //добавили в список
            }
        }

        private void pictureBoxDelFactory_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.DeleteFactory(comboBox1.SelectedText)) //добавили в объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Hide();
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                //добавили в список
            }
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panelModelInfo.Visible && (((ComboBox)sender).SelectedIndex != -1))
            {
                panelModelInfo.Show();
                panelCarInfo.Hide();
                panelFactoryInfo.Hide();

                comboBox1.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
        }

        private void comboBoxGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panelCarInfo.Visible && (((ComboBox)sender).SelectedIndex != -1))
            {
                panelModelInfo.Hide();
                panelCarInfo.Show();
                panelFactoryInfo.Hide();

                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (FactoryIndex != -1) //сохранение фабрики
            {
                MainCarDatabase.Factories[FactoryIndex].FactoryName = textBoxFactoryName.Text;
                MainCarDatabase.Factories[FactoryIndex].AboutInfoURL = textBoxURL.Text;
                comboBox1.Items[comboBox1.SelectedIndex] = textBoxFactoryName.Text;

            }

            if (ModelIndex != -1)
            {


            }
        }

        

    }
}
