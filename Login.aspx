<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <script src="JS/Login.js?1"></script>
    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body style="background-image: url(Images/Login_bkgrd.jpg); background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <table style="width: 100%; height: 100%;">
            <tr>
                <td style="width: 100%;">

                    <div>
                        <table style="width: 100%; text-align: right; padding-right: 40px; padding-top: 150px;">
                            <tr>
                                <td style="width: 70%;"></td>
                                <td style="width: 20%; text-align: center; vertical-align: middle; background: #404040;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 100%; padding-top: 20px;">
                                                <asp:Label runat="server" ID="lblHeader" Text="Welcome to Leave Management" CssClass="LogoText" ForeColor="white" Font-Bold="true" Font-Underline="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%;">
                                                <table style="width: 100%; text-align:center;">
                                                    <tr>
                                                        <td style="width: 100%; padding-top: 20px; text-align: left; padding-left: 5px;">
                                                            <asp:Label runat="server" ID="lblName" ForeColor="white" CssClass="TextFont" Text="Enter your username" Font-Bold="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; padding-top: 5px;">
                                                            <asp:TextBox runat="server" ID="txtUsername" Width="95%" CssClass="TextFont" ToolTip="Enter your username" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; padding-top: 10px; text-align: left; padding-left: 5px;">
                                                            <asp:Label runat="server" ID="lblPassword" ForeColor="white" CssClass="TextFont" Text="Enter your password" Font-Bold="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; padding-top: 5px;">
                                                            <asp:TextBox runat="server" ID="txtPassword" Width="95%" CssClass="TextFont" ToolTip="Enter your password" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; padding-top: 20px; padding-bottom: 20px">
                                                            <asp:Button runat="server" ID="btnLogin" CssClass="LoginBtn" Text="LOGIN" Width="50%" Height="35px" ToolTip="Login" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td style="width: 10%;"></td>
                            </tr>
                        </table>
                    </div>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
