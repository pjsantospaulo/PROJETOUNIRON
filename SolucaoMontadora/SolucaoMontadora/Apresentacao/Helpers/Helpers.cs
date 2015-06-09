using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Apresentacao.Helpers
{
    public static class Helpers
    {
        public static void LimpaCampo(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }

                if (c is Panel)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                    }
                }
            }
        }
    }
}