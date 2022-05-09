<%@ Page Language="VB"  AutoEventWireup="false" CodeBehind="Employee.aspx" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Employee</title>    
    <link href="CSS/Employee.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">  
        <table style="width:100%; height:30px;" class="TopHeader">
            <tr>
                <td style="width:80%;">                    
                    <asp:Label runat="server" ID="lblLogoText" Text="Employee" CssClass="LogoText" ForeColor="White"/>
                </td>
                <td style="width:20%;">
                    <asp:Button runat="server" ID="btnAdmin" OnClientClick="GoToEmployer" CssClass="PageRedirect"/>
                </td>
            </tr>
        </table>

        <table style="width:100%; padding-top:20px; background-color:grey;">
            <tr>
                <td style="width:100%;">
                    <asp:Label runat="server" ID="lblHeader" Text="Apply for leave" CssClass="TopHeader" ForeColor="Black"/>
                </td>
            </tr>
            <tr>
                <td style="width:100%;">
                    <div class="DetailBox">
                        <table style="width:100%;">
                            <tr>
                                <td style="width:100%;">
                                    <asp:label runat="server" ID="lblName" ForeColor="Black" CssClass="TextFont"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
