Imports ModuleDefinition

<ComapanyInformation("ZoroWorks", "www.zoroworks.com")>
Public Class VBModule
    Implements IAppFunctionality
    Sub DoIt() Implements ModuleDefinition.IAppFunctionality.DoIt
        Console.WriteLine("VB Module is doing it's work")
    End Sub
End Class
