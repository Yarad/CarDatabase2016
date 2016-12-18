using System;
using System.Collections.Generic;

public enum TBodyType { Седан, Универсал, Хетчбэк, Купе, Лимузин, Микроавтобус, Минивэн, Кабриолет, Другое }; //тип кузова
public enum TTransmission { Mechanic, Automatic, Robotic, Variator }; //трансмиссия
public enum TFuelType { Gasoline, Diesel, Gas, Hybrid, Electro, Turbo, };
public enum TClimateControl { Nothing, Сonditioner, ClimateControl_1s, ClimateControl_2s, ClimateControl_3s };
public enum TWheelAlignment { Nothing, AlignPlane_1, AlignPlane_2, AlignPlane_Auto }; //регулировка руля
public enum TMaterial { Other, Fabric, Velour, Leather, Combo };
public enum TElectricalWindows { No, AheadOnly, Full };
public enum TSeatsTuning { Nothing, ByHeight, Electrical, WithMemory };

public class Strings
{
    public static string[] StrBodyType = { "Седан","Универсал", "Хетчбэк", "Купе", "Лимузин", "Микроавтобус", "Минивэн", "Кабриолет", "Другое" };
    public static string[] StrFuelType = {"Бензин","Дизель","Газ","Гибрид","Электричество","Ракетное топливо" };
    public static string[] StrTransmission = { "Механика", "Автомат", "Роботизированная", "Вариатор" };
    public static string[] StrClimateControl = { "Нет", "Кондиционер", "1-сезонный климат-контроль", "2-сезонный климат-контроль", "3-сезонный климат-контроль" };
    public static string[] StrWheelAlignment = { "Нет", "Регулировка в 1 пл-сти", "Регулировка в 2 пл-стях", "Регулировка в 3 пл-стях" };
    public static string[] StrMaterial = { "Другой", "Ткань", "Велюр", "Кожа", "Комбинированный" };
    public static string[] StrElectricalWindows = {"Нет", "Передние окна","Все окна"};
    public static string[] StrSeatsTuning = {"Нет","По высоте","Электрические","С запомнанием\nположения" };

    //public static int 

    public static TTransmission TransmissionStrToType(string InputStr)
    {
        for (int i = 0; i < StrTransmission.Length; i++)
            if (String.Equals(StrTransmission[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TTransmission.Mechanic; break;
                    case 1: return TTransmission.Automatic; break;
                    case 2: return TTransmission.Robotic; break;
                    case 3: return TTransmission.Variator; break;
                }
            }
        return TTransmission.Mechanic;
    }

    public static TBodyType BodyTypeStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrBodyType.Length; i++)
            if (String.Equals(StrBodyType[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TBodyType.Седан;  break;
                    case 1: return TBodyType.Универсал ; break;
                    case 2: return TBodyType.Хетчбэк; break;
                    case 3: return TBodyType.Купе;  break;
                    case 4: return TBodyType.Лимузин;  break;
                    case 5: return TBodyType.Микроавтобус;  break;
                    case 6: return TBodyType.Минивэн;  break;
                    case 7: return TBodyType.Кабриолет;  break;
                    case 8: return TBodyType.Другое; break;
                }
            }
        return TBodyType.Седан;
    }

