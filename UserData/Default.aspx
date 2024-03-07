<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserData._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store User Info</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Information</h2>
            <label for="txtName">UserName</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <label for="txtAge">Password</label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <br />
            <label for="txtAge">Age:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <label for="txtAge">Age:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>