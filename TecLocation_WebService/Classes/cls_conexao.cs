using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;


namespace TecLocation_WebService
{
  public static class clsConexao
  {
    private static string cStringConexao = "Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=TecLocation;Data Source=LUCIANO\\Desenvolvimento;User Id=teclocation; password=teclocation;";
    private static SqlConnection cSqlConnection = null;
    private static SqlCommand cSqlCommand = null;
    private static List<clsParamentro> cParameters = null;

    public static SqlConnection cpSqlConnection
    {
      get
      {
        return cSqlConnection;
      }
    }

    public static SqlConnection abriConexao()
    {

      NameValueCollection appSettings = ConfigurationManager.AppSettings;

      cSqlConnection = new SqlConnection(cStringConexao);

      cParameters = new List<clsParamentro>();

      try
      {
        cSqlConnection.Open();
      }
      catch (SqlException Error)
      {
        throw new System.ArgumentException("NÃO FOI POSSIVEL SE CONECTAR AO SQL!\nDESCRIÇÃO DO ERRO: " + Error, "Error");
      }

      return cSqlConnection;

    }

    public static SqlConnection abriConexao(Boolean pLimparParamentos)
    {

      NameValueCollection appSettings = ConfigurationManager.AppSettings;

      cSqlConnection = new SqlConnection(cStringConexao);

      if (pLimparParamentos)
      {

        cParameters = new List<clsParamentro>();
      }

      try
      {
        cSqlConnection.Open();
      }
      catch (SqlException Error)
      {
        throw new System.ArgumentException("NÃO FOI POSSIVEL SE CONECTAR AO SQL!\nDESCRIÇÃO DO ERRO: " + Error, "Error");
      }

      return cSqlConnection;

    }

    public static void adicionaParamentro(String pNome, SqlDbType mTipo, String pValor)
    {

      if (cParameters == null)
      {
        abriConexao();
      }

      clsParamentro mParamentro = new clsParamentro();

      mParamentro.Nome = pNome;
      mParamentro.Tipo = mTipo;
      mParamentro.Valor = pValor;

      cParameters.Add(mParamentro);

    }

    public static void adicionaParamentro(String pNome, SqlDbType mTipo, Int32 pValor)
    {
      if (cParameters == null)
      {
        abriConexao();
      }

      clsParamentro mParamentro = new clsParamentro();

      mParamentro.Nome = pNome;
      mParamentro.Tipo = mTipo;
      mParamentro.Valor = pValor;

      cParameters.Add(mParamentro);

    }

    public static void executaComando(String pProcedure)
    {

      cSqlCommand = new SqlCommand(pProcedure, cSqlConnection);

      cSqlCommand.CommandType = CommandType.StoredProcedure;
      cSqlCommand.CommandTimeout = 300;

      foreach (clsParamentro mParamentro in cParameters)
      {

        cSqlCommand.Parameters.Add(mParamentro.Nome, mParamentro.Tipo);
        cSqlCommand.Parameters[mParamentro.Nome].Value = mParamentro.Valor;

      }

      cSqlCommand.ExecuteNonQuery();

      fechaConexao();

    }

    public static Object executaComando(String pProcedure, int pTamanho)
    {

      if (cSqlConnection.State == ConnectionState.Closed)
      {

        abriConexao(false);

      }
      cSqlCommand = new SqlCommand(pProcedure, cSqlConnection);

      cSqlCommand.CommandType = CommandType.StoredProcedure;
      cSqlCommand.CommandTimeout = 300;

      foreach (clsParamentro mParamentro in cParameters)
      {

        cSqlCommand.Parameters.Add(mParamentro.Nome, mParamentro.Tipo);
        cSqlCommand.Parameters[mParamentro.Nome].Value = mParamentro.Valor;

      }

      cSqlCommand.Parameters.Add("RETORNO", SqlDbType.VarChar, pTamanho).Direction = ParameterDirection.Output;

      cSqlCommand.ExecuteNonQuery();

      Object mRetorno = cSqlCommand.Parameters["RETORNO"].Value;

      fechaConexao();

      return mRetorno;

    }

    public static DataSet consultaDataset(String pProcedure)
    {

      if (cSqlConnection == null)
      {

        abriConexao();

      }
      cSqlCommand = new SqlCommand(pProcedure, cSqlConnection);
      DataSet mDataSet = new DataSet();
      SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(cSqlCommand);

      cSqlCommand.CommandType = CommandType.StoredProcedure;
      cSqlCommand.CommandTimeout = 300;

      foreach (clsParamentro mParamentro in cParameters)
      {

        cSqlCommand.Parameters.Add(mParamentro.Nome, mParamentro.Tipo);
        cSqlCommand.Parameters[mParamentro.Nome].Value = mParamentro.Valor;

      }

      mSqlDataAdapter.Fill(mDataSet);
      mSqlDataAdapter.Dispose();
      fechaConexao();

      return mDataSet;

    }

    public static DataTable consultaDataTable(String pProcedure)
    {
      if (cSqlConnection == null)
      {

        abriConexao();

      }

      cSqlCommand = new SqlCommand(pProcedure, cSqlConnection);
      DataTable mDataTable = new DataTable();
      SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(cSqlCommand);

      cSqlCommand.CommandType = CommandType.StoredProcedure;
      cSqlCommand.CommandTimeout = 300;

      foreach (clsParamentro mParamentro in cParameters)
      {

        cSqlCommand.Parameters.Add(mParamentro.Nome, mParamentro.Tipo);
        cSqlCommand.Parameters[mParamentro.Nome].Value = mParamentro.Valor;

      }

      mSqlDataAdapter.Fill(mDataTable);
      mSqlDataAdapter.Dispose();
      fechaConexao();

      return mDataTable;

    }

    public static String consultaXML(String pProcedure)
    {

      String mRetorno = "";

      if (cSqlConnection == null)
      {

        abriConexao();

      }

      cSqlCommand = new SqlCommand(pProcedure, cSqlConnection);
      SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(cSqlCommand);

      cSqlCommand.CommandType = CommandType.StoredProcedure;
      cSqlCommand.CommandTimeout = 300;

      foreach (clsParamentro mParamentro in cParameters)
      {

        cSqlCommand.Parameters.Add(mParamentro.Nome, mParamentro.Tipo);
        cSqlCommand.Parameters[mParamentro.Nome].Value = mParamentro.Valor;

      }

      XmlReader mXmlReader = cSqlCommand.ExecuteXmlReader();

      mXmlReader.Read();

      while (mXmlReader.ReadState != ReadState.EndOfFile)
      {

        mRetorno += mXmlReader.ReadOuterXml();

      }

      mXmlReader.Close();

      fechaConexao();

      return mRetorno;

    }

    public static void limpaParametros()
    {

      cParameters.Clear();

    }

    public static void fechaConexao()
    {

      if (cSqlConnection != null)
      {

        limpaParametros();
        cSqlConnection.Close();

      }
    }

  }

}