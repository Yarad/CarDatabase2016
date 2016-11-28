﻿using System;
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

            for (int i = 0; i < CurrDatabase.Factories.Length; i++)
                comboBox1.Items.Add(CurrDatabase.Factories[i].FactoryName);
            //остально подгружается только в других этапах
        }
        public void LoadFactoryInfo(TFactory CurrFactory)
        {
            if (CurrFactory == null) return;
            textBoxFactoryName.Lines[0] = CurrFactory.FactoryName;
            textBoxURL.Lines[0] = CurrFactory.AboutInfoURL;
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
            if (((ComboBox)sender).SelectedIndex != -1) //если выбрали марку
            {
                FactoryIndex = MainCarDatabase.FindFactory(comboBox1.SelectedText);
                if (FactoryIndex == -1)
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

            LoadFactoryInfo(MainCarDatabase.Factories[FactoryIndex]);
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

        private void pictureBoxAddFactory_Click(object sender, EventArgs e)
        {
            
            if (MainCarDatabase.AddFactory(ProjectStrings.InitFactoryName)) //добавили в объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Show();

                FactoryIndex = MainCarDatabase.FindFactory(ProjectStrings.InitFactoryName);
                comboBox1.Items.Add(ProjectStrings.InitFactoryName);
                comboBox1.SelectedText = ProjectStrings.InitFactoryName; //добавили в список
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (FactoryIndex != -1) //сохранение фабрики
            {
                MainCarDatabase.Factories[FactoryIndex].FactoryName = textBoxFactoryName.Text;
                MainCarDatabase.Factories[FactoryIndex].AboutInfoURL = textBoxURL.Text;
            }

            if (ModelIndex != -1)
            {


            }
        }




    }
}
