using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAgendaCodeFirst.DAL;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst
{
    public partial class Procedimentos : System.Web.UI.Page
    {
        private IProcedimentosDAL dal;
        private AProcedimento objProcedimento;

        protected Procedimentos()
        { 
        }

        public Procedimentos(IProcedimentosDAL dal, AProcedimento objProcedimento)
        {
            this.dal = dal;
            this.objProcedimento = objProcedimento;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlCadastroProcedimento.Visible = false;
            }

            ExibirRegistrosGridProcedimento();

        }

        // dataSource recebe dal e exibe registros no gridview
        protected void ExibirRegistrosGridProcedimento() 
        {            
            // conexão datasource recebe dal            
            gridProcedimentos.DataSource = dal.ExibirGridProcedimento();
            gridProcedimentos.DataBind();
        }

        protected void LimpaCampos()
        {
            txbId.Text = "";
            txbNome.Text = "";
            txbDuracao.Text = "";
            txbValor.Text = "";
            txbExcluir.Text = "";
            txbExcluir.Visible = false;
            gridProcedimentos.SelectedIndex = -1;
            btSalvar.Text = "Cadastrar";
            lbNotificacaoExcluir.Visible = false;
            btExcluir.Visible = false;
            btExibirCadastroProcedimento.Text = "Cadastrar Novo Procedimento";

        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            lbNotificacao.Visible = false;
        }

        protected void btExibirCadastroProcedimento_Click(object sender, EventArgs e) //botao exibir form
        {
            if (btExibirCadastroProcedimento.Text == "Cadastrar Novo Procedimento")
            {
                pnlCadastroProcedimento.Visible = true;
                btExibirCadastroProcedimento.Text = "Fechar Cadastro de novo Procedimento";
            }
            else
            {
                pnlCadastroProcedimento.Visible = false;
                btExibirCadastroProcedimento.Text = "Cadastrar Novo Procedimento";
                LimpaCampos();
            }
        }

        protected void btSalvar_Click(object sender, EventArgs e) // insert e update
        {
            if (txbNome.Text == "")
            {
                txbNome.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Nome do Procedimento deve ser preenchido";
            }
            else if (txbDuracao.Text == "")
            {
                txbDuracao.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Tempo de Duração deve ser preenchido";
            }
            else if (txbValor.Text == "")
            {
                txbValor.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Valor deve ser preenchido";
            }
            else
            {
                objProcedimento.Nome = txbNome.Text;
                objProcedimento.Duracao = Convert.ToDateTime(txbDuracao.Text);
                objProcedimento.Valor = Convert.ToDecimal(txbValor.Text);

                if (btSalvar.Text == "Cadastrar") // insert procedimento
                {
                    dal.CadastrarProcedimento((Procedimento)objProcedimento);

                    lbNotificacao.Visible = true;
                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Procedimento cadastrado com sucesso!!!";

                }
                else if (btSalvar.Text == "Alterar") // update procedimento
                {
                    int codCliente = Convert.ToInt32(txbId.Text);
                    dal.AlterarProcedimento((Procedimento)objProcedimento, codCliente);

                    lbNotificacao.Visible = true;
                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Alteração bem sucedida!!!";
                }
            }
            ExibirRegistrosGridProcedimento();
            LimpaCampos();
              
        }

        protected void gridProcedimentos_SelectedIndexChanged(object sender, EventArgs e) // select procedimentos
        {
            pnlCadastroProcedimento.Visible = true;
            btExibirCadastroProcedimento.Text = "Fechar Cadastro de novo Procedimento";

            int index = gridProcedimentos.SelectedIndex;
            int codCliente = Convert.ToInt32(gridProcedimentos.Rows[index].Cells[1].Text);

            objProcedimento = dal.ConsultarProcedimento(codCliente);

            txbId.Text = objProcedimento.Id.ToString();
            txbNome.Text = objProcedimento.Nome;
            txbDuracao.Text = Convert.ToDateTime(objProcedimento.Duracao).ToString("t");
            txbValor.Text = objProcedimento.Valor.ToString();
            btSalvar.Text = "Alterar";
            btExcluir.Visible = true;
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            lbNotificacao.Visible = true;
            lbNotificacaoExcluir.ForeColor = System.Drawing.Color.IndianRed;
            lbNotificacaoExcluir.Visible = true;
            txbExcluir.Visible = true;
            btExcluir.Text = "Confirmar Exclusão";
            lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;

            if (btExcluir.Text == "Confirmar Exclusão")
            {
                if (txbExcluir.Text == "")
                {
                    lbNotificacao.Text = "";
                }
                else if (txbExcluir.Text != "Excluir")
                {
                    txbExcluir.Focus();
                    lbNotificacao.Text = "Resposta inválida, tente novamente";
                }
                else
                {
                    int codCliente = Convert.ToInt32(txbId.Text);
                    dal.ExcluirProcedimento(codCliente);

                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Procedimento excluído com sucesso!!!";
                    ExibirRegistrosGridProcedimento();
                    LimpaCampos();
                }
            }
        }
    }
}