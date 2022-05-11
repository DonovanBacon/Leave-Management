Imports System.Data

Partial Class Employee
    Inherits System.Web.UI.Page
    Private TotalLeaveDays As Integer = 7
    Private mData As cData

    Private Sub clndStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles clndStartDate.SelectionChanged
        Try

            Dim RemainingLeave As String
            Dim LeaveDif As Integer

            If Session("EndDate") IsNot Nothing Then
                LeaveDif = DateAndTime.DateDiff("d", Session("EndDate"), clndStartDate.SelectedDate)
                RemainingLeave = TotalLeaveDays - TotalLeaveDays

                If clndStartDate.SelectedDate > Session("EndDate") Then
                    lblLeavePreview.Text = "Start date can not be greater than end date."
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"
                Else
                    lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"
                End If


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

                If clndStartDate.SelectedDate > Session("EndDate") Then
                    lblLeavePreview.Text = "Start date can not be greater than end date."
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"
                Else
                    lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of leave"
                End If


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

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim Completed As Boolean = True
            If txtFirstName.Text = "" Then
                Completed = False
            End If

            If txtLastName.Text = "" Then
                Completed = False
            End If

            If Session("StartDate") Is Nothing Or Session("EndDate") Is Nothing Then
                Completed = False
            End If

            If Completed = False Then
                Dim Msg, Style, Title
                Msg = "Please Complete form and then submit"
                Style = vbOKOnly
                Title = "Empty fields"

                MsgBox(Msg, Style, Title)
            Else

                Dim ds As New DataSet
                'Auditlog is being done in sql side after the insert to lessen the code on vb side
                ds = mData.SubmitLeave(Session("User").User_FK, txtFirstName.Text, txtLastName.Text, Session("StartDate"), Session("EndDate"), txtReason.Text)

                If ds.Tables(0)(0)(0).ToString = "successful" Then
                    MsgBox("Your leave has been submitted", vbOKOnly, "successful")
                Else
                    MsgBox("An error occurred, pelase try again", vbOKOnly, "Oops!")
                End If
            End If

        Catch ex As Exception
            MsgBox("An error occurred, pelase try again", vbOKOnly, "Oops!")
        End Try
    End Sub
End Class
