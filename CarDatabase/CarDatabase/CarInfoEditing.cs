using System;
using System.Runtime.Serialization.Formatters.Binary;//для преобразования объекта в байтовые данные
using System.IO;


[Serializable]
public class CarInfoDatabase
{
    private TFactory[] Factories;

    public bool AddFactory(string FactoryName)
    {
        for (int i = 0; i < Factories.Length; i++)
            if (Factories[i].FactoryName == FactoryName)
                return false;
        Factories[Factories.Length] = new TFactory(FactoryName);

        return true;
    }

    public bool SaveChanges()
    {
        NetWork CurrTransaction = new NetWork();
        BinaryFormatter binFormat = new BinaryFormatter(); //разновидность массива байт для серриализации

        using (Stream fStream = new FileStream(CurrTransaction.FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            binFormat.Serialize(fStream, this);
        }
        if (CurrTransaction.UploadFile())
        {
            CurrTransaction.DeleteFile(); ;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool UpdateInfo()
    {
        NetWork CurrTransaction = new NetWork();
        BinaryFormatter binFormat = new BinaryFormatter(); //разновидность массива байт для серриализации
        CarInfoDatabase LoadedDatabase;

        if (CurrTransaction.DownloadFile())
        {
            using (Stream fStream = new FileStream(CurrTransaction.FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                LoadedDatabase = (CarInfoDatabase)binFormat.Deserialize(fStream);
            }

            this.Factories = LoadedDatabase.Factories;
            CurrTransaction.DeleteFile();
            return true;
        }
        else
            return false;
    }
    
    public CarInfoDatabase()
    {


    }
}
