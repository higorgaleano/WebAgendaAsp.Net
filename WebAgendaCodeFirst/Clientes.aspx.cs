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
    public partial class Clientes : System.Web.UI.Page
    {
        // ctor com Injeção de Dependência

        private IClienteDAL dal;
        private ICliente objCliente;

        protected Clientes()
        {

        }

        public Clientes(IClienteDAL dal, ICliente objCliente)
        {
            this.dal = dal;
            this.objCliente = objCliente;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btExcluir.Visible = pnlCadastroCliente.Visible = false;
                DefaultCheckAtivo();
            }
        }

        protected void LimpaCampos()
        {
            txbId.Text = "";
            txbNome.Text = "";
            txbTelefone.Text = "";
            txbNascimento.Text = "";
            TextAreaObs.Value = "";
            btSalvar.Text = "Cadastrar";
            btCancelar.Text = "Limpar";
            btExcluir.Text = "Excluir";
            lbNotificacaoExcluir.Visible = false;
            txbExcluir.Visible = false;
            txbExcluir.Text = "";
            CheckClienteAtivo.Enabled = false;
            DesfazerSelecaoGrid();
            pnlCadastroCliente.ForeColor = System.Drawing.Color.Black;

            if(btExibirGrid.Text == "Mostrar Clientes Ativos")
            {
                btSalvar.Enabled = false;
                btCancelar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        protected void DesabilitaCampos()
        {
            txbNome.Enabled = false;
            txbTelefone.Enabled = false;
            txbNascimento.Enabled = false;
            TextAreaObs.Disabled = true;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;
            btExcluir.Enabled = false;
            lbNotificacaoExcluir.Visible = false;
            txbExcluir.Visible = false;

        }

        protected void HabilitaCampos()
        {
            txbNome.Enabled = true;
            txbTelefone.Enabled = true;
            txbNascimento.Enabled = true;
            TextAreaObs.Disabled = false;
            btSalvar.Enabled = true;
            btCancelar.Enabled = true;
            btExcluir.Enabled = true;
        }

        protected void DesfazerSelecaoGrid()
        {
            gridClientesAtivos.SelectedIndex = -1;
            gridClientesInativos.SelectedIndex = -1;
        }

        protected void DefaultCheckAtivo()
        {
            CheckClienteAtivo.Enabled = false;
            CheckClienteAtivo.Checked = true;
        }

        protected void btAbrirCadastro_Click(object sender, EventArgs e)
        {
            if(pnlCadastroCliente.Visible == false)
            {
                pnlCadastroCliente.Visible = true;
                btAbrirCadastro.Text = "Fechar Cadastro de Novo Cliente";
                LimpaCampos();
            }
            else
            {
                pnlCadastroCliente.Visible = false;
                btAbrirCadastro.Text = "Cadastrar Novo Cliente";
            }
            
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            lbNotificacao.Visible = false;
            
        }

        protected void btExibirGrid_Click(object sender, EventArgs e) // botão grid
        {
            pnlCadastroCliente.ForeColor = System.Drawing.Color.Black;
            lbNotificacao.Visible = false;            
            LimpaCampos();

            // clientes inativos
            if (btExibirGrid.Text == "Mostrar Clientes Inativos")
            {
                pnlCadastroCliente.GroupingText = "Cadastro/Alteração de Clientes Inativos";
                pnlExibicaoCliente.GroupingText = "Registro dos Clientes Inativos";
                gridClientesAtivos.Visible = false;
                gridClientesInativos.Visible = true;
                btExibirGrid.Text = "Mostrar Clientes Ativos";
                DesabilitaCampos();
                CheckClienteAtivo.Checked = false;
                btExcluir.Visible = true;
                btAbrirCadastro.Visible = false;
            }
            // clientes ativos
            else
            {
                pnlCadastroCliente.GroupingText = "Cadastro/Alteração de Clientes Ativos";
                pnlExibicaoCliente.GroupingText = "Registro dos Clientes Ativos";
                gridClientesAtivos.Visible = true;
                gridClientesInativos.Visible = false;
                btExibirGrid.Text = "Mostrar Clientes Inativos";
                HabilitaCampos();
                DefaultCheckAtivo();
                btExcluir.Visible = false;
                btAbrirCadastro.Visible= true;
            }
        }

        protected void btSalvar_Click(object sender, EventArgs e) // insert e update
        {
            objCliente.Nome = txbNome.Text;
            objCliente.Telefone = txbTelefone.Text;
            objCliente.Nascimento = txbNascimento.Text;
            objCliente.Observacao = TextAreaObs.Value;
            objCliente.Ativo = CheckClienteAtivo.Checked;

            if (txbNome.Text == "")
            {
                txbNome.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Nome deve ser preenchido";
            }
            else if (txbTelefone.Text == "")
            {
                txbTelefone.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Telefone deve ser preenchido";
            }
            else if (txbNascimento.Text == "")
            {
                txbNascimento.Focus();
                lbNotificacao.Visible = true;
                lbNotificacao.ForeColor = System.Drawing.Color.IndianRed;
                lbNotificacao.Text = "O campo Data de Nascimento deve ser preenchido";
            }
            else
            {
                if (btSalvar.Text == "Cadastrar") // insert cliente
                {
                    dal.CadastrarCliente((Cliente)objCliente);

                    lbNotificacao.Visible = true;
                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Cliente cadastrado com sucesso!!!"; 
                }
                else if (btSalvar.Text == "Alterar") // update cliente
                {
                    int codCliente = Convert.ToInt32(txbId.Text);
                    dal.AlterarCliente((Cliente)objCliente, codCliente);
                                        
                    lbNotificacao.Visible = true;
                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Alteração bem sucedida!!!";
                }
                gridClientesAtivos.DataBind();
                gridClientesInativos.DataBind();
                LimpaCampos();
            }   
        }

        protected void gridClientesAtivos_SelectedIndexChanged(object sender, EventArgs e) // select clientes ativos
        {            
            pnlCadastroCliente.Visible = true;
            btAbrirCadastro.Text = "Fechar Cadastro de Novo Cliente";

            int index = gridClientesAtivos.SelectedIndex;
            int codCliente = Convert.ToInt32(gridClientesAtivos.Rows[index].Cells[1].Text);
                        
            objCliente = dal.ConsultarCliente(codCliente);

            txbId.Text = objCliente.Id.ToString();
            txbNome.Text = objCliente.Nome;
            txbTelefone.Text = objCliente.Telefone;
            txbNascimento.Text = Convert.ToDateTime(objCliente.Nascimento).ToString("yyyy-MM-dd");
            TextAreaObs.Value = objCliente.Observacao;
            CheckClienteAtivo.Enabled = true;
            CheckClienteAtivo.Checked = Convert.ToBoolean(objCliente.Ativo);
            btSalvar.Text = "Alterar";

            pnlCadastroCliente.ForeColor = System.Drawing.Color.ForestGreen;
        }

        protected void gridClientesInativos_SelectedIndexChanged(object sender, EventArgs e) // select clientes inativos
        {
            pnlCadastroCliente.Visible = true;
            
            int index = gridClientesInativos.SelectedIndex;
            int codCliente = Convert.ToInt32(gridClientesInativos.Rows[index].Cells[1].Text);

            objCliente = dal.ConsultarCliente(codCliente);

            txbId.Text = objCliente.Id.ToString();
            txbNome.Text = objCliente.Nome;
            txbTelefone.Text = objCliente.Telefone;
            txbNascimento.Text = Convert.ToDateTime(objCliente.Nascimento).ToString("yyyy-MM-dd");
            TextAreaObs.Value = objCliente.Observacao;
            CheckClienteAtivo.Checked = false;
            CheckClienteAtivo.Checked = (Convert.ToBoolean(objCliente.Ativo));
            btSalvar.Text = "Alterar";
            
            CheckClienteAtivo.Enabled = true;
            btSalvar.Enabled = true;
            btCancelar.Enabled = true;
            btExcluir.Enabled = true;
            pnlCadastroCliente.ForeColor = System.Drawing.Color.IndianRed;
        }

        protected void btExcluir_Click(object sender, EventArgs e) // delete clientes
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
                    dal.ExcluirCliente(codCliente);

                    lbNotificacao.ForeColor = System.Drawing.Color.ForestGreen;
                    lbNotificacao.Text = "Cliente excluído com sucesso!!!";
                    gridClientesInativos.DataBind();
                    LimpaCampos();
                }
            }
 
        }
    }
}