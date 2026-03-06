using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TecLocation_WebService
{
  public static class Criptografia
  {
    public static string CalculateMD5(string data)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(data);

      MD5 md5 = MD5.Create();

      byte[] bHash = md5.ComputeHash(bytes);

      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < bHash.Length; i++)
      {
        sb.Append(bHash[i].ToString("X2"));
      }

      return sb.ToString();
    }

  }
}