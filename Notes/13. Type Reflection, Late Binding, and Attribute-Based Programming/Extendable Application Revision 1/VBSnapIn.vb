Imports CommonSnappableTypes

<CompanyInfo(CompanyName:="Chucky's Software", CompanyURL:="www.ChuckySoft.com")>
Public Class VBSnapIn
    Implements IAppFunctionality

    Public Sub DoIt() Implements IAppFunctionality.DoIt
        Console.WriteLine("Installed VB SnapIn!")
    End Sub
End Class
