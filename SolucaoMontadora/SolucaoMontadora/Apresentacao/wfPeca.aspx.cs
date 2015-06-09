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
    public partial class wfPeca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region
        public void CarregaDrop()
        {
            //FornecedorBO fBO = new FornecedorBO();
            //dpdlFornecedor.DataSource = fBO.BuscarPorId
        }
        #endregion

        protected void dpdlFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}