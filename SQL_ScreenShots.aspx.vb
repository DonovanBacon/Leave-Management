
Partial Class SQL_ScreenShots
    Inherits System.Web.UI.Page

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("AuditLog.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
