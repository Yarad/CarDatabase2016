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
}

public class ProjectStrings
{
    public static string WasSaved = "Успешно сохранено.";
    public static string WasNotSaved = "Ошибка сохранения на сервер.";

    public static string CarInfoWasNotFound = "Ошибка базы данных. Информация не найдена";

    public static string InitFactoryName = "<название марки>";
    
}