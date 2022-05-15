<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AuditLog.aspx.vb" Inherits="AuditLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Audit Log</title>
    <link href="CSS/Employer.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/LeaveManageMentBK.jpg);">
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; height: 30px;" class="TopHeader">
                <tr>
                    <td style="width: 60%; padding-left: 10px">
                        <asp:Label runat="server" ID="lblLogoText" Text="ADMIN" CssClass="LogoText" ForeColor="White" Font-Bold="true" />
                    </td>
                    <td style="width:20%;">
                        <asp:Button runat="server" ID="btnShowSQLScreenshots" CssClass="PageRedirect" Width="30%" Height="30px" Text="Show Audit Logs" OnClick="btnShowSQLScreenshots_Click" />
                    </td>
                    <td style="width: 20%; text-align: right; padding-right: 20px;">
                        <asp:Button runat="server" ID="btnBack" CssClass="PageRedirect" Width="30%" Height="30px" Text="Back" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>

            <table style="width:100%;">
                <tr>
                    <td style="width:100%; padding-left:15px;">
                        <asp:GridView runat="server" ID="grdAudit" Width="99%" Height="100%" BackColor="white">
                            <PagerSettings Mode="Numeric"/>    
                            <HeaderStyle BackColor="White"/>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
