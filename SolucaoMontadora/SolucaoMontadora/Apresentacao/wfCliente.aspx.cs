using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.BO;
using Negocio.Model;
using Apresentacao.Helpers;

namespace Apresentacao
{
    public partial class wfCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDrop();
            }
        }
        #region METODOS DO CLIENTE
        public void SelecionaEstado(int id)
        {
            CidadeBO cBO = new CidadeBO();
            IList<Cidade> listaDeCidades = new List<Cidade>();
            listaDeCidades = cBO.BuscarCidades(id);
            dpdlCidade.DataTextField = "nome";
            dpdlCidade.DataValueField = "cidadeId";
            dpdlCidade.DataSource = listaDeCidades.OrderBy(x => x.Nome).ToList();
            dpdlCidade.DataBind();
        }
        public void CarregaDrop()
        {
            dpdlUf.DataSource = Enum.GetNames(typeof(Estado));
            dpdlUf.DataBind();

            Estado vEstado = (Estado)Enum.Parse(typeof(Estado), dpdlUf.SelectedValue);
            int id = (int)vEstado;
            CidadeBO cBO = new CidadeBO();

            IList<Cidade> listaDeCidades = new List<Cidade>();
            listaDeCidades = cBO.BuscarCidades(id);
            dpdlCidade.DataTextField = "nome";
            dpdlCidade.DataValueField = "cidadeId";
            dpdlCidade.DataSource = listaDeCidades.OrderBy(x => x.Nome).ToList();
            dpdlCidade.DataBind();


            dpdlSexo.DataSource = Enum.GetNames(typeof(Sexo));

            dpdlSexo.DataBind();
        }
        public void Salvar()
        {
            ClienteBO cBO = new ClienteBO();
            Cliente c = new Cliente();

            c.Cpf = txtCpf.Text;
            c.Nome = txtNome.Text;
            c.DataNascimento = Convert.ToDateTime(txtDtNascimento.Text);
            c.Endereco = txtEndereco.Text;
            c._Sexo = (Sexo)Enum.Parse(typeof(Sexo), dpdlSexo.SelectedValue);
            c.Cidade = new ClienteBO().BuscaCidade(Convert.ToInt32(dpdlCidade.SelectedValue));
            c.Numero = txtNumero.Text;
            c.OrgaoExpedidor = txtOrgaoExpedidor.Text.ToUpper();
            c.Rg = txtRg.Text;
            cBO.Gravar(c);


        }
        public void LimpaCampo()
        {
            txtCpf.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtOrgaoExpedidor.Text = "";
            txtRg.Text = "";
            txtLocalizar.Text = "";
            lblMsg.Text = "";
            hfId.Value = "";
            txtDtNascimento.Text = "";
        }
        public void Apagar()
        {
            Cliente c = new Cliente();
            c.Id = Convert.ToInt32(hfId.Value);
            ClienteBO cBO = new ClienteBO();
            cBO.Excluir(c);

        }
        public void BuscarPorNome(string nome)
        {
            ClienteBO cBO = new ClienteBO();
            gvCliente.DataSource = cBO.BuscarPorNome(nome);
            gvCliente.DataBind();

        }
        public void Alterar()
        {
            Cliente c = new Cliente();
            c.Id = Convert.ToInt32(hfId.Value);
            c.Nome = txtNome.Text;
            c.Cpf = txtCpf.Text;
            c.Endereco = txtEndereco.Text;
            c.DataNascimento = Convert.ToDateTime(txtDtNascimento.Text);
            c._Sexo = (Sexo)Enum.Parse(typeof(Sexo), dpdlSexo.SelectedValue);
            c.Cidade = new ClienteBO().BuscaCidade(Convert.ToInt32(dpdlCidade.SelectedValue));
            c.Numero = txtNumero.Text;
            c.OrgaoExpedidor = txtOrgaoExpedidor.Text.ToUpper();
            c.Rg = txtRg.Text;
            ClienteBO cBO = new ClienteBO();
            c.Cidade = cBO.BuscaCidade(Convert.ToInt32(dpdlCidade.SelectedValue));
            cBO.Gravar(c);
        }
        public void Selecionar(int id)
        {

            Cliente c = new Cliente();
            c = new ClienteBO().BuscarPorid(id);
            hfId.Value = c.Id.ToString();
            txtCpf.Text = c.Cpf;
            txtNome.Text = c.Nome;
            txtNumero.Text = c.Numero;
            txtEndereco.Text = c.Endereco;
            txtRg.Text = c.Rg;
            txtDtNascimento.Text = c.DataNascimento.ToShortDateString();
            txtOrgaoExpedidor.Text = c.OrgaoExpedidor;
            txtDtNascimento.Text = c.DataNascimento.ToString();
            dpdlUf.SelectedValue = c.Cidade.Estado.ToString();
            dpdlCidade.SelectedItem.Text = c.Cidade.Nome;
            dpdlSexo.SelectedValue = c._Sexo.ToString();
            

        }
        #endregion
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Salvar();

            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.Message;
            }
        }
        protected void dpdlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado vEstado = (Estado)Enum.Parse(typeof(Estado), dpdlUf.SelectedValue);
            int id = (int)vEstado;
            SelecionaEstado(id);
        }

        protected void dpdlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sexo idSexo = (Sexo)Enum.Parse(typeof(Sexo), dpdlSexo.SelectedValue);
            int sexoId = (int)idSexo;
        }
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaCampo();
            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.Message;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorNome(txtLocalizar.Text);
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvCliente.SelectedDataKey.Value);
            Selecionar(id);
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Alterar();
                lblMsg.Text = "Dados Alterado com Sucesso!";
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
                Apagar();
                lblMsg.Text = "Foi Excluido com Sucesso !!";
            }
            catch (Exception ex)
            {
                
                lblMsg.Text = ex.Message;
            }
        }

        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCliente.PageIndex = e.NewPageIndex;
            
        }

       

       
    }
}