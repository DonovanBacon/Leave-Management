Imports System.IO
Imports System.Data
Partial Class Employer
    Inherits System.Web.UI.Page
    Public mData As New cData

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("Employee.aspx")
        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Try
            Dim Ds As New DataSet

            Ds = mData.GetLeaveRequests()


            grdLeaveRequests.DataSource = Ds.Tables(0)
            grdLeaveRequests.DataBind()

            'Use this for the demo when not able to connect to my DB

            'Dim Dttbl As New DataTable
            'Dttbl.Columns.Add("Full Name")
            'Dttbl.Columns.Add("Start Date")
            'Dttbl.Columns.Add("End Date")
            'Dttbl.Columns.Add("Reason")
            'Dttbl.Columns.Add("Date submitted")

            'Dttbl.Rows.Add("Donovan Bacon", "2022-05-03", "2022-05-05", "Testing Sick Leave", "2022-05-15 16:37:59.947")
            'Dttbl.Rows.Add("Donovan Bacon", "2022-05-10", "2022-05-11", "Testing Annual Leave", "2022-05-14 14:49:12.283")

            'grdLeaveRequests.DataSource = Dttbl
            'grdLeaveRequests.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAudit_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("AuditLog.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
