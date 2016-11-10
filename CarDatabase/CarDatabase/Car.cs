using System;

public enum TBodyType { Седан, Универсал, Хетчбэк, Купе, Лимузин, Микроавтобус, Минивэн, Кабриолет, Другое }; //тип кузова
public enum TTransmission { Mechanic, Automatic, Robotic, Variator }; //трансмиссия
public enum TFuelType { Gasoline, Diesel, Gas, Hybrid, Electro, Turbo, };
public enum TClimateControl { Nothing, Сonditioner, ClimateControl_1s, ClimateControl_2s, ClimateControl_3s };
public enum TWheelAlignment { Nothing, AlignPlane_1, AlignPlane_2, AlignPlane_Auto }; //регулировка руля
public enum TMaterial { Other, Fabric, Velour, Leather, Combo };
public enum TElectricalWindows { No, AheadOnly, Full };
public enum TSeatsTuning { Nothing, ByHeight, Electrical, WithMemory };

public class TFactory
{
    public string FactoryName;
}

public class TModel : TFactory
{
    public string ModelName;
}

public class TGeneration : TModel
{
    public int GenBegin;
    public int GenEnd;
}


//структуры для класса
public struct SizeParams
{
    public TBodyType BodyType; //тип кузова
    public int Width;
    public int Height;
    public int MaxWeight;
    public int FullEquipedWeight;
    public int AmountOfDoors;
}

public struct Fuel
{
    public TFuelType FuelType; //тип топлива
    public decimal FuelPer100_Town;
    public decimal FuelPer100_Road;
}

public struct Security
{
    public bool ABS;
    public bool ESP;
    public bool AntiSlip;
    public bool DriverAirbug;
    public bool AheadPassengerAirbug;
}

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

public struct Multimedia
{
    public bool AudioSystem;
    public bool NavigationSystem;
}

public struct ObserveOpportunities
{
    public bool RainSensor;
    public bool LightSensor;
    public bool XenonLights;
    public bool HeatingMirrors; //обогрев зеркал
    public bool LightAutoWashing;
    public bool ElectricMirrorTuning; //поворот зеркал
}

public struct AntiHijack
{
    public bool Signalization;
    public bool CentralLock;
}

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

public class CarInfo : TGeneration
{
    public TTransmission Transmission;
    public double EnginePower; //мощность 
    public int MaxSpeed;
    public double TimeTo100;

    public SizeParams SizeParams;
    public Fuel Fuel;
    public Security Security;
    public Comfort Comfort;
    public Multimedia Multimedia;
    public ObserveOpportunities ObserveOpportunities;
    public AntiHijack AntiHijack;
    public Interior Interior;

    public CarInfo() //конструктор
    {
        FactoryName = "";
        ModelName = "";
        GenBegin = 0;
        GenEnd = 0;
        Transmission = TTransmission.Mechanic;
        EnginePower = 0.0; //мощность 
        MaxSpeed = 0;
        TimeTo100 = 0.0;
        
        SizeParams.BodyType = TBodyType.Другое; //тип кузова
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
        Security.DriverAirbug = false;
        Security.AheadPassengerAirbug = false;
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
        AntiHijack.Signalization = false;
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

