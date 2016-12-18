using System;

public class OtherFuncs
{
    public static bool IsInRange(int Input, int RangeBeg, int RangeEnd)
    {
        if ((Input <= RangeEnd) && (Input >= RangeBeg)) 
            return true;
        else
            return false;
    }

    public static bool IsInRange(int InputBeg, int InputEnd, int RangeBeg, int RangeEnd)
    {
        if (IsInRange(InputBeg,RangeBeg,RangeEnd) || IsInRange(InputEnd,RangeBeg,RangeEnd) || ((InputBeg <= RangeBeg) && (InputEnd >= RangeBeg)))
            return true;
        else
            return false;
    }

    public static string FormGenerationName(int Beg, int End)
    {
        return (Beg.ToString() + "-" + End.ToString());
    }

    public static void RecogniseGenerParamsFromString(string Input, out int Beg, out int End)
    {
        Beg = -1;
        End = -1;
        string[] SplittedStrings;
        SplittedStrings = Input.Split('-');
        Int32.TryParse(SplittedStrings[0],out Beg);
        Int32.TryParse(SplittedStrings[1], out End);
    }
}

public class ProjectStrings
{
    public static string WasSaved = "Успешно сохранено.";
    public static string WasNotSaved = "Ошибка сохранения на сервер.";

    public static string CarInfoWasNotFound = "Ошибка базы данных. Информация не найдена";
    public static string NameIsAlreadyUsed = "Имя занято";
    public static string InvalidInput_Gen = "Некорректные данные в информации о поколении";
    public static string InvalidInput_EnginePower = "Некорректные данные в информации о мощности двигателя";
    public static string InvalidInput_MaxSpeed= "Некорректные данные в информации о максимально допустимой скорости";
    public static string InvalidInput_TimeTo100 = "Некорректные данные в информации о времени разгона до 100 км/ч";
    public static string InvalidInput_Length = "Некорректные данные в информации о длине авто";
    public static string InvalidInput_Width = "Некорректные данные в информации о ширине авто";
    public static string InvalidInput_Height = "Некорректные данные в информации о высоте авто";
    public static string InvalidInput_MaxWeight = "Некорректные данные в информации о максимальном весе авто";
    public static string InvalidInput_FullEquipedWeight = "Некорректные данные в информации о весе авто в полном снаряжении";
    public static string InvalidInput_AmountOfDoors = "Некорректные данные в информации о кол-ве дверей авто";
    public static string InvalidInput_FuelPer100_Town = "Некорректные данные в информации о расходе топлива на 100км. на трассе";
    public static string InvalidInput_FuelPer100_Road = "Некорректные данные в информации о расходе топлива на 100км. в дороге";
    public static string InvalidInput_AmountOfSeats = "Некорректные данные в информации о кол-ве мест для сидения";


    public static string InitFactoryName = "<название марки>";
    public static string InitModelName = "<название модели>";
    public static string InitGenerationName = "0-0";
    
}