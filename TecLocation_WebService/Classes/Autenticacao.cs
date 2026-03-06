using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace TecLocation_WebService
{
  public class Autenticacao : SoapHeader
  {
    private string cGuid;

    public string Guid {
      get { return cGuid; }
      set { cGuid = value;}
    }

    public Autenticacao() : base() 
    {

    }

    public Autenticacao(string pGuid) : base()
    {
      cGuid = pGuid;
    }

  }
}