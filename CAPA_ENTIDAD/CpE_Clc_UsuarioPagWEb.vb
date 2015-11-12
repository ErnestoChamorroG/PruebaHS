Public Class CpE_Clc_UsuarioPagWEb
    Private _Rut As String
    Public Property Rut() As String
        Get
            Return _Rut
        End Get
        Set(ByVal value As String)
            _Rut = value
        End Set
    End Property

    Private _Nombres As String
    Public Property Nombres() As String
        Get
            Return _Nombres
        End Get
        Set(ByVal value As String)
            _Nombres = value
        End Set
    End Property

    Private _Apellidos As String
    Public Property Apellidos() As String
        Get
            Return _Apellidos
        End Get
        Set(ByVal value As String)
            _Apellidos = value
        End Set
    End Property

    Private _Direccion As String
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Private _Fono As Integer
    Public Property Fono() As Integer
        Get
            Return _Fono
        End Get
        Set(ByVal value As Integer)
            _Fono = value
        End Set
    End Property

    Private _Contrasena As String
    Public Property Contrasena() As String
        Get
            Return _Contrasena
        End Get
        Set(ByVal value As String)
            _Contrasena = value
        End Set
    End Property

    Private _IdPerfil As Integer
    Public Property IdPerfil() As Integer
        Get
            Return _IdPerfil
        End Get
        Set(ByVal value As Integer)
            _IdPerfil = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
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

    Private _Sexo As String
    Public Property Sexo() As String
        Get
            Return _Sexo
        End Get
        Set(ByVal value As String)
            _Sexo = value
        End Set
    End Property

    Private _FechaNac As String
    Public Property FechaNac() As String
        Get
            Return _FechaNac
        End Get
        Set(ByVal value As String)
            _FechaNac = value
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
