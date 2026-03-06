using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecLocation_WebService
{
  public static class DiaSemana
  {

    public static String retorna_Dia_Semana()
    {
      String mRetorno = "";

      mRetorno += "<SEM>";

      mRetorno += "<Id_Semana>1</Id_Semana>";
      mRetorno += "<Nm_Semana>Segunda-Feira</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>2</Id_Semana>";
      mRetorno += "<Nm_Semana>Terça-Feira</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>3</Id_Semana>";
      mRetorno += "<Nm_Semana>Quarta-Feira</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>4</Id_Semana>";
      mRetorno += "<Nm_Semana>Quinta-Feira</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>5</Id_Semana>";
      mRetorno += "<Nm_Semana>Sexta-Feira</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>6</Id_Semana>";
      mRetorno += "<Nm_Semana>Sábado</Nm_Semana>";
      mRetorno += "</SEM><SEM>";
      mRetorno += "<Id_Semana>7</Id_Semana>";
      mRetorno += "<Nm_Semana>Domingo</Nm_Semana>";
      mRetorno += "</SEM>";

      return mRetorno;

    }

  }
}