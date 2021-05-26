# How to implement a Table Data Gateway pattern


<p>This example demonstrates how to implement a Table Data Gateway pattern.</p><p>From time to time we receive the question from our customers:</p><p>- Is it possible to bind ASPxScheduler to DataSet?</p><p>Due to the web environment limitation, the capability to bind ASPxScheduler directly is not supported. Basically, there is no built-in mechanism to persist a datasource collection between postbacks. Therefore, you should always use a datasource component (e. g. SqlDataSource or ObjectDataSource) to bind ASPxScheduler to a datasource. The ObjectDataSource component is the most appropriate for custom-binding scenarios. You should simply define it on a web page and point its *Method properties to the corresponding methods of a class (CarsXtraSchedulingProxy in this example) that is specified via the ObjectDataSource.TypeName property. In our scenario, this class methods, should delegate handling to the corresponding methods of TableAdapter that was generated along with a DataSet object.</p><p>Also, please note the way in which the Identity field value is retrieved from the database (see the CarsXtraSchedulingProxy.UpdateLastInsertedAppointmentId() method) and redirected to ASPxSchedulerStorage (see the Default.aspx.cs code-behind methods).</p><p>To test this example locally, you should setup our CarsXtraScheduling sample database in your SQL Server instance (you can download the corresponding *.sql scripts from the <a href="https://www.devexpress.com/Support/Center/p/E215">How to bind ASPxScheduler to MS SQL Server database</a> example).<br />
<br />
</p>

<br/>


