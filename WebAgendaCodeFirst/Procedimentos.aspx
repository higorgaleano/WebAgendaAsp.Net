<%@ Page Title="WebAgendaCodeFirst - Procedimentos" Language="C#" MasterPageFile="~/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Procedimentos.aspx.cs" Inherits="WebAgendaCodeFirst.Procedimentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="pnlCadastroProcedimento" runat="server" GroupingText="Cadastro e Alteração de Procedimentos">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txbId" runat="server" Enabled="false" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome do Procedimento"></asp:Label>
        <br />
        <asp:TextBox ID="txbNome" runat="server" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Tempo de Duração"></asp:Label>
        <br />
        <asp:TextBox ID="txbDuracao" runat="server" TextMode="Time" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Valor"></asp:Label>
        <br />
        <asp:TextBox ID="txbValor" runat="server" MaxLength="5" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbNotificacaoExcluir" runat="server" Text="Digite &quot;Excluir&quot; para confirmar a exclusão do procedimento selecionado." Font-Size="Small" Visible="false"></asp:Label>
        <br />
        <asp:Button ID="btSalvar" runat="server" Text="Cadastrar" OnClick="btSalvar_Click" Height="30px" Width="100px" />
        <asp:Button ID="btCancelar" runat="server" Text="Limpar" CausesValidation="false" OnClick="btCancelar_Click" Height="30px" Width="100px" />
        <asp:Button ID="btExcluir" runat="server" Text="Excluir" Visible="false" OnClick="btExcluir_Click" Height="30px" Width="100px" />
        &nbsp;<asp:TextBox ID="txbExcluir" runat="server" Font-Italic="True" Visible="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbNotificacao" runat="server" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
        <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlExibicaoProcedimento" runat="server" GroupingText="Exibição de Procedimentos">
        <br />
        <asp:Button ID="btExibirCadastroProcedimento" runat="server" Text="Cadastrar Novo Procedimento" OnClick="btExibirCadastroProcedimento_Click" Height="30px" Width="250px" />
        <br />
        <br />
        <asp:GridView ID="gridProcedimentos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1287px" AutoGenerateColumns="False" OnSelectedIndexChanged="gridProcedimentos_SelectedIndexChanged">

            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Cód.Procedimento" />
                <asp:BoundField DataField="Nome" HeaderText="Procedimento" />
                <asp:BoundField DataField="Duracao" DataFormatString="{0:HH:mm}" HeaderText="Tempo de Duração" />
                <asp:BoundField DataField="Valor" DataFormatString="{0:C2}" HeaderText="Valor" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>
    </asp:Panel>
</asp:Content>
