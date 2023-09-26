<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="U5_W1_D1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Elenco dipendenti:</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idDipendente" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
            <asp:BoundField DataField="Indirizzo" HeaderText="Indirizzo" />
            <asp:BoundField DataField="CodiceFiscale" HeaderText="Codice Fiscale" />
            <asp:BoundField DataField="Mansione" HeaderText="Mansione" />
            <asp:ButtonField Text="Elimina" CommandName="DeleteRow" />
        </Columns>
    </asp:GridView>

    <h1>Elenco pagamenti:</h1>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="idPagamenti" OnRowDeleting="GridView2_RowDeleting">
        <Columns>
            <asp:BoundField DataField="idPagamenti" HeaderText="idPagamento" />
            <asp:BoundField DataField="idDipendente" HeaderText="idDipendente" />
            <asp:BoundField DataField="PeriodoPagamento" HeaderText="Periodo di pagamento" />
            <asp:BoundField DataField="Ammontare" HeaderText="Ammontare" />
            <asp:BoundField DataField="TipoPagamento" HeaderText="Tipo di pagamento" />
            <asp:ButtonField Text="Elimina" CommandName="DeleteRow" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>