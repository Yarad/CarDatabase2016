using System;
using System.Net;
using System.IO;
using BytesRoad.Net.Ftp;
using BytesRoad.Net.Sockets;


public class NetWork
{
    private int TimeoutFTP = 30000; //Таймаут.
    private string MainDatabaseAdress = "http://svyatovved.ru/OtherFiles/CarDatabase/MainCarInfo.txt";
    private string FILE_NAME = "MainDatabase.txt";
    private string FTP_FILE_PATH = "/public_html/OtherFiles/CarDatabase/";
    private string FTP_SERVER = "betty.timeweb.ru";
    private int FTP_PORT = 21;
    private string FTP_USER = "cr74999";
    private string FTP_PASSWORD = "xbi3OswnsUnN";
    
    private FtpClient client = new FtpClient();
    private WebClient CurrClient = new WebClient();

    public bool UploadFile()
    {
        
        bool result = true;
        try
        {
            client.Connect(TimeoutFTP, FTP_SERVER, FTP_PORT);
            client.Login(TimeoutFTP, FTP_USER, FTP_PASSWORD);
            client.PutFile(TimeoutFTP, FTP_FILE_PATH + FILE_NAME, FILE_NAME);
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }
    
    public bool DownloadFile()
    {
        bool result;
        CurrClient.DownloadFile(MainDatabaseAdress, FILE_NAME);
        
        result = File.Exists(FILE_NAME);
        if (result)
            System.IO.File.SetAttributes(FILE_NAME, System.IO.FileAttributes.Hidden);
        return result;
    }

    ~NetWork()
    {
        File.Delete(FILE_NAME);
    }
}
