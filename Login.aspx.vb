Imports System.Data
Partial Class Login
    Inherits System.Web.UI.Page
    Private mData As New cData

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim username As String
            Dim password As String

            username = txtUsername.Text
            password = txtPassword.Text

            If username = "" Or password = "" Then
                MsgBox("Username or password is empty", vbOKOnly, "Empty fields")
            Else

                Session("User") = New cUser(username)

                If password <> Session("User").Password.ToString Or username <> Session("User").Username.ToString Then
                    MsgBox("Username or password is incorrect", vbOKOnly, "Incorrect username or password")
                Else
                    Response.Redirect("Employee.aspx")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
