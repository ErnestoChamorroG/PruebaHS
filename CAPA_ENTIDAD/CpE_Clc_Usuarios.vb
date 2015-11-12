Public Class CpE_Clc_Usuarios
    Private _Rut As String
    Public Property Rut() As String
        Get
            Return _Rut
        End Get
        Set(ByVal value As String)
            _Rut = value
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

    Private _Sexo As String
    Public Property Sexo() As String
        Get
            Return _Sexo
        End Get
        Set(ByVal value As String)
            _Sexo = value
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

    Private _Contrasenia As String
    Public Property Contrasenia() As String
        Get
            Return _Contrasenia
        End Get
        Set(ByVal value As String)
            _Contrasenia = value
        End Set
    End Property

    Private _Correo As String
    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            _Correo = value
        End Set
    End Property

    Private _Especialidad As Integer
    Public Property Especialidad() As Integer
        Get
            Return _Especialidad
        End Get
        Set(ByVal value As Integer)
            _Especialidad = value
        End Set
    End Property
    Private _Especialidad1 As Integer
    Public Property Especialidad1() As Integer
        Get
            Return _Especialidad1
        End Get
        Set(ByVal value As Integer)
            _Especialidad1 = value
        End Set
    End Property

    Private _Perfil As Integer
    Public Property Perfil() As Integer
        Get
            Return _Perfil
        End Get
        Set(ByVal value As Integer)
            _Perfil = value
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

    Private _Fecha_Nacimiento As String
    Public Property Fecha_Nacimiento() As String
        Get
            Return _Fecha_Nacimiento
        End Get
        Set(ByVal value As String)
            _Fecha_Nacimiento = value
        End Set
    End Property


    'ENTIDADES TABLA ATENCION
    Private _DIA As Integer
    Public Property DIA() As Integer
        Get
            Return _DIA
        End Get
        Set(ByVal value As Integer)
            _DIA = value
        End Set
    End Property
    Private _HORA_INICIO_1 As Integer
    Public Property HORA_INICIO_1() As Integer
        Get
            Return _HORA_INICIO_1
        End Get
        Set(ByVal value As Integer)
            _HORA_INICIO_1 = value
        End Set
    End Property
    Private _MINUTO_INICIO_1 As Integer
    Public Property MINUTO_INICIO_1() As Integer
        Get
            Return _MINUTO_INICIO_1
        End Get
        Set(ByVal value As Integer)
            _MINUTO_INICIO_1 = value
        End Set
    End Property
    Private __HORA_TERMINO_2 As Integer
    Public Property HORA_TERMINO_2() As Integer
        Get
            Return __HORA_TERMINO_2
        End Get
        Set(ByVal value As Integer)
            __HORA_TERMINO_2 = value
        End Set
    End Property
    Private __MINUTO_TERMINO_2 As Integer
    Public Property MINUTO_TERMINO_2() As Integer
        Get
            Return __MINUTO_TERMINO_2
        End Get
        Set(ByVal value As Integer)
            __MINUTO_TERMINO_2 = value
        End Set
    End Property
    Private __HORA_INICIO_3 As Integer
    Public Property HORA_INICIO_3() As Integer
        Get
            Return __HORA_INICIO_3
        End Get
        Set(ByVal value As Integer)
            __HORA_INICIO_3 = value
        End Set
    End Property
    Private __MINUTO_INICIO_3 As Integer
    Public Property MINUTO_INICIO_3() As Integer
        Get
            Return __MINUTO_INICIO_3
        End Get
        Set(ByVal value As Integer)
            __MINUTO_INICIO_3 = value
        End Set
    End Property

    Private _HORA_TERMINO_4 As Integer
    Public Property HORA_TERMINO_4() As Integer
        Get
            Return _HORA_TERMINO_4
        End Get
        Set(ByVal value As Integer)
            _HORA_TERMINO_4 = value
        End Set
    End Property
    Private _MINUTO_TERMINO_4 As Integer
    Public Property MINUTO_TERMINO_4() As Integer
        Get
            Return _MINUTO_TERMINO_4
        End Get
        Set(ByVal value As Integer)
            _MINUTO_TERMINO_4 = value
        End Set
    End Property
End Class
