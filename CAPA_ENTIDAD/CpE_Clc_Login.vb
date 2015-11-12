Public Class CpE_Clc_Login
    Private _Rut As String
    Public Property Rut() As String
        Get
            Return _Rut
        End Get
        Set(ByVal value As String)
            _Rut = value
        End Set
    End Property

    Private _IdLogin As String
    Public Property IdLogin() As String
        Get
            Return _IdLogin
        End Get
        Set(ByVal value As String)
            _IdLogin = value
        End Set
    End Property

    Private _Rut1 As String
    Public Property Rut1() As String
        Get
            Return _Rut1
        End Get
        Set(ByVal value As String)
            _Rut1 = value
        End Set
    End Property
End Class
