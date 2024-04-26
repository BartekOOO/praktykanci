<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../Content/Style.css">
    <title>Praktykanci</title>
</head>
<body>
    <div class="headerMenu">
        <span class="dxsplPane_iOS">Strona do dodawania praktykantów</span>
    </div>
    <asp:Panel runat="server">
        <form id="form1" runat="server">
            <div class="panel">
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
                <asp:TextBox runat="server" ReadOnly="true" class="shortInput" enabled="false" id="dateSubmitted" />
                <br>
                <asp:Label Text="Numer telefonu" runat="server" />
                <asp:TextBox TextMode="Number" ID="phoneNumber" runat="server" />
                <asp:Label Text="Adres e-mail" runat="server" />
                <asp:TextBox TextMode="Email" ID="email" runat="server" />
                <br>
                <br>
                <asp:Button UseSubmitBehavior="false" runat="server" Class="button" OnClick="Unnamed_Click" Text="Dodaj praktykanta" /><br>
                <br>
                <span runat="server" id="alertSpan" class="alertSpan"></span>
            </div>
            <asp:Panel HorizontalAlign="Center" ID="editForm" Visible="false" runat="server">
                <br />
                <asp:Label Text="Imie" runat="server" />
                <asp:TextBox Width="200" runat="server" ID="firstNameEd" />
                <asp:Label Text="Nazwisko" runat="server" />
                <asp:TextBox Width="200" runat="server" ID="lastNameEd" />
                <asp:DropDownList Width="200" runat="server" ID="desiredPositionEd">
                    <asp:ListItem Text="Programista" />
                    <asp:ListItem Text="Inżynier" />
                    <asp:ListItem Text="Informatyk" />
                    <asp:ListItem Text="Serwisant" />
                </asp:DropDownList>
                <asp:Label Visible="false" ID="editId" runat="server" />
                <asp:Label Visible="false" ID="dbId" runat="server" />
                <asp:Label Text="Data" runat="server" />
                <asp:TextBox Width="200" runat="server" TextMode="Date" ID="dateSubmittedEd"/>
                <asp:Label Text="Numer" runat="server" />
                <asp:TextBox TextMode="Number" Width="200" ID="phoneNumberEd" runat="server" />
                <asp:Label Text="E-mail" runat="server" />
                <asp:TextBox Width="200" TextMode="Email" ID="emailEd" runat="server" />
                <asp:Button runat="server" CssClass="button"  Text="Aktualizuj" OnClick="Unnamed_Click3"/>
                <asp:Button runat="server" CssClass="button" Text="Anuluj" OnClick="Unnamed_Click4"/>
            </asp:Panel>
            <asp:GridView AutoGenerateColumns="false" ID="gridView1" runat="server">
                <Columns>
                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Lp." DataField="index" />
                    <asp:BoundField Visible="true"  DataField="id" HeaderText="Id"/>
                    <asp:BoundField DataField="firstName" HeaderText="Imie" />
                    <asp:BoundField DataField="lastName" HeaderText="Nazwisko" />
                    <asp:BoundField DataField="desiredPosition" HeaderText="Stanowisko" />
                    <asp:BoundField DataField="dateSubmitted" HeaderText="Data wysłania" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="Numer telefonu" />
                    <asp:BoundField DataField="email" HeaderText="E-MAIL" />
                    <asp:TemplateField HeaderText="Działanie">
                        <ItemTemplate>
                            <asp:Button UseSubmitBehavior="false" runat="server" Class="button" OnClick="Unnamed_Click1" Text="Edytuj" />
                            <asp:Button UseSubmitBehavior="false" runat="server" Class="button" OnClick="Unnamed_Click2" Text="Usuń" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </asp:Panel>
    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
</body>
</html>
