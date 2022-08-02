<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KupacUpdejtajWebForma.aspx.cs" UnobtrusiveValidationMode="None" Inherits="RWA_Aplikacija.WebForms.KupacWebForma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../Content/bootstrap.css" rel="stylesheet" />
<head runat="server">
    <title>Uredi Kupca</title>
</head>
<body>
<h1 style="text-align:center;">Uredi kupca</h1>
    <form id="form1"  runat="server">
    <div class="container" style="width:50%;">
        <div class="form-group">
            <asp:Label ID="lbIme" runat="server" Text="Ime">Ime</asp:Label>
            <asp:TextBox ID="txtIme" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Val1" ControlToValidate="txtIme" runat="server" ErrorMessage="Ime je obvezno"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbPrezime" runat="server" Text="Prezime">Prezime</asp:Label>
            <asp:TextBox ID="txtPrezime" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Val2" ControlToValidate="txtPrezime" runat="server" ErrorMessage="Prezime je obvezno"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbEmail" runat="server" Text="Email">Email</asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Val3" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email je obvezan"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="ValEmail" runat="server" ErrorMessage="Unesite ispravnu e-mail adresu!" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
        </div> 
        <div>
            <asp:Label ID="lbTelefon" runat="server" Text="Telefon"></asp:Label>
            <asp:TextBox ID="txtTelefon" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Val4" ControlToValidate="txtTelefon" runat="server" ErrorMessage="Telefon je obvezan"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="ValTelfon" runat="server" ControlToValidate="txtTelefon" ErrorMessage="format broja telefona: 000-000-0000" ValidationExpression="^\d{3}-\d{3}-\d{4}$" ForeColor="Red"></asp:RegularExpressionValidator>
        </div >
        <div class="form-group">
            <asp:Label ID="lbDrzava" runat="server" Text="Drzava"></asp:Label>
            <asp:DropDownList ID="ddlDrzave" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="Val5" ControlToValidate="ddlDrzave" runat="server" ErrorMessage="Drzava je obvezan"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lbGrad" runat="server" Text="Grad" ></asp:Label>
            <asp:DropDownList ID="ddlGradovi" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="Val6" ControlToValidate="ddlGradovi" runat="server" ErrorMessage="Grad je obvezan"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSpremi" CssClass="btn btn-primary" runat="server" Text="Spremi promjene" OnClick="btnSpremi_Click" />
        </div>
    </div>
    </form>
</body>
</html>
