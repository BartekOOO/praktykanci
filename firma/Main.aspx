<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>


<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../Content/Site.css">
    <title>Praktykanci</title>
</head>
<body>
    <div class="headerMenu headerTop">
        <span class="dxsplPane_iOS">Strona do dodawania praktykantów</span>
    </div>
    <asp:Panel runat="server">
        <form id="form1" runat="server">
            <asp:Label Text="Imie" runat="server" />
            <asp:TextBox CssClass="contentPane" runat="server" ID="firstName" />
            <asp:Label Text="Nazwisko" runat="server" />
            <asp:TextBox runat="server" ID="lastName" />
            <br>
            <asp:Label runat="server" Text="Stanowisko" />
            <asp:DropDownList runat="server" ID="desiredPosition">
                <asp:ListItem Text="Programista" />
                <asp:ListItem Text="Inżynier" />
                <asp:ListItem Text="Informatyk" />
                <asp:ListItem Text="Serwisant" />
            </asp:DropDownList>
            <asp:Label Text="Data zgłoszenia" runat="server" />
            <input readonly="true" runat="server" type="date" enabled="false" id="dateSubmitted" />
            <br>
            <asp:Label Text="Numer telefonu" runat="server" />
            <input type="number" id="phoneNumber" runat="server" />
            <asp:Label Text="Adres e-mail" runat="server" />
            <input type="email" id="email" runat="server" />
            <br>
            <br>
            <asp:Button runat="server" OnClick="Unnamed_Click" Text="Dodaj praktykanta" /><br>
            <br>
            <asp:GridView ID="gridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="firstName" HeaderText="Imie" />
                    <asp:BoundField DataField="lastName" HeaderText="Nazwisko" />
                    <asp:BoundField DataField="desiredPosition" HeaderText="Stanowisko" />
                    <asp:BoundField DataField="dateSubmitted" HeaderText="Data wysłania" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="Numer telefonu" />
                    <asp:BoundField DataField="email" HeaderText="E-MAIL" />
                </Columns>
            </asp:GridView>
        </form>
    </asp:Panel>
</body>
</html>
