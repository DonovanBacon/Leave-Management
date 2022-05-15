Imports Microsoft.VisualBasic
Imports System.Data
Public Class cUser
    Private mData As New cData
    Property User_FK As Integer
    Property Username As String
    Property Email As String
    Property FullName As String
    Property FirstName As String
    Property LastName As String
    Property Password As String

    Sub New(mUsername)
        Dim ds As New DataSet

        ds = mData.GetUserDetails(mUsername)
        For Each item As DataRow In ds.Tables(0).Rows
            User_FK = Trim(item("User_PK")).ToString
            Username = Trim(item("Username")).ToString
            Email = item("Email").ToString
            FullName = item("Full_Name").ToString
            FirstName = item("First_Name").ToString
            LastName = item("Last_Name").ToString
            Password = item("Password").ToString
        Next

        'Use this for the demo when not able to connect to my DB

        'User_FK = 1
        'Username = "Donovan"
        'Email = "DonovanBaconTest@gmail.com"
        'FullName = "Donovan Bacon"
        'FirstName = "Donovan"
        'LastName = "Bacon"
        'Password = "Test123!"
    End Sub
End Class
