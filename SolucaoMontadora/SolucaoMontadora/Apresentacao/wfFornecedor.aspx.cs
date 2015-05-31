using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.BO;

namespace Apresentacao
{
    public partial class wfFornecedor : System.Web.UI.Page
    {
       
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region
        public void Limpar()
        {
            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            lblMsg.Text = "";
            txtNome.Focus();
        }
        public void Salvar()
        {
            Fornecedor f = new Fornecedor();
            FornecedorBO fBO = new FornecedorBO();
            f.Cpf = txtCpf.Text;
            f.Nome = txtNome.Text;
            f.Endereco = txtEndereco.Text;
            fBO.Gravar(f);
            
        }
        public void Alterar()
        {
            Fornecedor f = new Fornecedor();
            FornecedorBO fBO = new FornecedorBO();
            f.Cpf = txtCpf.Text;
            f.Nome = txtNome.Text;
            f.Endereco = txtEndereco.Text;
            fBO.Gravar(f);
            
        }
        public void Excluir()
        {
            Fornecedor f = new Fornecedor();
            
            f.Id = Convert.ToInt32(hfId.Value);
            FornecedorBO fBO = new FornecedorBO();
            fBO.Apagar(f);
            
        }
        public void BuscarPorNome(string nome)
        {
            FornecedorBO fBO = new FornecedorBO();
            gvFornecedor.DataSource = fBO.BuscarPorFornecedor(nome);
            gvFornecedor.DataBind();
         
            
        }
        public void Selecionar(int id)
        {
            Fornecedor f = new Fornecedor();
            FornecedorBO fBO = new FornecedorBO();
            f = fBO.BuscarPorId(id);
            hfId.Value = f.Id.ToString();
            txtCpf.Text = f.Cpf;
            txtEndereco.Text = f.Endereco;
            txtNome.Text = f.Nome;
           
            
        }
        #endregion

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                Salvar();
                lblMsg.Text = "Os Dados foi Gravado com Sucess!!";
               
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
        
        protected void gvFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(gvFornecedor.SelectedDataKey.Value);
            Selecionar(Id);
            lblMsg.Text = "";

        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            BuscarPorNome(txtLocalizar.Text);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Excluir();
                lblMsg.Text = "Excluido com Sucesso!!";
            }
            catch (Exception ex)
            {
                
                lblMsg.Text = ex.Message;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }
    }
}