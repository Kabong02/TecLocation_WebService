using System.Xml;
using System.Data;
using System.Web.Services;
using System.Xml.Linq;
using System.Linq;
using System.IO.Compression;
using System;
using System.IO;
using System.Text;
using System.Web.Services.Protocols;
using System.Collections.Generic;

namespace TecLocation_WebService
{

  [WebService(Namespace = "http://www.TecLocation.com.br/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]

  public class cls_Operacoes : WebService
  {
    public Autenticacao Authentication;
    private string cGuid = "F20DFF91-1114-4590-83B1-DB0E5D121280";

    [WebMethod]
    //[SoapHeader("Authentication")]
    public string autentica_login(string pLogin, string pSenha)
    {

      string mRetorno;

      try
      {

        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Nm_Login", SqlDbType.NVarChar, pLogin);
        clsConexao.adicionaParamentro("Nm_Senha", SqlDbType.NVarChar, Criptografia.CalculateMD5(pSenha));
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Usuario_Login");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("USUÁRIO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_professores()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Professores");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }
      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_turmas()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Turmas");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_semana()
    {

      string mRetorno = "";

      try
      {

        mRetorno = DiaSemana.retorna_Dia_Semana();

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }
    
    [WebMethod]
    public string obtem_salas()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Salas");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }
    
    [WebMethod]
    public string obtem_aulas(string pId_Professor,string pId_Dia_Semana, string pId_Turma)
    {

      string mRetorno = "";

      try
      {
        clsConexao.abriConexao();
        if (pId_Professor != "") {clsConexao.adicionaParamentro("Id_Professor", SqlDbType.NVarChar, pId_Professor);}
        clsConexao.adicionaParamentro("Id_Dia_Semana", SqlDbType.NVarChar, pId_Dia_Semana);
        clsConexao.adicionaParamentro("Id_Turma", SqlDbType.NVarChar, pId_Turma);
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Aulas");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else {

          throw new Exception("OPERCAÇÃO INVÁLIDO!");

        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }
    
    [WebMethod]
    public string obtem_especialidades()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Especialidades");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_usuario_especialidades()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Usuario_Especialidades");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_motivos_ausencia()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Motivo_Ausencia");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string obtem_notificacoes(string pId_Usuario)
    {

      string mRetorno = "";
            
      try
      {

        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Id_Usuario", SqlDbType.Int, pId_Usuario);
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Usuario_Notificacao");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return "";

    }

    [WebMethod]
    public string atualiza_notificacao(string pId_Usuario_Notificacao)
    {

      string mRetorno = "<ASN><RESULTADO>true<RESULTADO><ASN>";

      try
      {
        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Id_Usuario_Notificacao", SqlDbType.Int, pId_Usuario_Notificacao);
        clsConexao.executaComando("Mob_Spr_Upd_Usuario_Notificacao");
        
        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return "";

    }

    [WebMethod]
    public string atualiza_sala(string pId_Sala, string pId_Aula)
    {
      string mRetorno = "<SAL><RESULTADO>true<RESULTADO><SAL>";

      try
      {

        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Id_Aula", SqlDbType.Int, pId_Aula);
        clsConexao.adicionaParamentro("Id_Sala", SqlDbType.Int, pId_Sala);
        clsConexao.executaComando("Mob_Spr_Upd_Sala_Aula");
        
      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return Convert.ToBase64String(zip_string(mRetorno));

    }

    [WebMethod]
    public string atualiza_aula(string pId_Aula, string pId_Havera_Aula, string pId_Motivo_Ausencia, string pDescricao)
    {
      string mRetorno = "<SAL><RESULTADO>true<RESULTADO><SAL>";

      try
      {

        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Id_Aula", SqlDbType.Int, pId_Aula);
        if (pId_Havera_Aula.Equals("1")) {clsConexao.adicionaParamentro("Id_Havera_Aula", SqlDbType.Bit, "true");}
        clsConexao.adicionaParamentro("Id_Motivo_Ausencia", SqlDbType.Int, pId_Motivo_Ausencia);
        clsConexao.adicionaParamentro("Nm_Descricao", SqlDbType.NVarChar, pDescricao);

        clsConexao.executaComando("Mob_Spr_Upd_Motivo_Ausencia_Aula");

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return Convert.ToBase64String(zip_string(mRetorno));

    }

    [WebMethod]
    public string atualiza_senha(string pLogin, string pSenha)
    {
      string mRetorno = "<ASN><RESULTADO>true<RESULTADO><ASN>";

      try
      {
        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Nm_Login", SqlDbType.NVarChar, pLogin);
        clsConexao.adicionaParamentro("Nm_Senha", SqlDbType.NVarChar, Criptografia.CalculateMD5(pSenha));
        clsConexao.executaComando("Mob_Spr_Upd_Usuario_Senha");

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return Convert.ToBase64String(zip_string(mRetorno));

    }

    [WebMethod]
    public string solicitacao_notificacao(string pId_Aula, string pId_Usuario)
    {
      string mRetorno = "<ASN><RESULTADO>true<RESULTADO><ASN>";

      try
      {


        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Id_Usuario", SqlDbType.Int, pId_Usuario);
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Usuario_Notificacao");

        if (mRetorno.Length > 0) { 

          clsConexao.abriConexao();
          clsConexao.adicionaParamentro("Id_Aula", SqlDbType.Int, pId_Aula);
          clsConexao.adicionaParamentro("Id_Usuario", SqlDbType.Int, pId_Usuario);
          clsConexao.executaComando("Mob_Spr_Ins_Usuario_Notificacao");

        }
      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

      return Convert.ToBase64String(zip_string(mRetorno));

    }

    [WebMethod]
    public string verifica_atualizacao()
    {

      string mRetorno = "";

      try
      {

        clsConexao.abriConexao();
        mRetorno = clsConexao.consultaXML("Mob_Spr_Sel_Versao");

        if (mRetorno.Length > 0)
        {

          return Convert.ToBase64String(zip_string(mRetorno));

        }
        else
        {
          throw new Exception("OPERCAÇÃO INVÁLIDO!");
        }

      }
      catch (System.Exception ex)
      {

        throw new System.Exception(ex.Message);
      }

    }

    [WebMethod]
    public string envia_email(string pLogin, string pCodigo ) {

      string mRetorno = "<EML><Id_Enviado>[Id_Enviado]</Id_Enviado><MENSAGEM>[MENSAGEM]</MENSAGEM></EML>";

      try
      {
        

        clsConexao.abriConexao();
        clsConexao.adicionaParamentro("Nm_Login", SqlDbType.NVarChar, pLogin);
        DataTable mDataTable = clsConexao.consultaDataTable("Mob_Spr_Sel_Usuario_Email");

        if (mDataTable.Rows.Count > 0)
        {

          List<String> pDestinatarios = new List<String>();

          pDestinatarios.Add(mDataTable.Rows[0]["Nm_Email"].ToString());

          if (Email.envia_email(pDestinatarios, null, "RECUPERAÇÃO DE SENHA", pCodigo)) {

            String mMensagem = "Um e-mail contendo o código de recuperação foi enviado para: " + (mDataTable.Rows[0]["Nm_Email"].ToString().Split(new Char[] { '@' }))[0].Substring(0, 5);
            mMensagem += "....@" + mDataTable.Rows[0]["Nm_Email"].ToString().Split(new Char[] { '@' })[1];

            return Convert.ToBase64String(zip_string(mRetorno.Replace("[Id_Enviado]", "true").Replace("[MENSAGEM]", mMensagem)));

          }

        }

      }
      catch (Exception)
      {
        throw;
      }

      return Convert.ToBase64String(zip_string(mRetorno.Replace("[Id_Enviado]", "false").Replace("[MENSAGEM]", "Não foi encontrando e-mail correspondente, Por favor contate o Administrador")));

    }
    
    private bool Autenticacao()
    {

      if (Authentication != null && !string.IsNullOrEmpty(Authentication.Guid))
      {
        if (Authentication.Guid.Equals(cGuid))
        {
          return true;
        }
        else {
          return false;
        }
      }
      else {
        return false;
      }

    }

    public static byte[] zip_string(string pString)
    {
      var bytes = Encoding.UTF8.GetBytes(pString);

      using (var mMemoryStreamInput = new MemoryStream(bytes))
      using (var mMemoryStreamOut = new MemoryStream())
      {
        using (var mGZipStream = new GZipStream(mMemoryStreamOut, CompressionMode.Compress))
        {
          copia(mMemoryStreamInput, mGZipStream);
        }

        return mMemoryStreamOut.ToArray();
      }
    }

    public static void copia(Stream pInput, Stream pOut)
    {
      int i;
      byte[] bytes = new byte[4096];

      while ((i = pInput.Read(bytes, 0, bytes.Length)) != 0)
      {
        pOut.Write(bytes, 0, i);
      }
    }

    public static string unzip_string(byte[] pBytes)
    {
      using (var mMemoryStreamInput = new MemoryStream(pBytes))
      using (var mMemoryStreamOut = new MemoryStream())
      {
        using (var mGZipStream = new GZipStream(mMemoryStreamInput, CompressionMode.Decompress))
        {
          copia(mGZipStream, mMemoryStreamOut);
        }

        return Encoding.UTF8.GetString(mMemoryStreamOut.ToArray());
      }
    }
    
  }
}
