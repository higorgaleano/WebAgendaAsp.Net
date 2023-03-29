<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Page Title="WebAgendaCodeFirst - Procedimentos" Language="C#" MasterPageFile="~/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Agendamentos.aspx.cs" Inherits="WebAgendaCodeFirst.Agendamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />

    <br />
    <br />
    <telerik:RadPushButton RenderMode="Lightweight" ID="btSalvar" runat="server" Text="Cadastrar" Width="80px" OnClick="btSalvar_Click"></telerik:RadPushButton>
    <telerik:RadPushButton RenderMode="Lightweight" ID="btCancelar" runat="server" Text="Limpar" Width="80px" OnClick="btCancelar_Click"></telerik:RadPushButton>
    <telerik:RadPushButton RenderMode="Lightweight" ID="btAtualizar" runat="server" Text="Atualizar" OnClick="btAtualizar_Click"></telerik:RadPushButton>
    <telerik:RadPushButton RenderMode="Lightweight" ID="btDeletar" runat="server" Text="Deletar" Width="80px" OnClick="btDeletar_Click"></telerik:RadPushButton>
    <telerik:RadPushButton RenderMode="Lightweight" ID="btFaturamento" runat="server" Text="Faturamento" Width="100px" OnClick="btFaturamento_Click"></telerik:RadPushButton>
    <br />
    <br />
    <asp:Panel ID="pnlCadastrarAgendamento" runat="server" GroupingText="Cadastro e Alteração - Agendamentos">
        <asp:Label ID="Label9" runat="server" Text="Cód.Agendamento"></asp:Label>
        <br />
        <telerik:RadTextBox RenderMode="Lightweight" ID="txbId" runat="server" Width="250px" Enabled="false" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>
        <br />
        <telerik:RadDropDownList RenderMode="Lightweight" ID="ddlClientes" runat="server" Width="250px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Datas Disponíveis"></asp:Label>
        <br />
        <asp:Calendar ID="CalendarAgendamento" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnSelectionChanged="CalendarAgendamento_SelectionChanged" Width="330px" OnDayRender="CalendarAgendamento_DayRender">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Horários Disponíveis"></asp:Label>
        <br />
        <telerik:RadDropDownList RenderMode="Lightweight" ID="ddlHorarios" runat="server" Width="250px" AutoPostBack="true">
        <Items>
                <telerik:DropDownListItem Text="-- Selecione Horário --" Value="00" />
                <telerik:DropDownListItem Text="08:00" Value="08" />
                <telerik:DropDownListItem Text="09:00" Value="09" />
                <telerik:DropDownListItem Text="10:00" Value="10" />
                <telerik:DropDownListItem Text="11:00" Value="11" />
                <telerik:DropDownListItem Text="12:00" Value="12" />
                <telerik:DropDownListItem Text="13:00" Value="13" />
                <telerik:DropDownListItem Text="14:00" Value="14" />
                <telerik:DropDownListItem Text="15:00" Value="15" />
                <telerik:DropDownListItem Text="16:00" Value="16" />
                <telerik:DropDownListItem Text="17:00" Value="17" />
                <telerik:DropDownListItem Text="18:00" Value="18" />
                <telerik:DropDownListItem Text="19:00" Value="19" />
            </Items>
        </telerik:RadDropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Procedimento"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Tempo de Atendimento"></asp:Label>
        <br />
        <telerik:RadDropDownList ID="ddlProcedimentos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProcedimentos_SelectedIndexChanged" RenderMode="Lightweight" Width="250px" />
        &nbsp;&nbsp;&nbsp;
        <telerik:RadTextBox RenderMode="Lightweight" ID="txbTempoAtendimento" runat="server" Width="180px" Enabled="false" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Orçamento"></asp:Label>
        <br />
        <telerik:RadTextBox RenderMode="Lightweight" ID="txbOrcamento" runat="server" Width="250px" Enabled="false" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Estado do Agendamento"></asp:Label>
        <br />
        <telerik:RadDropDownList RenderMode="Lightweight" ID="ddlEstadoAgendamento" runat="server" Width="250px">
            <Items>
                <telerik:DropDownListItem Text="-- Selecionar Status --" Value="0" />
                <telerik:DropDownListItem Text="A Confirmar" Value="1" />
                <telerik:DropDownListItem Text="Confirmado" Value="2" />
                <telerik:DropDownListItem Text="Concluído" Value="3" Visible="false" />
                <telerik:DropDownListItem Text="Cancelado" Value="4" Visible="false" />
            </Items>
        </telerik:RadDropDownList>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Observações"></asp:Label>
        <br />
        <telerik:RadTextBox ID="txaObs" RenderMode="Lightweight" EmptyMessage="Entre com as observações" TextMode="MultiLine" runat="server" Width="250px" Height="100px" />
        <br />
        <br />
        <asp:Label ID="lbNotificacao" runat="server" Text="" Visible="false" Font-Size="Medium" Font-Bold="True"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlAgendamentosRegistrados" runat="server" GroupingText="Agendamentos Registrados">
        <br />
        <telerik:RadPushButton RenderMode="Lightweight" ID="btExibirGridAgendamentos" runat="server" Text="Exibir Agendamentos Concluídos" OnClick="btExibirGridAgendamentos_Click" ></telerik:RadPushButton>
        <br />
        <br />
        <asp:GridView ID="gridAgendamentos" runat="server" AutoGenerateColumns="False" Width="1287px" Height="100px" OnRowDataBound="gridAgendamentos_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gridAgendamentos_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Cód.Agendamento" />
                <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Horario" DataFormatString="{0:HH:mm}" HeaderText="Horário" />
                <asp:BoundField DataField="ClienteNome" HeaderText="Cliente" />
                <asp:BoundField DataField="ProcedimentoNome" HeaderText="Procedimento" />
                <asp:BoundField DataField="valor" DataFormatString="{0:c}" HeaderText="Orçamento" />
                <asp:BoundField DataField="Status" HeaderText="Estado" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#a5b1b5" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

        <br />

        <asp:GridView ID="gridAgendamentosConcluidos" runat="server" AutoGenerateColumns="False" Width="1287px" Height="100px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Cód.Agendamento" />
                <asp:BoundField DataField="Data" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data" />
                <asp:BoundField DataField="Horario" DataFormatString="{0:HH:mm}" HeaderText="Horário" />
                <asp:BoundField DataField="ClienteNome" HeaderText="Cliente" />
                <asp:BoundField DataField="ProcedimentoNome" HeaderText="Procedimento" />
                <asp:BoundField DataField="Valor" HeaderText="Orçamento" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Status" HeaderText="Estado" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#a5b1b5" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlFaturamento" runat="server" GroupingText="Faturamento" Visible="false">
        <br />
        <telerik:RadPushButton RenderMode="Lightweight" ID="btCalcProcedimento1" runat="server" Text="Cálc. Procedimento1" Width="160px" Height="25px" OnClick="btCalcProcedimento1_Click"></telerik:RadPushButton>
        <telerik:RadPushButton RenderMode="Lightweight" ID="btCalcProcedimento2" runat="server" Text="Cálc. Procedimento2" Width="160px" Height="25px" OnClick="btCalcProcedimento2_Click"></telerik:RadPushButton>
        <telerik:RadPushButton RenderMode="Lightweight" ID="btCalcProcedimento3" runat="server" Text="Cálc. Procedimento3" Width="160px" Height="25px" OnClick="btCalcProcedimento3_Click"></telerik:RadPushButton>
        <telerik:RadPushButton RenderMode="Lightweight" ID="btCalcTot" runat="server" Text="Cálc. Total" Width="120px" Height="25px" OnClick="btCalcTot_Click"></telerik:RadPushButton>
        <telerik:RadPushButton RenderMode="Lightweight" ID="btFechar" runat="server" Text="Fechar" Width="80px" Height="25px" OnClick="btFechar_Click"></telerik:RadPushButton>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Quant. Atendimento:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label14" runat="server" Text="Faturamento Total:"></asp:Label>
        <br />
        <telerik:RadTextBox ID="txbQquantTotal" RenderMode="Lightweight" runat="server" Width="180px" Height="25px" Enabled="false" Font-Bold="true" />
        &nbsp;
        <telerik:RadTextBox ID="txbValorTotal" RenderMode="Lightweight" runat="server" Width="180px" Height="25px" Enabled="false" Font-Bold="true" />
        <br />
        <br />
        <asp:GridView ID="gridFaturamento" runat="server" Width="558px" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Cód.Atendimento" ItemStyle-Width="180px">
                <ItemStyle Width="180px" />
                </asp:BoundField>
                <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:c}" ItemStyle-Width="180px">
                <ItemStyle Width="180px" />
                </asp:BoundField>
                <asp:BoundField DataField="Data" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Atendimento" ItemStyle-Width="180px">
                <ItemStyle Width="180px" />
                </asp:BoundField>
            </Columns>       
        </asp:GridView>
    </asp:Panel>

</asp:Content>
