Imports System.Data

Imports System.Collections.Generic
Imports System.IO

Imports System.Threading

Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Calendar.v3.EventsResource
Imports Google.Apis.Services
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports Google.Apis.Requests

Partial Class Employee
    Inherits System.Web.UI.Page
    Private TotalLeaveDays As Integer = 7
    Private mData As New cData

    Private Sub clndStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles clndStartDate.SelectionChanged
        Try

            Dim RemainingLeave As String
            Dim LeaveDif As Integer

            If Session("EndDate") IsNot Nothing Then
                LeaveDif = DateAndTime.DateDiff("d", clndStartDate.SelectedDate, Session("EndDate"))

                If lstbxTypeOfLeave.SelectedValue = 1 Then
                    RemainingLeave = Convert.ToInt64(lblAnnualBalance.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 2 Then
                    RemainingLeave = Convert.ToInt64(lblfamLeave.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 3 Then
                    RemainingLeave = Convert.ToInt64(lblOverTime.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 4 Then
                    RemainingLeave = Convert.ToInt64(lblSick.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 5 Then
                    RemainingLeave = Convert.ToInt64(lblTravel.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 6 Then
                    RemainingLeave = Convert.ToInt64(lblUnpaid.Text) - LeaveDif
                End If
                'RemainingLeave = TotalLeaveDays - LeaveDif
                Session("LeavePeriod") = RemainingLeave

                If clndStartDate.SelectedDate > Session("EndDate") Then
                    lblLeavePreview.Text = "Start date can not be greater than end date."
                    lblTotalLeaveDays.Text = ""
                Else
                    lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of " + lstbxTypeOfLeave.SelectedItem.Text.ToString
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
                Session("LeaveDif") = LeaveDif

                If lstbxTypeOfLeave.SelectedValue = 1 Then
                    RemainingLeave = Convert.ToInt64(lblAnnualBalance.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 2 Then
                    RemainingLeave = Convert.ToInt64(lblfamLeave.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 3 Then
                    RemainingLeave = Convert.ToInt64(lblOverTime.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 4 Then
                    RemainingLeave = Convert.ToInt64(lblSick.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 5 Then
                    RemainingLeave = Convert.ToInt64(lblTravel.Text) - LeaveDif
                ElseIf lstbxTypeOfLeave.SelectedValue = 6 Then
                    RemainingLeave = Convert.ToInt64(lblUnpaid.Text) - LeaveDif
                End If

                Session("LeavePeriod") = RemainingLeave

                If Session("StartDate") > clndEndDate.SelectedDate Then
                    lblLeavePreview.Text = "Start date can not be greater than end date."
                    lblTotalLeaveDays.Text = ""
                Else
                    lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + RemainingLeave.ToString
                    lblTotalLeaveDays.Text = "You are submitting " + LeaveDif.ToString + " days of  " + lstbxTypeOfLeave.SelectedItem.Text.ToString
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
            If Session("LeavePeriod") IsNot Nothing And Session("LeaveDif") IsNot Nothing Then
                lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + Session("LeavePeriod").ToString
                lblTotalLeaveDays.Text = "You are submitting " + Session("LeaveDif").ToString + " days of  " + lstbxTypeOfLeave.SelectedItem.Text.ToString
            End If


        Catch ex As Exception
            'Audit Log to capture exception error and log to DB
        End Try
    End Sub

    'Private Sub lstbxTypeOfLeave_TextChanged(sender As Object, e As EventArgs) Handles lstbxTypeOfLeave.TextChanged
    '    Try

    '        Session("TypeLeave") = lstbxTypeOfLeave.SelectedItem.Text
    '        lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + Session("LeavePeriod").ToString
    '        lblTotalLeaveDays.Text = "You are submitting " + Session("LeaveDif").ToString + " days of  " + lstbxTypeOfLeave.SelectedItem.Text.ToString


    '    Catch ex As Exception
    '        'Audit Log to capture exception error and log to DB
    '    End Try
    'End Sub


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
                'Session("User").User_FK

                If Session("LeavePeriod").ToString.Contains("-") Then
                    Session("LeavePeriod") = 0
                End If
                ds = mData.SubmitLeave(Session("User").User_FK, txtFirstName.Text, txtLastName.Text, Session("StartDate").ToString, Session("EndDate").ToString, lstbxTypeOfLeave.SelectedItem.Text.ToString, Session("LeavePeriod"), txtReason.Text.ToString)

                If ds.Tables(0)(0)(0).ToString = "successful" Then
                    MsgBox("Your leave has been submitted", vbOKOnly, "successful")


                    'Dim CalendarEvent As New Data.Event
                    'Dim StartDateTime As New Data.EventDateTime
                    'Dim A As Date
                    'Dim service As CalendarService

                    'Dim scopes As IList(Of String) = New List(Of String)()

                    'scopes.Add(CalendarService.Scope.Calendar)
                    'Dim credential As UserCredential
                    'Using stream As New FileStream("client_secrets.json", FileMode.Open, FileAccess.Read)
                    '    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    'GoogleClientSecrets.Load(stream).Secrets, scopes, "user", CancellationToken.None,
                    'New FileDataStore("Calendar.VB.Sample")).Result
                    'End Using

                    'Dim initializer As New BaseClientService.Initializer()
                    'initializer.HttpClientInitializer = credential
                    'initializer.ApplicationName = "VB.NET Calendar Sample"
                    'service = New CalendarService(initializer)

                    ''A = "15-OCT-2016 12:00"
                    'StartDateTime.DateTime = Session("StartDate")
                    ''Dim b As Date
                    ''b = A.AddDays(2)
                    'Dim EndDateTime As New Data.EventDateTime
                    'EndDateTime.DateTime = Session("EndDate")
                    'CalendarEvent.Start = StartDateTime
                    'CalendarEvent.End = EndDateTime
                    'CalendarEvent.Id = System.Guid.NewGuid.ToString
                    'CalendarEvent.Description = lstbxTypeOfLeave.SelectedItem.Text.ToString + " has been submitted."
                    'CalendarEvent.Attendees = New EventAttendee() {New EventAttendee() With {.Email = "DonovanBaconTest@gmail.com"}}

                    'service.Events.Insert(CalendarEvent, "primary").Execute()
                Else
                    MsgBox("An error occurred, pelase try again", vbOKOnly, "Oops!")
                End If
            End If

        Catch ex As Exception
            MsgBox("An error occurred, pelase try again", vbOKOnly, "Oops!")
        End Try
    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            lblLogoText.Text = "Employee: " + Session("User").fullname.ToString + "001"

            If Not IsPostBack Then
                Dim ds As New DataSet
                ds = mData.GetUserSickLeave(Session("User").User_Fk)

                lblAnnualBalance.Text = ds.Tables(0)(0)("Annual_Leave").ToString
                lblfamLeave.Text = ds.Tables(0)(0)("Fam_Respon_leave").ToString
                lblOverTime.Text = ds.Tables(0)(0)("Overtime_Leave").ToString
                lblSick.Text = ds.Tables(0)(0)("Sick_Leave").ToString
                lblTravel.Text = ds.Tables(0)(0)("Travel_Leave").ToString
                lblUnpaid.Text = ds.Tables(0)(0)("Unpaid_Leave").ToString

            End If

            If Session("TypeLeave") IsNot Nothing And Session("LeavePeriod") IsNot Nothing And Session("LeaveDif") IsNot Nothing Then
                Session("TypeLeave") = lstbxTypeOfLeave.SelectedItem.Text
                lblLeavePreview.Text = "Remaining " + lstbxTypeOfLeave.SelectedItem.Text.ToString + ": " + Session("LeavePeriod").ToString
                lblTotalLeaveDays.Text = "You are submitting " + Session("LeaveDif").ToString + " days of  " + lstbxTypeOfLeave.SelectedItem.Text.ToString
            End If


        Catch ex As Exception

        End Try
    End Sub


End Class