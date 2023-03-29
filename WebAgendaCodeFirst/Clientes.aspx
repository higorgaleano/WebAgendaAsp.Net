<%@ Page Title="WebAgendaCodeFirst - Clientes" Language="C#" MasterPageFile="~/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebAgendaCodeFirst.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="pnlCadastroCliente" runat="server" GroupingText="Cadastro/Alteração de Clientes Ativos" Visible="false">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txbId" runat="server" Enabled="false" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="CheckClienteAtivo" runat="server" /><asp:Label ID="LbStatus_Cliente" runat="server" Text="Cliente Ativo"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome do Cliente"></asp:Label>
        <br />
        <asp:TextBox ID="txbNome" runat="server" Width="400px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Telefone"></asp:Label>
        <br />
        <asp:TextBox ID="txbTelefone" runat="server" TextMode="Phone" MaxLength="11" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Data de Nascimento"></asp:Label>
        <br />
        <asp:TextBox ID="txbNascimento" runat="server" TextMode="Date" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Observações"></asp:Label>
        <br />
        <textarea id="TextAreaObs" cols="53" rows="4" runat="server" maxlength="200" lang="pt-br"></textarea>
        <br />
        <br />
        <asp:Label ID="lbNotificacaoExcluir" runat="server" Text="Digite &quot;Excluir&quot; para confirmar a exclusão do cliente selecionado." Font-Size="Small" Visible="False"></asp:Label>
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
    <asp:Panel ID="pnlExibicaoCliente" runat="server" GroupingText="Registro dos Clientes Ativos">
        <br />
        <asp:Button ID="btAbrirCadastro" runat="server" Text="Cadastrar Novo Cliente" OnClick="btAbrirCadastro_Click" Height="30px" />
        <asp:Button ID="btExibirGrid" runat="server" Text="Mostrar Clientes Inativos" OnClick="btExibirGrid_Click" Height="30px" />
        <br />
        <br />
        <asp:GridView ID="gridClientesAtivos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridClientesAtivos_SelectedIndexChanged" Width="1313px" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Cód.Cliente" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" SortExpression="Telefone" />
                <asp:BoundField DataField="Nascimento" HeaderText="Data de Nascimento" SortExpression="Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Ativo" HeaderText="Status" SortExpression="Ativo" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebAgendaCodeFirstConnectionString %>" SelectCommand="SELECT * FROM cliente WHERE ativo = 1"></asp:SqlDataSource>
        
        <asp:GridView ID="gridClientesInativos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="1312px" Visible="False" OnSelectedIndexChanged="gridClientesInativos_SelectedIndexChanged" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Cód.Cliente" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" SortExpression="Telefone" />
                <asp:BoundField DataField="Nascimento" HeaderText="Data de Nascimento" SortExpression="Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Ativo" HeaderText="Status" SortExpression="Ativo" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:WebAgendaCodeFirstConnectionString2 %>" SelectCommand="SELECT * FROM cliente WHERE ativo = 0"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
