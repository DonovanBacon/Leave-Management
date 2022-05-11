Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cData

#Region "Admin"

#End Region

#Region "Employee"

    Function SubmitLeave(User_FK As Integer, FirstName As String, LastName As String, StartDate As String, EndDate As String, Optional Reason As String = "") As DataSet
        Dim ds As New DataSet

        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand
            With cmd

                .Connection = cn
                .Connection.Open()
                .CommandText = System.Configuration.ConfigurationManager.AppSettings("LeaveManagement") + ".dbo.SubmitLeave"
                .CommandType = CommandType.StoredProcedure

                .Parameters.AddWithValue("User_FK", User_FK)
                .Parameters.AddWithValue("FirstName", FirstName)
                .Parameters.AddWithValue("LastName", LastName)
                .Parameters.AddWithValue("StartDate", StartDate)
                .Parameters.AddWithValue("EndDate", EndDate)
                .Parameters.AddWithValue("Reason", Reason)

            End With

            Try

                Dim adapt As New SqlDataAdapter(cmd)
                adapt.Fill(ds)
                Return ds

            Catch ex As Exception
                'LogError("GetLeaveRequests", ex, "High", cmd)
                Return Nothing
            End Try
        End Using
    End Function

#End Region

#Region "Employer"

    Function GetLeaveRequests() As DataSet 'User_FK As Integer) As DataSet
        Dim ds As New DataSet

        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand
            With cmd

                .Connection = cn
                .Connection.Open()
                .CommandText = System.Configuration.ConfigurationManager.AppSettings("LeaveManagement") + ".dbo.GetLeaveRequests"
                .CommandType = CommandType.StoredProcedure

                '.Parameters.AddWithValue("User_FK", User_FK)

            End With

            Try

                Dim adapt As New SqlDataAdapter(cmd)
                adapt.Fill(ds)
                Return ds

            Catch ex As Exception
                'LogError("GetLeaveRequests", ex, "High", cmd)
                Return Nothing
            End Try
        End Using
    End Function

#End Region

End Class
