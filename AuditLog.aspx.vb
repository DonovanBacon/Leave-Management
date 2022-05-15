Imports System.Data
Partial Class AuditLog
    Inherits System.Web.UI.Page
    Private mData As New cData

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("Employer.aspx")
        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Try
            Dim Ds As New DataSet

            Ds = mData.GetAuditLogs()


            grdAudit.DataSource = Ds.Tables(0)
            grdAudit.DataBind()

            'Use this for the demo when not able to connect to my DB

            'Dim Dttbl As New DataTable
            'Dttbl.Columns.Add("Audit Message")
            'Dttbl.Columns.Add("Inserted By")
            'Dttbl.Columns.Add("Inserted Date")

            'Dttbl.Rows.Add("User: Donovan Bacon, Submitted Sick Leave From: 2022-05-10 To: 2022-05-11 Reason: Testing", "Donovan Bacon", "2022-05-15")

            'grdAudit.DataSource = Dttbl
            'grdAudit.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShowSQLScreenshots_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("SQL_ScreenShots.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
