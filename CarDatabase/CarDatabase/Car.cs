using System;

public enum TBodyType {Седан,Универсал,Хетчбэк,Купе,Лимузин,Микроавтобус,Минивэн,Кабриолет}; //тип кузова
public enum TTransmission {Mechanic,Automatic,Robotic,Variator}; //трансмиссия
public enum TFuelType {Gasoline, Diesel,Gas, Hybrid,Electro, Turbo, };
public enum TClimateControl { Nothing, Сonditioner, ClimateControl_1s, ClimateControl_2s, ClimateControl_3s };
public enum TWheelAlignment { Nothing, AlignPlane_1, AlignPlane_2, AlignPlane_3};
public enum TMaterial {Other,Fabric,Velour,Leather,Combo};
public enum TElectricalWindows {No, AheadOnly, Full};
public enum TSeatsTuning {Nothing, ByHeight, Electrical, WithMemory};

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



public class CarInfo: TGeneration
{
    public TTransmission Transmission;
    public decimal EnginePower; //мощность 
    public int MaxSpeed;
    public decimal TimeTo100;

    public struct SizeParams
    {
        TBodyType BodyType; //тип кузова
        int Width;
        int Height;
        int MaxWeight;
        int FullEquipedWeight;
        int AmountOfDoors;
    }

    public struct Fuel
    {
        TFuelType FuelType; //тип топлива
        decimal FuelPer100_Town;
        decimal FuelPer100_Road;
    }

    public struct Security
    {
        bool ABS;
        bool ESP;
        bool AntiSlip;
        bool DriverAirbug;
        bool AheadPassengerAirbug;
    }

    public struct Comfort
    {
        bool CruiseControl;
        bool ServoWheel;
        bool OnBoardComputer;
        bool ParkingSystem;
        bool TintedGlass; //тонированные стёкла
    }

    public struct Comfort
    {
        bool CruiseControl;
        bool ServoWheel;
        bool OnBoardComputer;
        bool ParkingSystem;
        bool TintedGlass; //тонированные стёкла
        TClimateControl ClimateControl;
        TWheelAlignment WheelAlignment;
    }

    public struct Multimedia
    {
        bool AudioSystem;
        bool NavigationSystem;
    }

    public struct ObserveOpportunities
    {
        bool RainSensor;
        bool LightSensor;
        bool XenonLights;
        bool HeatingMirrors; //обогрев зеркал
        bool LightAutoWashing;
        bool ElectricMirrorTuning; //поворот зеркал
    }

    public struct AntiHijack
    {
        bool Signalization;
        bool CentralLock;
    }

    public struct Interior //интерьер, салон
    {
        int AmountOfSeats;
        TMaterial Material;
        bool WheelHeating;
        bool SeatHeating;
        bool Sunroof; //люк на крыше
        TSeatsTuning DriverSeatTuning;
        TSeatsTuning OtherSeatsTuning;
    }


    public CarInfo() //конструктор
	{
	}
}

