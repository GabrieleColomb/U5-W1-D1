<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagamenti.aspx.cs" Inherits="U5_W1_D1.Pagamenti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div id="container">
    <h1>Aggiungi pagamento:</h1>
        <label for="ddlDipendente">Seleziona il dipendente:</label>
        <asp:DropDownList ID="ddlDipendente" runat="server">
        </asp:DropDownList>

        <label for="txtPeriodoPagamento">Periodo del pagamento:</label>
        <asp:TextBox ID="txtPeriodoPagamento" runat="server" Required="true"></asp:TextBox>

        <label for="txtAmmontarePagameto">Ammontare del pagamento:</label>
        <asp:TextBox ID="txtAmmontarePagamento" runat="server" Required="true"></asp:TextBox>

        <label for="ddlTipoPagamento">Tipo di pagamento:</label>
        <asp:DropDownList ID="ddlTipoPagamento" runat="server">
            <asp:ListItem Text="Stipendio" Value="Stipendio" />
            <asp:ListItem Text="Acconto" Value="Acconto" />
        </asp:DropDownList>
           <br /><br />

        <asp:Button ID="btnSalvaPagamento" runat="server" Text="Salva Pagamento" OnClick="btnSalvaPagamento_Click" CssClass="button-custom" />
    </div>
</asp:Content>
