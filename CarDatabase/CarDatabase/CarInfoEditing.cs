using System;

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

    public CarInfoDatabase()
    {


    }
}
