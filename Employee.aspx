<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Employee.aspx.vb" Inherits="Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Employee</title>
    <link href="CSS/Employee.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; height: 30px;" class="TopHeader">
            <tr>
                <td style="width: 80%; padding-left: 10px">
                    <asp:Label runat="server" ID="lblLogoText" Text="Employee" CssClass="LogoText" ForeColor="White" Font-Bold="true" />
                </td>
                <td style="width: 20%; text-align: right; padding-right: 10px;">
                    <asp:Button runat="server" ID="btnAdmin" CssClass="PageRedirect" Width="30%" Height="30px" Text="Admin" OnClick="btnAdmin_Click" />
                </td>
            </tr>
        </table>

        <table style="width: 100%; padding-top: 15px; padding-left: 20px; background-color: white;">
            <tr>
                <td style="width: 100%;">
                    <asp:Label runat="server" ID="lblHeader" Text="Apply for leave" CssClass="LogoText" ForeColor="Black" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td style="width: 80%;">
                    <div class="DetailBox" style="width: 99%;">
                        <table style="width: 100%; padding: 5px;">
                            <tr>
                                <td style="width: 70%;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblName" ForeColor="Black" CssClass="TextFont" Text="Enter your first name" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:TextBox runat="server" ID="txtFirstName" Width="30%" CssClass="TextFont" ToolTip="enter your first name" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblLastName" ForeColor="Black" CssClass="TextFont" Text="Enter your last name" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:TextBox runat="server" ID="txtLastName" Width="30%" CssClass="TextFont" ToolTip="Enter your last name" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblStartDate" ForeColor="Black" CssClass="TextFont" Text="From Date" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:Calendar runat="server" ID="clndStartDate" CssClass="Calendar" Width="30%" ToolTip="Select the date from when you want to take leve" ForeColor="Black" DayHeaderStyle-ForeColor="Black" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblEndDate" ForeColor="Black" CssClass="TextFont" Text="To Date" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:Calendar runat="server" ID="clndEndDate" CssClass="TextFont" Width="30%" ToolTip="Select the date the day before your return" ForeColor="Black" DayHeaderStyle-ForeColor="Black" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblTypeOfLeave" ForeColor="Black" CssClass="TextFont" Text="Leave Type" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:DropDownList runat="server" ID="lstbxTypeOfLeave" Width="20%" CssClass="Lstbx" ToolTip="Select your type of leave">
                                                    <asp:ListItem Text="Annual Leave" Value="1" Selected="True" />
                                                    <asp:ListItem Text="Family Responsibility Leave" Value="2" />
                                                    <asp:ListItem Text="Overtime Leave" Value="3" />
                                                    <asp:ListItem Text="Sick Leave" Value="4" />
                                                    <asp:ListItem Text="Travel Leave" Value="5" />
                                                    <asp:ListItem Text="Unpaid Leave" Value="6" />
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblLeave" ForeColor="Black" CssClass="TextFont" Text="Leave Preview" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%;">
                                                <asp:Label runat="server" ID="lblLeavePreview" ForeColor="Black" CssClass="TextFont" />
                                                <br />
                                                <asp:Label runat="server" ID="lblTotalLeaveDays" ForeColor="Black" CssClass="TextFont" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Label runat="server" ID="lblEnterReason" ForeColor="Black" CssClass="TextFont" Text="Reason" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 5px;">
                                                <asp:TextBox runat="server" ID="txtReason" CssClass="TextFont" Width="30%" Height="60px" Wrap="true" Font-Bold="true" ToolTip="Enter a reason for your leave" TextMode="MultiLine" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; padding-top: 10px;">
                                                <asp:Button runat="server" ID="btnSubmit" CssClass="SubmitBtn" Text="SUBMIT" Width="10%" Height="35px" ToolTip="Submit your leave" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:30%;">
                                    <table>
                                        <tr>
                                            <td>

                                            </td>
                                        </tr>
                                    </table>
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
