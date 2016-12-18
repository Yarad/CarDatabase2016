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

            MainCarDatabase.UpdateInfo();
            InitializeComponent();
            LoadFactoriesList(MainCarDatabase);
            FactoryIndex = ModelIndex = GenerationIndex = -1;

        }

        public void LoadFactoriesList(CarInfoDatabase CurrDatabase)
        {
            if (comboBoxFactory != null)
            {
                comboBoxFactory.ResetText();
                comboBoxFactory.Items.Clear();
            }
            //if (CurrDatabase.Factories == null) return;

            for (int i = 0; i < CurrDatabase.Factories.Count; i++)
                comboBoxFactory.Items.Add(CurrDatabase.Factories[i].FactoryName);
            //остально подгружается только в других этапах
        }//сделано
        public void LoadFactoryInfo(TFactory CurrFactory)
        {
            if (CurrFactory == null) return;
            textBoxFactoryName.Text = CurrFactory.FactoryName;
            textBoxURL.Text = CurrFactory.AboutInfoURL;
        } //сделано

        public void LoadModelsList(TFactory CurrFactory)
        {
            if (comboBoxModel != null)
            {
                comboBoxModel.ResetText();
                comboBoxModel.Items.Clear();
            }
            for (int i = 0; i < CurrFactory.Models.Count; i++)
                comboBoxModel.Items.Add(CurrFactory.Models[i].ModelName);

        }//сделано
        public void LoadModelInfo(TModel CurrModel)
        {
            if (CurrModel == null) return;
            textBoxModelName.Text = CurrModel.ModelName;
            textBoxModelURL.Text = CurrModel.ModelURL;
        }//сделано

        public void LoadCarList(TModel CurrModel)
        {
            if (comboBoxGeneration != null)
            {
                comboBoxGeneration.ResetText();
                comboBoxGeneration.Items.Clear();
            }
            for (int i = 0; i < CurrModel.Generations.Count; i++)
                comboBoxGeneration.Items.Add(OtherFuncs.FormGenerationName(CurrModel.Generations[i].GenBegin, CurrModel.Generations[i].GenEnd));

        }//сделано

        public void LoadCarInfo(TGeneration CurrGeneration)
        {
            textBoxGenBegin.Text = CurrGeneration.GenBegin.ToString();
            textBoxGenEnd.Text = CurrGeneration.GenEnd.ToString();


            for (int i=0;i<Strings.StrTransmission.Count();i++)
            {
                if (String.Equals(Strings.TransmissionStrToType(Strings.StrTransmission[i]), CurrGeneration.CurrCar.MainParams.Transmission))
                {
                    comboBoxTransmission.SelectedIndex = i;
                    break;
                }
            }
            EnginePower.Text = CurrGeneration.CurrCar.MainParams.EnginePower.ToString();

            textBoxMaxSpeed.Text = CurrGeneration.CurrCar.MainParams.MaxSpeed.ToString();
            textBoxTimeTo100.Text = CurrGeneration.CurrCar.MainParams.TimeTo100.ToString();

            for (int i = 0; i < Strings.StrBodyType.Count(); i++)
            {
                if (String.Equals(Strings.BodyTypeStrToType(Strings.StrBodyType[i]), CurrGeneration.CurrCar.SizeParams.BodyType))
                {
                    comboBoxBodyType.SelectedIndex = i;
                    break;
                }
            }

            textBoxLength.Text = CurrGeneration.CurrCar.SizeParams.Length.ToString();

            textBoxWidth.Text = CurrGeneration.CurrCar.SizeParams.Width.ToString();
            textBoxHeight.Text = CurrGeneration.CurrCar.SizeParams.Height.ToString();
            textBoxMaxWeight.Text = CurrGeneration.CurrCar.SizeParams.MaxWeight.ToString();

            textBoxFullEquiepedWeight.Text = CurrGeneration.CurrCar.SizeParams.FullEquipedWeight.ToString();
            textBoxAmountOfDoors.Text = CurrGeneration.CurrCar.SizeParams.AmountOfDoors.ToString();

            for (int i = 0; i < Strings.StrFuelType.Count(); i++)
            {
                if (String.Equals(Strings.FuelTypeStrToType(Strings.StrFuelType[i]), CurrGeneration.CurrCar.Fuel.FuelType))
                {
                    comboBoxFuelType.SelectedIndex = i;
                    break;
                }
            }

            textBoxFuelPer100_Town.Text = CurrGeneration.CurrCar.Fuel.FuelPer100_Town.ToString();
            textBoxFuelPer100_Road.Text = CurrGeneration.CurrCar.Fuel.FuelPer100_Road.ToString();

            if (CurrGeneration.CurrCar.Security.ABS)
                checkBoxABS.CheckState = CheckState.Checked;
            else
                checkBoxABS.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Security.ESP)
                checkBoxESP.CheckState = CheckState.Checked;
            else
                checkBoxESP.CheckState = CheckState.Unchecked;
            
            if (CurrGeneration.CurrCar.Security.AntiSlip)
                checkBoxAntiSlip.CheckState = CheckState.Checked;
            else
                checkBoxAntiSlip.CheckState = CheckState.Unchecked;


            if (CurrGeneration.CurrCar.Security.DriverAirbag)
               checkBoxAirbagDriver.CheckState = CheckState.Checked;
            else
                checkBoxAirbagDriver.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Security.AheadPassengerAirbag)
                checkBoxAirbagAheadPassenger.CheckState = CheckState.Checked;
            else
                checkBoxAirbagAheadPassenger.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Comfort.CruiseControl)
                checkBoxCruiseControl.CheckState = CheckState.Checked;
            else
                checkBoxCruiseControl.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Comfort.ServoWheel)
                checkBoxServoWheel.CheckState = CheckState.Checked;
            else
                checkBoxServoWheel.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Comfort.OnBoardComputer)
                checkBoxOnBoardComputer.CheckState = CheckState.Checked;
            else
                checkBoxOnBoardComputer.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Comfort.ParkingSystem)
                checkBoxParkingSystem.CheckState = CheckState.Checked;
            else
                checkBoxParkingSystem.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Comfort.TintedGlass)
                checkBoxTintedGlass.CheckState = CheckState.Checked;
            else
                checkBoxTintedGlass.CheckState = CheckState.Unchecked;

            for (int i = 0; i < Strings.StrClimateControl.Count(); i++)
            {
                if (String.Equals(Strings.ClimateControlStrToType(Strings.StrClimateControl[i]), CurrGeneration.CurrCar.Comfort.ClimateControl))
                {
                    comboBoxClimateControl.SelectedIndex = i;
                    break;
                }
            }

            if (CurrGeneration.CurrCar.Multimedia.AudioSystem)
                checkBoxAudioSystem.CheckState = CheckState.Checked;
            else
                checkBoxAudioSystem.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Multimedia.NavigationSystem)
                checkBoxNavigationSystem.CheckState = CheckState.Checked;
            else
                checkBoxNavigationSystem.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.RainSensor)
                checkBoxRainSensors.CheckState = CheckState.Checked;
            else
                checkBoxRainSensors.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.LightSensor)
                checkBoxLightSensors.CheckState = CheckState.Checked;
            else
                checkBoxLightSensors.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.XenonLights)
                checkBoxXenonLights.CheckState = CheckState.Checked;
            else
                checkBoxXenonLights.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.HeatingMirrors)
                checkBoxMirrorHeating.CheckState = CheckState.Checked;
            else
                checkBoxMirrorHeating.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.LightAutoWashing)
                checkBoxLightsAutowashing.CheckState   = CheckState.Checked;
            else
                checkBoxLightsAutowashing.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.ObserveOpportunities.ElectricMirrorTuning)
                checkBoxElectricMirrorTuning.CheckState = CheckState.Checked;
            else
                checkBoxElectricMirrorTuning.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.AntiHijack.CentralLock)
                checkBoxCentralLock.CheckState = CheckState.Checked;
            else
                checkBoxCentralLock.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.AntiHijack.Signalisation)
                checkBoxSignalisation.CheckState = CheckState.Checked;
            else
                checkBoxSignalisation.CheckState = CheckState.Unchecked;

            textBoxAmountOfSeats.Text = CurrGeneration.CurrCar.Interior.AmountOfSeats.ToString();

            for (int i = 0; i < Strings.StrMaterial.Count(); i++)
            {
                if (String.Equals(Strings.MaterialStrToType(Strings.StrMaterial[i]), CurrGeneration.CurrCar.Interior.Material))
                {
                    comboBoxMaterial.SelectedIndex = i;
                    break;
                }
            }

            if (CurrGeneration.CurrCar.Interior.WheelHeating)
                checkBoxWheelHeating.CheckState = CheckState.Checked;
            else
                checkBoxWheelHeating.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Interior.SeatHeating)
                checkBoxSeatHeating.CheckState = CheckState.Checked;
            else
                checkBoxSeatHeating.CheckState = CheckState.Unchecked;

            if (CurrGeneration.CurrCar.Interior.Sunroof)
                checkBoxSunroof.CheckState = CheckState.Checked;
            else
                checkBoxSunroof.CheckState = CheckState.Unchecked;

            for (int i = 0; i < Strings.StrSeatsTuning.Count(); i++)
            {
                if (String.Equals(Strings.SeatTuningStrToType(Strings.StrSeatsTuning[i]), CurrGeneration.CurrCar.Interior.DriverSeatTuning))
                {
                    comboBoxDriverSeatTuning.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < Strings.StrSeatsTuning.Count(); i++)
            {
                if (String.Equals(Strings.SeatTuningStrToType(Strings.StrSeatsTuning[i]), CurrGeneration.CurrCar.Interior.OtherSeatsTuning))
                {
                    comboBoxOtherSeatsTuning.SelectedIndex = i;
                    break;
                }
            }
        }
        public bool SaveCarInfo(TGeneration CurrGeneration)
        {
            bool res,WholeRes;
            WholeRes = true;
            res = Int32.TryParse(textBoxGenBegin.Text, out CurrGeneration.GenBegin);
            res = res & Int32.TryParse(textBoxGenEnd.Text, out CurrGeneration.GenEnd);
            if (!res)
            {
                //MessageBox.Show(ProjectStrings.); уже делается
                WholeRes = false;
            }
            CurrGeneration.CurrCar.MainParams.Transmission = Strings.TransmissionStrToType(comboBoxTransmission.SelectedText);
            res = Double.TryParse(EnginePower.Text, out CurrGeneration.CurrCar.MainParams.EnginePower);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_EnginePower);
                WholeRes = false;
            }
            res = Int32.TryParse(textBoxMaxSpeed.Text, out CurrGeneration.CurrCar.MainParams.MaxSpeed);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_MaxSpeed);
                WholeRes = false;
            }

            res = Double.TryParse(textBoxTimeTo100.Text, out CurrGeneration.CurrCar.MainParams.TimeTo100);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_TimeTo100);
                WholeRes = false;
            }

            CurrGeneration.CurrCar.SizeParams.BodyType = Strings.BodyTypeStrToType(comboBoxBodyType.SelectedText);

            res = Int32.TryParse(textBoxLength.Text, out CurrGeneration.CurrCar.SizeParams.Length);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_Length);
                WholeRes = false;
            }

            res = Int32.TryParse(textBoxWidth.Text, out CurrGeneration.CurrCar.SizeParams.Width);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_Width);
                WholeRes = false;
            }

            res = Int32.TryParse(textBoxHeight.Text, out CurrGeneration.CurrCar.SizeParams.Height);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_Height);
                WholeRes = false;
            }

            res = Int32.TryParse(textBoxMaxWeight.Text, out CurrGeneration.CurrCar.SizeParams.MaxWeight);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_MaxWeight);
                WholeRes = false;
            }

            res = Int32.TryParse(textBoxFullEquiepedWeight.Text, out CurrGeneration.CurrCar.SizeParams.FullEquipedWeight);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_FullEquipedWeight);
                WholeRes = false;
            }

            res = Int32.TryParse(textBoxAmountOfDoors.Text, out CurrGeneration.CurrCar.SizeParams.AmountOfDoors);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_AmountOfDoors);
                WholeRes = false;
            }

            CurrGeneration.CurrCar.Fuel.FuelType = Strings.FuelTypeStrToType(comboBoxFuelType.SelectedText);

            res = Decimal.TryParse(textBoxFuelPer100_Town.Text, out CurrGeneration.CurrCar.Fuel.FuelPer100_Town);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_FuelPer100_Town);
                WholeRes = false;
            }

            res = Decimal.TryParse(textBoxFuelPer100_Road.Text, out CurrGeneration.CurrCar.Fuel.FuelPer100_Road);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_FuelPer100_Road);
                WholeRes = false;
            }

            CurrGeneration.CurrCar.Security.ABS = (checkBoxABS.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Security.ESP = (checkBoxESP.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Security.AntiSlip = (checkBoxAntiSlip.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Security.ABS = (checkBoxABS.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Security.DriverAirbag = (checkBoxAirbagDriver.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Security.AheadPassengerAirbag = (checkBoxAirbagAheadPassenger.CheckState == CheckState.Checked);

            CurrGeneration.CurrCar.Comfort.CruiseControl = (checkBoxCruiseControl.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Comfort.ServoWheel = (checkBoxServoWheel.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Comfort.OnBoardComputer = (checkBoxOnBoardComputer.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Comfort.ParkingSystem = (checkBoxParkingSystem.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Comfort.TintedGlass = (checkBoxTintedGlass.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Comfort.ClimateControl = Strings.ClimateControlStrToType(comboBoxClimateControl.SelectedText);

            CurrGeneration.CurrCar.Multimedia.AudioSystem = (checkBoxAudioSystem.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Multimedia.NavigationSystem = (checkBoxNavigationSystem.CheckState == CheckState.Checked);

            CurrGeneration.CurrCar.ObserveOpportunities.RainSensor = (checkBoxRainSensors.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.ObserveOpportunities.LightSensor = (checkBoxLightSensors.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.ObserveOpportunities.XenonLights = (checkBoxXenonLights.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.ObserveOpportunities.HeatingMirrors = (checkBoxMirrorHeating.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.ObserveOpportunities.LightAutoWashing = (checkBoxLightsAutowashing.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.ObserveOpportunities.ElectricMirrorTuning = (checkBoxElectricMirrorTuning.CheckState == CheckState.Checked);

            CurrGeneration.CurrCar.AntiHijack.CentralLock = (checkBoxCentralLock.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.AntiHijack.Signalisation = (checkBoxSignalisation.CheckState == CheckState.Checked);

            res = Int32.TryParse(textBoxAmountOfSeats.Text,out CurrGeneration.CurrCar.Interior.AmountOfSeats);
            if (!res)
            {
                MessageBox.Show(ProjectStrings.InvalidInput_AmountOfSeats);
                WholeRes = false;
            }
            CurrGeneration.CurrCar.Interior.Material = Strings.MaterialStrToType(comboBoxMaterial.SelectedText);
            CurrGeneration.CurrCar.Interior.WheelHeating = (checkBoxWheelHeating.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Interior.SeatHeating = (checkBoxSeatHeating.CheckState == CheckState.Checked);
            CurrGeneration.CurrCar.Interior.Sunroof = (checkBoxSunroof.CheckState == CheckState.Checked);

            CurrGeneration.CurrCar.Interior.DriverSeatTuning = Strings.SeatTuningStrToType(comboBoxDriverSeatTuning.SelectedText);
            CurrGeneration.CurrCar.Interior.OtherSeatsTuning = Strings.SeatTuningStrToType(comboBoxOtherSeatsTuning.SelectedText);

            return WholeRes;
        }
        public void ResetCarInfo()
        {
            textBoxGenBegin.Clear();
            textBoxGenEnd.Clear();


            comboBoxTransmission.Items.Clear();
            comboBoxTransmission.Items.AddRange(Strings.StrTransmission);
            
            EnginePower.Clear();
                    
            textBoxMaxSpeed.Clear();
            textBoxTimeTo100.Clear();

            comboBoxBodyType.Items.Clear();
            comboBoxBodyType.Items.AddRange(Strings.StrBodyType);

            textBoxLength.Clear();

            textBoxWidth.Clear();
            textBoxHeight.Clear();
            textBoxMaxWeight.Clear();
            
            textBoxFullEquiepedWeight.Clear();
            textBoxAmountOfDoors.Clear();
            comboBoxFuelType.Items.Clear();
            comboBoxFuelType.Items.AddRange(Strings.StrFuelType);
            textBoxFuelPer100_Town.Clear();
            textBoxFuelPer100_Road.Clear();

            checkBoxABS.CheckState = CheckState.Unchecked;
            checkBoxESP.CheckState = CheckState.Unchecked;
            checkBoxAntiSlip.CheckState = CheckState.Unchecked;
            checkBoxABS.CheckState = CheckState.Unchecked;
            checkBoxAirbagDriver.CheckState = CheckState.Unchecked;
            checkBoxAirbagAheadPassenger.CheckState = CheckState.Unchecked;

            checkBoxCruiseControl.CheckState = CheckState.Unchecked;
            checkBoxServoWheel.CheckState = CheckState.Unchecked;
            checkBoxOnBoardComputer.CheckState = CheckState.Unchecked;
            checkBoxParkingSystem.CheckState = CheckState.Unchecked;
            checkBoxTintedGlass.CheckState = CheckState.Unchecked;
            comboBoxClimateControl.Items.Clear();
            comboBoxClimateControl.Items.AddRange(Strings.StrClimateControl);

            checkBoxAudioSystem.CheckState = CheckState.Unchecked;
            checkBoxNavigationSystem.CheckState = CheckState.Unchecked;

            checkBoxRainSensors.CheckState = CheckState.Unchecked;
            checkBoxLightSensors.CheckState = CheckState.Unchecked;
            checkBoxXenonLights.CheckState = CheckState.Unchecked;
            checkBoxMirrorHeating.CheckState = CheckState.Unchecked;
            checkBoxLightsAutowashing.CheckState = CheckState.Unchecked;
            checkBoxElectricMirrorTuning.CheckState = CheckState.Unchecked;

            checkBoxCentralLock.CheckState = CheckState.Unchecked;
            checkBoxSignalisation.CheckState = CheckState.Unchecked;

            textBoxAmountOfSeats.Clear();

            comboBoxMaterial.Items.Clear();
            comboBoxMaterial.Items.AddRange(Strings.StrMaterial);
            checkBoxWheelHeating.CheckState = CheckState.Unchecked;
            checkBoxSeatHeating.CheckState = CheckState.Unchecked;
            checkBoxSunroof.CheckState = CheckState.Unchecked;

            comboBoxDriverSeatTuning.Items.Clear();
            comboBoxOtherSeatsTuning.Items.Clear();
            comboBoxDriverSeatTuning.Items.AddRange(Strings.StrSeatsTuning);
            comboBoxOtherSeatsTuning.Items.AddRange(Strings.StrSeatsTuning);
        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            webBrowserFactoryInfo.Navigate(((TextBox)sender).Text);
        }//сделано
        private void textBoxModelInfo_TextChanged(object sender, EventArgs e)
        {
            webBrowserModelInfo.Navigate(((TextBox)sender).Text);
        }//сделано

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
                FactoryIndex = MainCarDatabase.FindFactory(comboBoxFactory.SelectedItem.ToString());
                if ((FactoryIndex == -1) && !(String.Equals(comboBoxFactory.SelectedItem.ToString(), ProjectStrings.InitFactoryName)))
                    MessageBox.Show(ProjectStrings.CarInfoWasNotFound);

                if (!panelFactoryInfo.Visible)
                {
                    panelModelInfo.Hide();
                    panelCarInfo.Hide();
                    panelFactoryInfo.Show();
                }

                if (FactoryIndex != -1)
                {
                    ModelIndex = -1;
                    LoadModelsList(MainCarDatabase.Factories[FactoryIndex]);
                    if ((FactoryIndex != -1) && !(String.Equals(comboBoxFactory.SelectedItem.ToString(), ProjectStrings.InitFactoryName)))
                        LoadFactoryInfo(MainCarDatabase.Factories[FactoryIndex]);
                }
                pictureBoxDelFactory.Enabled = true;
                pictureBoxAddModel.Enabled = true;

            }
            else
            {
                comboBoxFactory.ResetText();
                FactoryIndex = -1;
                pictureBoxDelFactory.Enabled = false;
            }

            comboBoxModel.SelectedIndex = -1;
            comboBoxGeneration.SelectedIndex = -1;
        }

        private void pictureBoxAddFactory_Click(object sender, EventArgs e)
        {

            if (MainCarDatabase.AddFactory(ProjectStrings.InitFactoryName)) //добавили в объект
            {
                FactoryIndex = MainCarDatabase.FindFactory(ProjectStrings.InitFactoryName);
                ModelIndex = -1;
                GenerationIndex = -1;
                int temp = comboBoxFactory.Items.Add(ProjectStrings.InitFactoryName);
                comboBoxGeneration.Items.Clear();
                comboBoxModel.Items.Clear();
                comboBoxFactory.SelectedIndex = temp;
                //добавили в список
            }
        }
        private void pictureBoxDelFactory_Click(object sender, EventArgs e)
        {

            if (MainCarDatabase.DeleteFactory(MainCarDatabase.Factories[FactoryIndex].FactoryName))//удалили объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Hide();

                int temp = comboBoxFactory.SelectedIndex;
                comboBoxFactory.SelectedIndex = -1;
                comboBoxFactory.Items.Remove(comboBoxFactory.Items[temp]);

                comboBoxFactory.ResetText();
                //удалили из списка
                comboBoxModel.SelectedIndex = -1;
                comboBoxModel.Items.Clear();


            }
        }

        private void pictureBoxAddModel_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.Factories[FactoryIndex].AddModel(ProjectStrings.InitModelName)) //добавили в объект
            {
                ModelIndex = MainCarDatabase.Factories[FactoryIndex].FindModel(ProjectStrings.InitModelName);
                int temp = comboBoxModel.Items.Add(ProjectStrings.InitModelName);
                comboBoxModel.SelectedIndex = temp;
                //добавили в список
            }
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxModelName.Clear();
            textBoxModelURL.Clear();

            if (((ComboBox)sender).SelectedIndex != -1) //если выбрали марку
            {
                ModelIndex = MainCarDatabase.Factories[FactoryIndex].FindModel(((ComboBox)sender).SelectedItem.ToString());
                if ((ModelIndex == -1) && !(String.Equals(((ComboBox)sender).SelectedItem.ToString(), ProjectStrings.InitModelName)))
                    MessageBox.Show(ProjectStrings.CarInfoWasNotFound);

                if (!panelModelInfo.Visible)
                {
                    panelModelInfo.Show();
                    panelCarInfo.Hide();
                    panelFactoryInfo.Hide();
                }
                /////////////////////////////////////////////////////////////////////////////////////////
                //   if (FactoryIndex != -1)
                //       LoadModelsList(MainCarDatabase.Factories[FactoryIndex]);
                ///////////////////////////////////////////нужно поменять на подгрузку листа поколений///
                if ((ModelIndex != -1) && !(String.Equals(((ComboBox)sender).SelectedItem.ToString(), ProjectStrings.InitModelName)))
                    LoadModelInfo(MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex]);
                pictureBoxDelModel.Enabled = true;
                pictureBoxAddGeneration.Enabled = true;
            }
            else //пустой пункт (после удаления или обновления, например)
            {
                comboBoxModel.ResetText();
                ModelIndex = -1;
                pictureBoxDelModel.Enabled = false;
            }
            comboBoxGeneration.SelectedIndex = -1;
        }

        private void comboBoxGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            //чистка полей
            ResetCarInfo();
            
            GenerationIndex = -1;
            if (((ComboBox)sender).SelectedIndex != -1) //если выбрали поколение
            {
                int Beg, End;
                OtherFuncs.RecogniseGenerParamsFromString(comboBoxGeneration.SelectedItem.ToString(), out Beg, out End);
                GenerationIndex = MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].FindGeneration(Beg, End);
                if ((GenerationIndex == -1) && !(String.Equals(comboBoxGeneration.SelectedItem.ToString(), ProjectStrings.InitGenerationName)))
                    MessageBox.Show(ProjectStrings.CarInfoWasNotFound);

                if (!panelCarInfo.Visible)
                {
                    panelModelInfo.Hide();
                    panelCarInfo.Show();
                    panelFactoryInfo.Hide();
                }

                if (GenerationIndex != -1)
                {
                    if ((GenerationIndex != -1) && !(String.Equals(comboBoxGeneration.SelectedItem.ToString(), ProjectStrings.InitGenerationName)))
                        LoadCarInfo(MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].Generations[GenerationIndex]);
                }
                pictureBoxDelGeneration.Enabled = true;
                //pictureBoxAddModel.Enabled = true;

            }
            else
            {
                comboBoxGeneration.ResetText();
                GenerationIndex = -1;
                pictureBoxDelGeneration.Enabled = false;
            }

            //comboBoxGeneration.SelectedIndex = -1;
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (GenerationIndex != -1)
            {
                int Beg, End;
                bool res;
                //OtherFuncs.RecogniseGenerParamsFromString(, out Beg, out End);
                res = Int32.TryParse(textBoxGenBegin.Text, out Beg); 
                res = res & Int32.TryParse(textBoxGenEnd.Text, out End);
                
                if (!res)
                {
                    MessageBox.Show(ProjectStrings.InvalidInput_Gen);
                    return;
                }

                if ((MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].FindGeneration(Beg, End) == GenerationIndex) || (MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].FindGeneration(Beg, End) == -1))
                {
                    ///сделать загрузку

                    SaveCarInfo(MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].Generations[GenerationIndex]);

                    // конец загрузки

                    comboBoxGeneration.Items[comboBoxGeneration.SelectedIndex] = textBoxGenBegin.Text.ToString() + "-" + textBoxGenEnd.Text.ToString();
                }
                else
                    MessageBox.Show(ProjectStrings.NameIsAlreadyUsed);

            }
            else
                if (ModelIndex != -1)
                {
                    if ((MainCarDatabase.Factories[FactoryIndex].FindModel(textBoxModelName.Text) == ModelIndex) || (MainCarDatabase.Factories[FactoryIndex].FindModel(textBoxModelName.Text) == -1))
                    {
                        MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].ModelName = textBoxModelName.Text;
                        MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].ModelURL = textBoxModelURL.Text;
                        comboBoxModel.Items[comboBoxModel.SelectedIndex] = textBoxModelName.Text;
                    }
                    else
                        MessageBox.Show(ProjectStrings.NameIsAlreadyUsed);
                }
                else
                    if (FactoryIndex != -1) //сохранение фабрики
                    {
                        if ((MainCarDatabase.FindFactory(textBoxFactoryName.Text) == FactoryIndex) || (MainCarDatabase.FindFactory(textBoxFactoryName.Text) == -1))
                        {
                            MainCarDatabase.Factories[FactoryIndex].FactoryName = textBoxFactoryName.Text;
                            MainCarDatabase.Factories[FactoryIndex].AboutInfoURL = textBoxURL.Text;
                            comboBoxFactory.Items[comboBoxFactory.SelectedIndex] = textBoxFactoryName.Text;
                        }
                        else
                            MessageBox.Show(ProjectStrings.NameIsAlreadyUsed);
                    }


        }

        private void pictureBoxDelModel_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.Factories[FactoryIndex].DeleteModel(MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].ModelName))//удалили объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Hide();

                int temp = comboBoxModel.SelectedIndex;
                comboBoxModel.SelectedIndex = -1;
                comboBoxModel.Items.Remove(comboBoxModel.Items[temp]);

                comboBoxModel.ResetText();
                //удалили из списка
                comboBoxGeneration.SelectedIndex = -1;
                comboBoxGeneration.Items.Clear();
            }
        }

        private void pictureBoxAddGeneration_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].AddGeneration(0, 0)) //добавили в объект
            {

                GenerationIndex = MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].FindGeneration(0, 0);
                int temp = comboBoxGeneration.Items.Add(OtherFuncs.FormGenerationName(0, 0));
                comboBoxGeneration.SelectedIndex = temp;
                //добавили в список
            }
        }

        private void pictureBoxDelGeneration_Click(object sender, EventArgs e)
        {
            if (MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].DeleteGeneration(MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].Generations[GenerationIndex].GenBegin,MainCarDatabase.Factories[FactoryIndex].Models[ModelIndex].Generations[GenerationIndex].GenEnd))//удалили объект
            {
                panelModelInfo.Hide();
                panelCarInfo.Hide();
                panelFactoryInfo.Hide();

                int temp = comboBoxGeneration.SelectedIndex;
                comboBoxGeneration.SelectedIndex = -1;
                comboBoxGeneration.Items.Remove(comboBoxGeneration.Items[temp]);

                comboBoxGeneration.ResetText();
                //удалили из списка
                comboBoxGeneration.SelectedIndex = -1;
                //comboBoxGeneration.Items.Clear();
            }
        }

    }
}
