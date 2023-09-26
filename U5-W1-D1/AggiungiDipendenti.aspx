<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AggiungiDipendenti.aspx.cs" Inherits="U5_W1_D1.AggiungiDipendenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
    <h1>Aggiungi dipendente:</h1>

        <label for="txtNome">Nome:</label>
        <asp:TextBox ID="txtNome" runat="server" Required="true"></asp:TextBox>

        <label for="txtCognome">Cognome:</label>
        <asp:TextBox ID="txtCognome" runat="server" Required="true"></asp:TextBox>

        <label for="txtIndirizzo">Indirizzo:</label>
        <asp:TextBox ID="txtIndirizzo" runat="server" Required="true"></asp:TextBox>

        <label for="txtCodiceFiscale">Codice Fiscale:</label>
        <asp:TextBox ID="txtCodiceFiscale" runat="server" Required="true"></asp:TextBox>

        <label for="chkConiugato">Coniugato:</label>
        <asp:CheckBox ID="chkConiugato" runat="server" /><br />

        <label for="txtFigli">Numero di figli a carico:</label>
        <asp:TextBox ID="txtFigli" runat="server" TextMode="Number"></asp:TextBox>

        <label for="ddlMansione">Mansione:</label>
        <asp:DropDownList ID="ddlMansione" runat="server">
            <asp:ListItem Text="Amministrativo" Value="Amministrativo"></asp:ListItem>
            <asp:ListItem Text="Operativo" Value="Operativo"></asp:ListItem>
            <asp:ListItem Text="Tecnico" Value="Tecnico"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Button ID="btnSalvaDipendete" runat="server" Text="Salva Dipendente" OnClick="btnSalvaDipendete_Click" CssClass="button-custom" />
    </div>
</asp:Content>
