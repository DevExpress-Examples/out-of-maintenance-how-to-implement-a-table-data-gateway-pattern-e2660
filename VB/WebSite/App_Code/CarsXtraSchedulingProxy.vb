Imports System
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports CarsXtraSchedulingTableAdapters

<DataObjectAttribute()> _
Public NotInheritable Class CarsXtraSchedulingProxy

    Private Sub New()
    End Sub

    Private Shared carSchedulingTableAdapter As CarSchedulingTableAdapter
    Private Shared carTableAdapter As CarsTableAdapter

    Private Shared lastInsertedAppointmentId_Renamed As Integer

    Public Shared ReadOnly Property LastInsertedAppointmentId() As Integer
        Get
            Return lastInsertedAppointmentId_Renamed
        End Get
    End Property

    Shared Sub New()
        carSchedulingTableAdapter = New CarSchedulingTableAdapter()
        carTableAdapter = New CarsTableAdapter()
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select)> _
    Public Shared Function GetAppointments() As CarsXtraScheduling.CarSchedulingDataTable
        Return carSchedulingTableAdapter.GetData()
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select)> _
    Public Shared Function GetResources() As CarsXtraScheduling.CarsDataTable
        Return carTableAdapter.GetData()
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert)> _
    Public Shared Function InsertAppointment(ByVal CarId As String, ByVal Status? As Integer, ByVal Subject As String, ByVal Description As String, ByVal Label? As Integer, ByVal StartTime? As Date, ByVal EndTime? As Date, ByVal Location As String, ByVal AllDay As Boolean, ByVal EventType? As Integer, ByVal RecurrenceInfo As String, ByVal ReminderInfo As String, ByVal Price? As Decimal) As Boolean

        Dim rowsAffected As Integer = carSchedulingTableAdapter.Insert(CarId, Status, Subject, Description, Label, StartTime, EndTime, Location, AllDay, EventType, RecurrenceInfo, ReminderInfo, Price)

        UpdateLastInsertedAppointmentId()

        Return rowsAffected = 1
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update)> _
    Public Shared Function UpdateAppointment(ByVal CarId As String, ByVal Status? As Integer, ByVal Subject As String, ByVal Description As String, ByVal Label? As Integer, ByVal StartTime? As Date, ByVal EndTime? As Date, ByVal Location As String, ByVal AllDay As Boolean, ByVal EventType? As Integer, ByVal RecurrenceInfo As String, ByVal ReminderInfo As String, ByVal Price? As Decimal, ByVal ID As Integer) As Boolean

        Dim rowsAffected As Integer = carSchedulingTableAdapter.Update(CarId, Status, Subject, Description, Label, StartTime, EndTime, Location, AllDay, EventType, RecurrenceInfo, ReminderInfo, Price, ID)

        Return rowsAffected = 1
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete)> _
    Public Shared Function DeleteAppointment(ByVal ID As Integer) As Boolean
        Dim rowsAffected As Integer = carSchedulingTableAdapter.Delete(ID)

        Return rowsAffected = 1
    End Function

    Private Shared Sub UpdateLastInsertedAppointmentId()
        carSchedulingTableAdapter.Connection.Open()
        Using command As New SqlCommand("SELECT IDENT_CURRENT('CarScheduling')", carSchedulingTableAdapter.Connection)
            lastInsertedAppointmentId_Renamed = Convert.ToInt32(command.ExecuteScalar())
        End Using
        carSchedulingTableAdapter.Connection.Close()
    End Sub

End Class