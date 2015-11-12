Public Class CpE_Clc_Especialidad

    Private _NombreEsp As String
    Public Property NombreEsp() As String
        Get
            Return _NombreEsp
        End Get
        Set(ByVal value As String)
            _NombreEsp = value
        End Set
    End Property


    Private _NombreEspCons As String
    Public Property NombreEspCons() As String
        Get
            Return _NombreEspCons
        End Get
        Set(ByVal value As String)
            _NombreEspCons = value
        End Set
    End Property
    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property
End Class