    public static TFuelType FuelTypeStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrFuelType.Length; i++)
            if (String.Equals(StrFuelType[i], InputStr))
            {
                switch (i)
                {
                    case 1: return TFuelType.Diesel; break;
                    case 4: return TFuelType.Electro; break;
                    case 2: return TFuelType.Gas; break;
                    case 0: return TFuelType.Gasoline; break;
                    case 3: return TFuelType.Hybrid; break;
                    case 5: return TFuelType.Turbo; break;
                    
                }
            }
        return TFuelType.Gasoline;
    }

    public static TClimateControl ClimateControlStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrFuelType.Length; i++)
            if (String.Equals(StrFuelType[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TClimateControl.Nothing; break;
                    case 1: return TClimateControl.Сonditioner; break;
                    case 2: return TClimateControl.ClimateControl_1s; break;
                    case 3: return TClimateControl.ClimateControl_2s; break;
                    case 4: return TClimateControl.ClimateControl_3s; break;
                }
            }
        return TClimateControl.Nothing;
    }
    
    public static TWheelAlignment WheelAlignmentStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrFuelType.Length; i++)
            if (String.Equals(StrFuelType[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TWheelAlignment.Nothing; break;
                    case 1: return TWheelAlignment.AlignPlane_1; break;
                    case 2: return TWheelAlignment.AlignPlane_2; break;
                    case 3: return TWheelAlignment.AlignPlane_Auto; break;
                }
            }
        return TWheelAlignment.Nothing;
    }

    public static TMaterial MaterialStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrMaterial.Length; i++)
            if (String.Equals(StrMaterial[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TMaterial.Other; break;
                    case 1: return TMaterial.Fabric; break;
                    case 2: return TMaterial.Velour; break;
                    case 3: return TMaterial.Leather; break;
                    case 4: return TMaterial.Combo; break;
                }
            }
        return TMaterial.Other;
    }

    public static TSeatsTuning SeatTuningStrToType(string InputStr)
    {
        int i;
        for (i = 0; i < StrSeatsTuning.Length; i++)
            if (String.Equals(StrSeatsTuning[i], InputStr))
            {
                switch (i)
                {
                    case 0: return TSeatsTuning.Nothing; break;
                    case 1: return TSeatsTuning.ByHeight; break;
                    case 2: return TSeatsTuning.Electrical; break;
                    case 3: return TSeatsTuning.WithMemory; break;
                }
            }
        return TSeatsTuning.ByHeight;
    }

}

[Serializable]
public class TFactory
{
    public string FactoryName;
    public string AboutInfoURL;
    public List<TModel> Models;

    public TFactory(string FactoryName)
    {
        this.FactoryName = FactoryName;
        Models = new List<TModel>();
    }

    public bool AddModel(string ModelName)
    {
        for (int i = 0; i < Models.Count; i++)
            if (Models[i].ModelName == ModelName)
                return false;
        Models.Add(new TModel(ModelName));

        return true;
    }
    public int FindModel(string InputStr)
    {
        if (Models == null) return -1;

        for (int i = 0; i < Models.Count; i++)
            if (String.Equals(Models[i].ModelName, InputStr))
                return i;
        return -1;
    }

    public bool DeleteModel(string ModelName)
    {
        int res = FindModel(ModelName);
        if (res != -1)
        {
            Models.RemoveRange(res, 1);
            return true;
        }
        else
            return false;

    }
}

[Serializable]
public class TModel
{
    public string ModelName;
    public string ModelURL;
    public List<TGeneration> Generations;

    public TModel(string ModelName)
    {
        this.ModelName = ModelName;
        Generations = new List<TGeneration>();
    }

    public bool AddGeneration(int Beg, int End)
    {
        for (int i = 0; i < Generations.Count; i++)
            if (OtherFuncs.IsInRange(Beg, End, Generations[i].GenBegin, Generations[i].GenEnd))
                return false;
        Generations.Add(new TGeneration(Beg,End));

        return true;
        
    }
    public int FindGeneration(int Beg, int End)
    {
        if (Generations == null) return -1;

        for (int i = 0; i < Generations.Count; i++)
            if ((Generations[i].GenBegin==Beg)&& (Generations[i].GenEnd==End))
                return i;
        return -1;
    }
    public bool DeleteGeneration(int Beg, int End)
    {
        int res = FindGeneration(Beg,End);
        if (res != -1)
        {
            Generations.RemoveRange(res, 1);
            return true;
        }
        else
            return false;

    }

}

[Serializable]
public class TGeneration
{
    public int GenBegin;
    public int GenEnd;
    public TCarInfo CurrCar;

    public TGeneration(int Begin, int End)
    {
        this.GenBegin = Begin;
        this.GenEnd = End;
        CurrCar = new TCarInfo();
    }
}


//структуры для класса
[Serializable]
public struct MainParams
{
    public TTransmission Transmission;
    public double EnginePower; //мощность 
    public int MaxSpeed;
    public double TimeTo100;    
}

[Serializable]
public struct SizeParams
{
    public TBodyType BodyType; //тип кузова
    public int Length;
    public int Width;
    public int Height;
    public int MaxWeight;
    public int FullEquipedWeight;
    public int AmountOfDoors;
}

