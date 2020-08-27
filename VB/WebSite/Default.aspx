<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraScheduler" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" 
            AppointmentDataSourceID="ObjectDataSourceAppointments" 
            ResourceDataSourceID="ObjectDataSourceResources"
            onappointmentrowinserting="ASPxScheduler1_AppointmentRowInserting" 
            onappointmentrowinserted="ASPxScheduler1_AppointmentRowInserted" 
            onappointmentsinserted="ASPxScheduler1_AppointmentsInserted">

            <Storage>
                <Appointments ResourceSharing="True">

                    <Mappings 
                        AllDay="AllDay" 
                        AppointmentId="ID" 
                        Description="Description" 
                        End="EndTime" 
                        Label="Label" 
                        Location="Location" 
                        RecurrenceInfo="RecurrenceInfo" 
                        ReminderInfo="ReminderInfo" 
                        ResourceId="CarId"
                        Start="StartTime" 
                        Status="Status" 
                        Subject="Subject" 
                        Type="EventType" />

                    <CustomFieldMappings>
                        <dxwschs:ASPxAppointmentCustomFieldMapping Member="Price" Name="Field1" />
                    </CustomFieldMappings>

                </Appointments>

                <Resources>
                    <Mappings 
                        ResourceId="ID"  
                        Caption="Model" />
                </Resources>
            </Storage>

        </dxwschs:ASPxScheduler>

        <asp:ObjectDataSource ID="ObjectDataSourceAppointments" runat="server" 
            TypeName="CarsXtraSchedulingProxy"
            SelectMethod="GetAppointments" 
            InsertMethod="InsertAppointment"
            UpdateMethod="UpdateAppointment"
            DeleteMethod="DeleteAppointment">
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjectDataSourceResources" runat="server" 
            TypeName="CarsXtraSchedulingProxy"
            SelectMethod="GetResources">
        </asp:ObjectDataSource>

    </div>
    </form>
</body>
</html>