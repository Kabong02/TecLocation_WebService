using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;



namespace TecLocation_WebService
{
  public static class Email
  {
      private static String cLoginGmail;
      private static String cSenhaGmail;
      private static String cHostSMTP;

      public static Boolean envia_email(List<String> pDestinatarios, List<String> pDestinatariosOcultos, String pAssunto, String pMensagem)
      {

        NameValueCollection appSettings = ConfigurationManager.AppSettings;

        cLoginGmail = appSettings.Get("LoginGmail");
        cSenhaGmail = appSettings.Get("SenhaGmail");
        cHostSMTP = appSettings.Get("HostSMTP");
        SmtpClient mSMTP = new SmtpClient();

        if (cLoginGmail != null & cSenhaGmail != null & cHostSMTP != null)
        {

          try
          {

            MailMessage mEmail = new MailMessage();
            mEmail.From = new MailAddress(cLoginGmail);

            if (pDestinatarios.Count == 0)
            {

              throw new System.ArgumentException("NÃO FOI ENCONTRADO DESTINATÁRIOS!", "Error");

            }
            else
            {
              foreach (String mItem in pDestinatarios)
              {

                mEmail.To.Add(mItem);

              }
            }


            if (pDestinatariosOcultos != null && pDestinatariosOcultos.Count > 0)
            {

              foreach (String mItem in pDestinatariosOcultos)
              {

                mEmail.Bcc.Add(mItem);

              }
            }

            mEmail.Priority = MailPriority.Normal;
            mEmail.IsBodyHtml = true;
            mEmail.Subject = pAssunto;
            mEmail.Body = constroiMensagem(pMensagem);
            mEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            mEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            mSMTP.Host = cHostSMTP;
            mSMTP.EnableSsl = true;
            mSMTP.Port = 587;
            mSMTP.Credentials = new NetworkCredential(cLoginGmail, cSenhaGmail);
            mSMTP.Send(mEmail);

          }
          catch (Exception Error)
          {
            throw Error;// new System.ArgumentException("NÃO FOI POSSIVEL ENVIAR O EMAIL!\nDESCRIÇÃO DO ERRO: " + Error, "Error");
          }
        }
        else { return false; }

        return true;
      }

      private static String constroiMensagem(String pMensagem)
      {

        String mMensagem = "";

        StreamReader mReader = new StreamReader(HttpContext.Current.Server.MapPath("~/Template/EmailTemplate.html"));

        String mReadFile = mReader.ReadToEnd();

        mMensagem = mReadFile;
        mMensagem = mMensagem.Replace("[Mensagem]", pMensagem);

        return mMensagem;
      }
    }
  }
