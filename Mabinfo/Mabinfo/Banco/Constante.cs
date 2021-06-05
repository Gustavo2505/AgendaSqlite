using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mabinfo.Banco
{
   public static class Constante
    {
        public const string NomeDoArquivo = "AppTarefa.db3";

 
        public static string CaminhoDoBanco
        {
            get
            {
                var caminhoBanco = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(caminhoBanco, NomeDoArquivo);
            }
        }
    }
}

