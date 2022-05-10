
Partial Class Employee
    Inherits System.Web.UI.Page
    Private TotalLeaveDays As Integer = 7

    Private Sub clndStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles clndStartDate.SelectionChanged
        Try

            Dim RemainingLeave As String
            Dim LeaveDif As Integer

            If Session("EndDate") IsNot Nothing Then
                LeaveDif = DateAndTime.DateDiff("d", Session("EndDate"), clndStartDate.SelectedDate)
                RemainingLeave = TotalLeaveDays - TotalLeaveDays

                lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"

            End If

            Session("StartDate") = clndStartDate.SelectedDate

        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub

    Private Sub clndEndDate_SelectionChanged(sender As Object, e As EventArgs) Handles clndEndDate.SelectionChanged
        Try

            Dim RemainingLeave As String
            Dim LeaveDif As Integer

            If Session("StartDate") IsNot Nothing Then
                LeaveDif = DateAndTime.DateDiff("d", Session("StartDate"), clndEndDate.SelectedDate)
                RemainingLeave = TotalLeaveDays - LeaveDif

                lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"

            End If

            Session("EndDate") = clndEndDate.SelectedDate

        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub

    Private Sub lstbxTypeOfLeave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxTypeOfLeave.SelectedIndexChanged
        Try

            Session("TypeLeave") = lstbxTypeOfLeave.SelectedItem.Text

        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub


    Protected Sub btnAdmin_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("Employer.aspx")
        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub
End Class
