using Unity;
using HouseofCat.DependencyInjection.WebForms.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebAgendaCodeFirst.DAL;
using WebAgendaCodeFirst.Models;

namespace WebAgendaCodeFirst
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // config unity DI - adicionando a chamada para criar o contêiner

            var container = this.AddUnity();

            container.RegisterType<IClienteDAL, ClienteDAL>();
            container.RegisterType<ICliente, Cliente>();
            container.RegisterType<IProcedimentosDAL, ProcedimentoDAL>();
            container.RegisterType<AProcedimento, Procedimento>();
        }
    }
}