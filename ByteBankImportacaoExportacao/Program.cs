﻿using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output


namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var enderecoDoArquivo = "contas.txt";
            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDeArquivo);
                var linha = leitor.ReadToEnd();
            }

        }
    }
}

