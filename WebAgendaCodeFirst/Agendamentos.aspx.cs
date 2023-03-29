using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WebAgendaCodeFirst.DAL;
using WebAgendaCodeFirst.Models;


namespace WebAgendaCodeFirst
{
    public partial class Agendamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageDefault();
                ExibirddlClientes();
                ExibirddlProcedimentos();

            }

            ExibirRegistrosGridAgendamentos();
            
        }

        protected void ExibirRegistrosGridAgendamentos()
        {
            AgendamentoDAL dal = new AgendamentoDAL();

            gridAgendamentos.DataSource = dal.ExibirGridAgendamento();
            gridAgendamentos.DataBind();
        }

        protected void ExibirRegistrosGridAgendamentosConcluidos()
        {
            AgendamentoDAL dal = new AgendamentoDAL();

            gridAgendamentosConcluidos.DataSource = dal.ExibirGridAgendamentoConcluido();
            gridAgendamentosConcluidos.DataBind();
        }

        protected void gridAgendamentos_RowDataBound(object sender, GridViewRowEventArgs e) // update status do agendamento e colors cells
        {
            AgendamentoDAL dal = new AgendamentoDAL();

            DateTime dataAtual = DateTime.Today.Date;

            for (int i = 0; i < gridAgendamentos.Rows.Count; i++)
            {
                if (Convert.ToDateTime(gridAgendamentos.Rows[i].Cells[2].Text) < dataAtual && gridAgendamentos.Rows[i].Cells[7].Text == "Confirmado")
                    dal.AlteraAgendamentoConfirmadosAposDataAtual(Convert.ToInt32(gridAgendamentos.Rows[i].Cells[1].Text));
            }

            if (e.Row.Cells[7].Text == "Confirmado")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
            }
            if (e.Row.Cells[7].Text == "A Confirmar")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
            }
            if (e.Row.Cells[7].Text == "Cancelado")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
            }
        }

        protected void PageDefault()
        {
            btSalvar.Enabled = true;
            btCancelar.Enabled = true;
            btAtualizar.Enabled = false;
            btDeletar.Enabled = false;
            ddlHorarios.Enabled = false;
        }

        protected void LimparCampos()
        {
            btSalvar.Enabled = true;
            btAtualizar.Enabled = false;
            txbId.Text = null;
            ddlClientes.SelectedIndex = 0;
            CalendarAgendamento.SelectedDate = DateTime.Now;
            ddlHorarios.SelectedIndex = 0;
            ddlHorarios.Enabled = false;
            ddlProcedimentos.SelectedIndex = 0;
            txbTempoAtendimento.Text = null;
            txbOrcamento.Text = null;
            ddlEstadoAgendamento.SelectedIndex = 0;
            txaObs.Text = "";
            gridAgendamentos.SelectedIndex = -1;

        }

        protected void ExibirddlClientes() // carrega clientes do sql no ddl
        {
            AgendamentoDAL dal = new AgendamentoDAL();
            ddlClientes.DataSource = dal.ListarClientes();
            ddlClientes.DataValueField = "Id";
            ddlClientes.DataTextField = "Nome";
            ddlClientes.DataBind();
            ddlClientes.Items.Insert(0, "-- Selecione Cliente --");
            //ddlClientes.Items.Insert(0, new ListItem("--Selecione--")) antes do telerik;
        }

        protected void ExibirddlProcedimentos() // carrega procedimentos do sql no ddl
        {
            AgendamentoDAL dal = new AgendamentoDAL();

            ddlProcedimentos.DataSource = dal.ListarProcedimentos();
            ddlProcedimentos.DataValueField = "Id";
            ddlProcedimentos.DataTextField = "Nome";
            ddlProcedimentos.DataBind();
            ddlProcedimentos.Items.Insert(0, "-- Selecione Procedimento --");
        }

        protected void ddlProcedimentos_SelectedIndexChanged(object sender, EventArgs e) // exibe valor de acordo com o procedimento selecionado
        {
            //1. AutoPostBack="true" no ddlProcedimentos 
            //2. Coloquei um if para separar a validacao do ExibirddlProcedimentos e memorizar o elemento selecioando
            //3. A consulta está na dal, aqui pega apenas o selectedvalue e joga para o Id 

            AgendamentoDAL dal = new AgendamentoDAL();
            Procedimento objProcedimento = new Procedimento();

            if (!IsPostBack)
            {
                ddlProcedimentos.DataSource = dal.ListarProcedimentos(); // criar metodo para conexao datasource
                ddlProcedimentos.DataValueField = "Id";
                ddlProcedimentos.DataTextField = "Nome";
                ddlProcedimentos.Items.Insert(0, "-- Selecione Procedimento --");
            }

            if (ddlProcedimentos.SelectedIndex == 0) // tratamento evita erro ao selecionar 1a opcao do ddl
            {
                txbOrcamento.Text = "";
                txbTempoAtendimento.Text = "";
            }
            else
            {
                int codProcedimento = Convert.ToInt32(ddlProcedimentos.SelectedValue);
                objProcedimento = dal.ConsultarIdProcedimento(codProcedimento);
                txbOrcamento.Text = objProcedimento.Valor.ToString("C");
                txbTempoAtendimento.Text = objProcedimento.Duracao.ToString("t");
            }
            ddlProcedimentos.DataBind();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            lbNotificacao.Text = "";
            lbNotificacao.Visible = false;
        }

        protected void btSalvar_Click(object sender, EventArgs e) // cadastrar agendamento
        {
            Agendamento objAgendamento = new Agendamento();
            AgendamentoDAL dal = new AgendamentoDAL();

            if (ddlClientes.SelectedIndex < 1)
            {
                ddlClientes.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Cliente deve ser selecionado";
            }
            else if (CalendarAgendamento.SelectedDate == null)
            {
                CalendarAgendamento.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Uma Data deve ser selecionada para o agendamento";
            }
            else if (ddlHorarios.SelectedIndex < 1)
            {
                ddlHorarios.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Horário deve ser selecionado para o agendamento";
            }
            else if (ddlProcedimentos.SelectedIndex < 1)
            {
                ddlProcedimentos.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Procedimento deve ser selecionado";
            }
            else if (ddlEstadoAgendamento.SelectedIndex < 1)
            {
                ddlEstadoAgendamento.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Estado deve ser selecionado para o agendamento";
            }
            else
            {

                objAgendamento.ClienteId = Convert.ToInt32(ddlClientes.SelectedValue);
                objAgendamento.Data = Convert.ToDateTime(CalendarAgendamento.SelectedDate);
                objAgendamento.Horario = ddlHorarios.SelectedText;
                objAgendamento.ProcedimentoId = int.Parse(ddlProcedimentos.SelectedValue);

                string orcamentoSemMascara = txbOrcamento.Text.Replace("R$", "");
                objAgendamento.Valor = decimal.Parse(orcamentoSemMascara);

                objAgendamento.Status = ddlEstadoAgendamento.SelectedText;
                objAgendamento.Observacao = txaObs.Text;

                dal.CadastrarAgendamento((Agendamento)objAgendamento);

                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                lbNotificacao.Text = "Agendamento realizado com sucesso!!!!";

                ExibirRegistrosGridAgendamentos();
                LimparCampos();
            }
        }

        protected void CalendarAgendamento_DayRender(object sender, DayRenderEventArgs e) // render regras dias da semana no calendar
        {
            e.Cell.ForeColor = System.Drawing.Color.RoyalBlue;
            e.Cell.Font.Bold = true;

            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
                e.Cell.Font.Bold = false;
            }
        }

        protected void CalendarAgendamento_SelectionChanged(object sender, EventArgs e) // selecionar data no calendar
        {
            // inicia o uso do calendario | quando seleciona uma data sem horarios marcados:
            ddlHorarios.Enabled = true;
            for (int i = 0; i < ddlHorarios.Items.Count; i++)
            {
                ddlHorarios.Items[i].Enabled = true;
            }

            // quando seleciona uma data com horarios ja marcados: 
            AgendamentoDAL dal = new AgendamentoDAL();
            Agendamento objAgendamento = new Agendamento();
            List<RetornoAgendamentos> listaAgendamentos = new List<RetornoAgendamentos>();
            listaAgendamentos.Clear();

            DateTime dataSelecionada = CalendarAgendamento.SelectedDate;
            listaAgendamentos = dal.VerificarHorariosDisponiveis(dataSelecionada);

            for (int i = 0; i < listaAgendamentos.Count; i++)
            {
                foreach (var item in listaAgendamentos)
                {
                    ddlHorarios.DataTextField = item.Horario.ToString();

                    string indexTratado = ddlHorarios.DataTextField.Replace(":00", "");
                    int index = Convert.ToInt32(indexTratado);

                    string procedDuracaoTratado = item.ProcedimentoDuracao.ToString("t").Replace(":00", "");
                    int duracao = Convert.ToInt32(procedDuracaoTratado);

                    int calculoDuracao = index + duracao;

                    if (ddlHorarios.DataTextField == item.Horario.ToString())
                    {
                        ddlHorarios.FindItemByValue(indexTratado).Enabled = false;
                        for (int j = index+1; j < calculoDuracao; j++)
                        {
                            ddlHorarios.FindItemByValue(j.ToString()).Enabled = false;
                        }
                    }   
                }
                // Solucao provisoria, necessita de melhorias como:
                // - no ultimo horario só poderá ser escolhido o procedimento de 1h de duracao
                // - respeitar intervalos entre agendamentos com tipos de procedimentos diferentes
            }  
        }

        protected void btExibirGridAgendamentos_Click(object sender, EventArgs e) // botão exibir grids agendamentos
        {
            ExibirRegistrosGridAgendamentosConcluidos();

            if (btExibirGridAgendamentos.Text == "Exibir Agendamentos Concluídos")
            {
                LimparCampos();
                gridAgendamentos.Visible = false;
                gridAgendamentosConcluidos.Visible = true;
                btExibirGridAgendamentos.Text = "Exibir Demais Agendamentos";
            }
            else if(btExibirGridAgendamentos.Text == "Exibir Demais Agendamentos")
            {
                gridAgendamentosConcluidos.Visible = false;
                gridAgendamentos.Visible = true;
                btExibirGridAgendamentos.Text = "Exibir Agendamentos Concluídos";
            }
        }

        protected void gridAgendamentos_SelectedIndexChanged(object sender, EventArgs e) // seleciona linha na grid
        {
            btSalvar.Enabled = false;
            btAtualizar.Enabled = true;
            btDeletar.Enabled = true;
            ddlClientes.Enabled = false;
            ddlEstadoAgendamento.FindItemByValue("3").Visible = true;

            Agendamento objAgendamento = new Agendamento();
            AgendamentoDAL dal = new AgendamentoDAL();

            int index = gridAgendamentos.SelectedIndex;
            int codCliente = Convert.ToInt32(gridAgendamentos.Rows[index].Cells[1].Text);

            objAgendamento = dal.ConsultarAgendamentoNaGrid(codCliente);
            txbId.Text = objAgendamento.Id.ToString();
            ddlClientes.SelectedValue = objAgendamento.ClienteId.ToString();
            CalendarAgendamento.SelectedDate = Convert.ToDateTime(objAgendamento.Data);
            ddlHorarios.SelectedText = objAgendamento.Horario;
            if(!IsPostBack)
            {
                ddlProcedimentos.SelectedValue = objAgendamento.ProcedimentoId.ToString();
            }
            txbOrcamento.Text = objAgendamento.Valor.ToString();
            ddlEstadoAgendamento.SelectedText = objAgendamento.Status.ToString();
            txaObs.Text = objAgendamento.Observacao.ToString();
        }

        protected void btAtualizar_Click(object sender, EventArgs e) // alterar agendamento
        {
            AgendamentoDAL dal = new AgendamentoDAL();
            Agendamento objAgendamento = new Agendamento();
            int codCliente = Convert.ToInt32(txbId.Text);

            if (ddlClientes.SelectedIndex < 1)
            {
                ddlClientes.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Cliente deve ser selecionado";
            }
            else if (CalendarAgendamento.SelectedDate == null)
            {
                CalendarAgendamento.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Uma Data deve ser selecionada para o agendamento";
            }
            else if (ddlHorarios.SelectedIndex < 1)
            {
                ddlHorarios.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Horário deve ser selecionado para o agendamento";
            }
            else if (ddlEstadoAgendamento.SelectedIndex < 1)
            {
                ddlEstadoAgendamento.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "Um Estado deve ser selecionado para o agendamento";
            }
            else
            {

                objAgendamento.Id = Convert.ToInt32(txbId.Text);
                objAgendamento.Data = CalendarAgendamento.SelectedDate;
                objAgendamento.Horario = ddlHorarios.SelectedText;
                objAgendamento.ProcedimentoId = Convert.ToInt32(ddlProcedimentos.SelectedValue);
                objAgendamento.Status = ddlEstadoAgendamento.SelectedText;
                objAgendamento.Observacao = txaObs.Text;

                dal.AlterarAgendamento(objAgendamento, codCliente);

                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                lbNotificacao.Text = "Alteração bem sucedida!!!";
                ExibirRegistrosGridAgendamentos();
                LimparCampos();
            }
        }

        protected void btDeletar_Click(object sender, EventArgs e) // excluir um agendamento
        {
            AgendamentoDAL dal = new AgendamentoDAL();
            Agendamento objAgendamento = new Agendamento();

            int codCliente = Convert.ToInt32(txbId.Text);

            dal.ExcluirAgendamento(codCliente);

            lbNotificacao.Visible = true;
            lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
            lbNotificacao.Text = "Agendamento excluído com sucesso!!!";
            ExibirRegistrosGridAgendamentos();
            LimparCampos();
        }

        protected void btFaturamento_Click(object sender, EventArgs e) // acessar pnl faturamento
        {
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;
            pnlCadastrarAgendamento.Visible = false;
            pnlAgendamentosRegistrados.Visible = false;
            pnlFaturamento.Visible = true;

        }

        protected void btCalcProcedimento1_Click(object sender, EventArgs e)
        {
            gridFaturamento.Visible = true;

            AgendamentoDAL dal = new AgendamentoDAL();

            gridFaturamento.DataSource = dal.ConsultarFaturamentoProcedimento1();
            gridFaturamento.DataBind();

            int totAtendimento = gridFaturamento.Rows.Count;
            decimal totValor = 0;

            for (int i = 0; i < gridFaturamento.Rows.Count; i++)
            {
                totValor += Convert.ToDecimal(gridFaturamento.Rows[i].Cells[1].Text.Replace("R$", ""));
            }

            txbQquantTotal.Text = totAtendimento.ToString();
            txbValorTotal.Text = totValor.ToString("c");
        }

        protected void btCalcProcedimento2_Click(object sender, EventArgs e)
        {
            gridFaturamento.Visible = true;

            AgendamentoDAL dal = new AgendamentoDAL();

            gridFaturamento.DataSource = dal.ConsultarFaturamentoProcedimento2();
            gridFaturamento.DataBind();

            int totAtendimento = gridFaturamento.Rows.Count;
            decimal totValor = 0;

            for (int i = 0; i < gridFaturamento.Rows.Count; i++)
            {
                totValor += Convert.ToDecimal(gridFaturamento.Rows[i].Cells[1].Text.Replace("R$", ""));
            }

            txbQquantTotal.Text = totAtendimento.ToString();
            txbValorTotal.Text = totValor.ToString("c");
        }

        protected void btCalcProcedimento3_Click(object sender, EventArgs e)
        {
            gridFaturamento.Visible = true;

            AgendamentoDAL dal = new AgendamentoDAL();

            gridFaturamento.DataSource = dal.ConsultarFaturamentoProcedimento3();
            gridFaturamento.DataBind();

            int totAtendimento = gridFaturamento.Rows.Count;
            decimal totValor = 0;

            for (int i = 0; i < gridFaturamento.Rows.Count; i++)
            {
                totValor += Convert.ToDecimal(gridFaturamento.Rows[i].Cells[1].Text.Replace("R$", ""));
            }

            txbQquantTotal.Text = totAtendimento.ToString();
            txbValorTotal.Text = totValor.ToString("c");
        }

        protected void btCalcTot_Click(object sender, EventArgs e)
        {
            gridFaturamento.Visible = true;

            AgendamentoDAL dal = new AgendamentoDAL();

            gridFaturamento.DataSource = dal.ConsultarFaturamentoTotal();
            gridFaturamento.DataBind();

            int totAtendimento = gridFaturamento.Rows.Count;
            decimal totValor = 0;

            for (int i = 0; i < gridFaturamento.Rows.Count; i++)
            {
                totValor += Convert.ToDecimal(gridFaturamento.Rows[i].Cells[1].Text.Replace("R$", ""));
            }

            txbQquantTotal.Text = totAtendimento.ToString();
            txbValorTotal.Text = totValor.ToString("c");
        }

        protected void btFechar_Click(object sender, EventArgs e)
        {
            pnlFaturamento.Visible = false;
            pnlCadastrarAgendamento.Visible = true;
            pnlAgendamentosRegistrados.Visible = true;
            txbQquantTotal.Text = null;
            txbValorTotal.Text = null;
            gridFaturamento.Visible = false;
            PageDefault();
        }
    }
}