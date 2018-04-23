using System;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            ASPxScheduler1.Start = new DateTime(2008, 7, 12);
        }
    }

    protected void ASPxScheduler1_AppointmentRowInserting(object sender, DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertingEventArgs e) {
        e.NewValues.Remove("ID");
    }

    protected void ASPxScheduler1_AppointmentRowInserted(object sender, DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertedEventArgs e) {
        e.KeyFieldValue = CarsXtraSchedulingProxy.LastInsertedAppointmentId;
    }

    protected void ASPxScheduler1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
        Appointment apt = (Appointment)e.Objects[0];
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        storage.SetAppointmentId(apt, CarsXtraSchedulingProxy.LastInsertedAppointmentId);
    }

}
