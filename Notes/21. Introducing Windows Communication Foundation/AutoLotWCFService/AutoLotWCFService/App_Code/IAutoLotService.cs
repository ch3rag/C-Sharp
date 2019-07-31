using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

[ServiceContract]
public interface IAutoLotService
{
    [OperationContract]
    void InsertCar(string make, string color, string petName);

    [OperationContract (Name="InsertCarWithDetails")]   // Web service do not support method overloading
    void InsertCar(InventoryRecord car);

    [OperationContract]
    List<InventoryRecord> GetInventory();
}