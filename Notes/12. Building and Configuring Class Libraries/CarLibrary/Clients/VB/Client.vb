'Cross Platform Inheritance

Imports CarLibrary

Module Module1
    Sub Main()
        Dim myMinivan As New MiniVan()
        myMinivan.TurboBoost()

        Dim mySportsCar As New SportsCar()
        mySportsCar.TurboBoost()

        Dim dreamCar As New PerformanceCar()
        dreamCar.TurboBoost()
        dreamCar.PetName = "Hank"

        Console.ReadLine()
    End Sub
End Module