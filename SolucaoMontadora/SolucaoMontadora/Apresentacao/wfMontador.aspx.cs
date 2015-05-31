using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.BO;
using Negocio.Model;



namespace Apresentacao
{
    public partial class wfMontador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region METODOS DO WFMONTADOR
        public void Limpar()
        {

            txtCpf.Text = "";
            txtNome.Text = "";
            txtSalario.Text = "";
            lblMsg.Text = "";
            hfID.Value = "";
        }
        public void Salvar()
        {
            Montador m = new Montador();
           
            m.Cpf = txtCpf.Text;
            m.Nome = txtNome.Text;
            m.Salario = Convert.ToDecimal(txtSalario.Text);
            MontadorBO mBO = new MontadorBO();
            mBO.Gravar(m);
        }
        public void Alterar()
        {
            Montador m = new Montador();

            m.Cpf = txtCpf.Text;
            m.Nome = txtNome.Text;
            m.Salario = Convert.ToDecimal(txtSalario.Text);
            m.Id = Convert.ToInt32(hfID.Value);
            MontadorBO mBO = new MontadorBO();
            mBO.Gravar(m);
        }
        public void Excluir()
        {
            Montador m = new Montador();
            m.Id = Convert.ToInt32(hfID.Value);
            MontadorBO mBO = new MontadorBO();
            mBO.Excluir(m);
        }
        public void BuscaPorNome(string nome)
        {
            MontadorBO mBO = new MontadorBO();
            gvMontador.DataSource = mBO.BuscarPorNome(nome);
            gvMontador.DataBind();
        }
        public void Selecionar(int id)
        {
            MontadorBO mBO = new MontadorBO();
            Montador m = new Montador();

            m = mBO.BuscarPorId(id);
            hfID.Value = m.Id.ToString();
            txtNome.Text = m.Nome;
            txtCpf.Text = m.Cpf;
            txtSalario.Text = m.Salario.ToString();

        }
        #endregion
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Salvar();
                lblMsg.Text = "Dados Gravados com Sucesso !!";
            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.Message;
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Alterar();
            }
            catch (Exception ex)
            {
                
                lblMsg.Text = ex.Message;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Excluir();
                lblMsg.Text = "Os Dados foram apagados";
                Limpar();
            }
            catch (Exception ex)
            {
                
                lblMsg.Text = ex.Message;
            }
        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            BuscaPorNome(txtBusca.Text);
        }

        protected void gvMontador_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(gvMontador.SelectedDataKey.Value);
            Selecionar(Id);
          
        }
    }
}