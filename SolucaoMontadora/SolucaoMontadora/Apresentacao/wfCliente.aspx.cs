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
    public partial class wfCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            c._Sexo = (Sexo)Enum.Parse(typeof(Sexo),dpdlSexo.SelectedValue);
            c.Cidade = new ClienteBO().BuscaCidade(Convert.ToInt32(dpdlCidade.SelectedValue));
            c.Numero = txtNumero.Text;
            c.OrgaoExpedidor = txtOrgaoExpedidor.Text;
            c.Rg = txtRg.Text;
            cBO.Gravar(c);


        }
        #endregion


        protected void btnGravar_Click(object sender, EventArgs e)
        {
            Salvar();

        }

        protected void dpdlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado vEstado = (Estado)Enum.Parse(typeof(Estado), dpdlUf.SelectedValue);
            int id = (int)vEstado;
            SelecionaEstado(id);
            
        }

      
        




    }
}