using System;
using System.Runtime.Serialization.Formatters.Binary;//для преобразования объекта в байтовые данные
using System.IO;
using System.Collections.Generic;


[Serializable]
public class CarInfoDatabase
{
    public List<TFactory> Factories;

    public bool AddFactory(string FactoryName)
    {
        for (int i = 0; i < Factories.Count; i++)
            if (Factories[i].FactoryName == FactoryName)
                return false;

        Factories.Add(new TFactory(FactoryName));
        
        return true;
    }

    public int FindFactory(string InputStr)
    {
        if (Factories == null) return -1;

        for (int i = 0; i < Factories.Count; i++)
            if (String.Equals(Factories[i].FactoryName,InputStr))
                return i;
            return -1;
    }

    public bool DeleteFactory(string FactoryName)
    {
        int res = FindFactory(FactoryName);
        if (res != -1)
        {
            Factories.RemoveRange(res,1);
            return true;
        }
        else
            return false;

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
            //CurrTransaction.DeleteFile(); ;
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
            using (Stream fStream = new FileStream(CurrTransaction.FILE_NAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                LoadedDatabase = (CarInfoDatabase)binFormat.Deserialize(fStream);

                fStream.Dispose();
                //fStream.Close();
            }
            

            this.Factories = LoadedDatabase.Factories;
            //CurrTransaction.DeleteFile();  файл не удаляем, но держим всегда под боком ... в тепле и уюте
            //ему ведь неприятно ... только представь: Ррраз ... и ты его больше не увидишь
           // System.IO.File.SetAttributes(CurrTransaction.FILE_NAME, System.IO.FileAttributes.Normal);
            //лучше его спрятать. И нас никто и никогда не разлучит
            return true;
        }
        else
        {
            //добавить подгрузку из файла
            return false;
        }
    }
    
    public CarInfoDatabase()
    {
        Factories = new List<TFactory>();
    }
}
