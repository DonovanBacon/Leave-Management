
Partial Class Employer
    Inherits System.Web.UI.Page


    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("Employee.aspx")
        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub
End Class
