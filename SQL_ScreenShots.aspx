<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SQL_ScreenShots.aspx.vb" Inherits="SQL_ScreenShots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Screenshots</title>
    <link href="CSS/Employer.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/LeaveManageMentBK.jpg);">
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td style="width:100%; padding-left:10px;">
                        <asp:Button runat="server" ID="btnBack" CssClass="PageRedirect" Width="30%" Height="30px" Text="Back" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/Admin_DB.PNG" Width="30%"/>
                    </td>
                </tr>
               <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/GetAuditLog_proc.PNG" Width="30%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/GetUserDetails_proc.PNG" Width="30%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/GetUserSickLeave_proc.PNG" Width="30%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/Leave_Management_DB.PNG" Width="30%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/GetLeaveRequests_proc.PNG" Width="30%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/SubmitLeave_proc_Part1.PNG" Width="60%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/SubmitLeave_proc_Part2.PNG" Width="60%"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; height:200px; padding-top:10px;">
                        <asp:Image runat="server" ImageUrl="./Images/Screenshots/SubmitLeave_proc_Part3.PNG" Width="60%"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
