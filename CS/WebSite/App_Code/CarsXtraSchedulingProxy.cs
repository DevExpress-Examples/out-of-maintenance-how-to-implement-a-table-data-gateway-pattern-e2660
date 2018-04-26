using System;
using System.Data.SqlClient;
using System.ComponentModel;
using CarsXtraSchedulingTableAdapters;

[DataObjectAttribute()]
public static class CarsXtraSchedulingProxy {
    private static CarSchedulingTableAdapter carSchedulingTableAdapter;
    private static CarsTableAdapter carTableAdapter;
    private static int lastInsertedAppointmentId;

    public static int LastInsertedAppointmentId { get { return lastInsertedAppointmentId; } }

    static CarsXtraSchedulingProxy() {
        carSchedulingTableAdapter = new CarSchedulingTableAdapter();
        carTableAdapter = new CarsTableAdapter();
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select)]
    public static CarsXtraScheduling.CarSchedulingDataTable GetAppointments() {
        return carSchedulingTableAdapter.GetData();
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Select)]
    public static CarsXtraScheduling.CarsDataTable GetResources() {
        return carTableAdapter.GetData();
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Insert)]
    public static bool InsertAppointment(string CarId,
                                         int? Status,
                                         string Subject,
                                         string Description,
                                         int? Label,
                                         DateTime? StartTime,
                                         DateTime? EndTime,
                                         string Location,
                                         bool AllDay,
                                         int? EventType,
                                         string RecurrenceInfo,
                                         string ReminderInfo,
                                         decimal? Price) {

        int rowsAffected = carSchedulingTableAdapter.Insert(CarId,
                                                            Status,
                                                            Subject,
                                                            Description,
                                                            Label,
                                                            StartTime,
                                                            EndTime,
                                                            Location,
                                                            AllDay,
                                                            EventType,
                                                            RecurrenceInfo,
                                                            ReminderInfo,
                                                            Price);

        UpdateLastInsertedAppointmentId();

        return rowsAffected == 1;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Update)]
    public static bool UpdateAppointment(string CarId,
                                         int? Status,
                                         string Subject,
                                         string Description,
                                         int? Label,
                                         DateTime? StartTime,
                                         DateTime? EndTime,
                                         string Location,
                                         bool AllDay,
                                         int? EventType,
                                         string RecurrenceInfo,
                                         string ReminderInfo,
                                         decimal? Price,
                                         int ID) {

        int rowsAffected = carSchedulingTableAdapter.Update(CarId,
                                                            Status,
                                                            Subject,
                                                            Description,
                                                            Label,
                                                            StartTime,
                                                            EndTime,
                                                            Location,
                                                            AllDay,
                                                            EventType,
                                                            RecurrenceInfo,
                                                            ReminderInfo,
                                                            Price,
                                                            ID);

        return rowsAffected == 1;
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Delete)]
    public static bool DeleteAppointment(int ID) {
        int rowsAffected = carSchedulingTableAdapter.Delete(ID);

        return rowsAffected == 1;
    }

    private static void UpdateLastInsertedAppointmentId() {
        carSchedulingTableAdapter.Connection.Open();
        using (SqlCommand command = new SqlCommand("SELECT IDENT_CURRENT('CarScheduling')", carSchedulingTableAdapter.Connection)) {
            lastInsertedAppointmentId = Convert.ToInt32(command.ExecuteScalar());
        }
        carSchedulingTableAdapter.Connection.Close();
    }

}