[Serializable]
public struct Fuel
{
    public TFuelType FuelType; //тип топлива
    public decimal FuelPer100_Town;
    public decimal FuelPer100_Road;
}

[Serializable]
public struct Security
{
    public bool ABS;
    public bool ESP;
    public bool AntiSlip;
    public bool DriverAirbag;
    public bool AheadPassengerAirbag;
}

[Serializable]
public struct Comfort
{
    public bool CruiseControl;
    public bool ServoWheel;
    public bool OnBoardComputer;
    public bool ParkingSystem;
    public bool TintedGlass; //тонированные стёкла
    public TClimateControl ClimateControl;
    public TWheelAlignment WheelAlignment;
}

[Serializable]
public struct Multimedia
{
    public bool AudioSystem;
    public bool NavigationSystem;
}

[Serializable]
public struct ObserveOpportunities
{
    public bool RainSensor;
    public bool LightSensor;
    public bool XenonLights;
    public bool HeatingMirrors; //обогрев зеркал
    public bool LightAutoWashing;
    public bool ElectricMirrorTuning; //поворот зеркал
}

[Serializable]
public struct AntiHijack
{
    public bool Signalisation;
    public bool CentralLock;
}

[Serializable]
public struct Interior //интерьер, салон
{
    public int AmountOfSeats;
    public TMaterial Material;
    public bool WheelHeating;
    public bool SeatHeating;
    public bool Sunroof; //люк на крыше
    public TSeatsTuning DriverSeatTuning;
    public TSeatsTuning OtherSeatsTuning;
}

//конец структур для класса

[Serializable]
public class TCarInfo
{
    public MainParams MainParams;
    public SizeParams SizeParams;
    public Fuel Fuel;
    public Security Security;
    public Comfort Comfort;
    public Multimedia Multimedia;
    public ObserveOpportunities ObserveOpportunities;
    public AntiHijack AntiHijack;
    public Interior Interior;

    public TCarInfo() //конструктор
    {
        MainParams.Transmission = TTransmission.Mechanic;
        MainParams.EnginePower = 0.0; //мощность 
        MainParams.MaxSpeed = 0;
        MainParams.TimeTo100 = 0.0;
        
        SizeParams.BodyType = TBodyType.Другое; //тип кузова
        SizeParams.Length = 0;
        SizeParams.Width = 0;
        SizeParams.Height = 0;
        SizeParams.MaxWeight = 0;
        SizeParams.FullEquipedWeight = 0;
        SizeParams.AmountOfDoors = 0;
        
        Fuel.FuelType = TFuelType.Gasoline; //тип топлива
        Fuel.FuelPer100_Town = 0;
        Fuel.FuelPer100_Road = 0;
        
        Security.ABS = false;
        Security.ESP = false;
        Security.AntiSlip = false;
        Security.DriverAirbag = false;
        Security.AheadPassengerAirbag = false;
        Comfort.CruiseControl = false;
        Comfort.ServoWheel = false;
        Comfort.OnBoardComputer = false;
        Comfort.ParkingSystem = false;
        Comfort.TintedGlass = false; //тонированные стёкла
        Comfort.ClimateControl = TClimateControl.Nothing;
        Comfort.WheelAlignment = TWheelAlignment.AlignPlane_1;
        Multimedia.AudioSystem = false;
        Multimedia.NavigationSystem = false;
        ObserveOpportunities.RainSensor = false;
        ObserveOpportunities.LightSensor = false;
        ObserveOpportunities.XenonLights = false;
        ObserveOpportunities.HeatingMirrors = false; //обогрев зеркал
        ObserveOpportunities.LightAutoWashing = false;
        ObserveOpportunities.ElectricMirrorTuning = false; //поворот зеркал
        AntiHijack.Signalisation = false;
        AntiHijack.CentralLock = false;
        Interior.AmountOfSeats = 0;
        Interior.Material = TMaterial.Other;
        Interior.WheelHeating = false;
        Interior.SeatHeating = false;
        Interior.Sunroof = false; //люк на крыше
        Interior.DriverSeatTuning = TSeatsTuning.Nothing;
        Interior.OtherSeatsTuning = TSeatsTuning.Nothing;
    }
}

