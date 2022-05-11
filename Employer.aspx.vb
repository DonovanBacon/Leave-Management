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

            Ds = mData.GetLeaveRequests() 'Session("User").User_FK)

            'grdLeaveRequests.AccessKey = "Leave_FK"
            grdLeaveRequests.DataSource = Ds.Tables(0)
            grdLeaveRequests.DataBind()

        Catch ex As Exception

        End Try
    End Sub
End Class
