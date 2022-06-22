using ByteBankImportacaoExportacao.Modelos;
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
            // ele procura o arquivo na pasta onde esta o executável
            var enderecoDoArquivo = "contas.txt";
            using (var fluxoDeArquivo = new FileStream("_teste.txt", FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    System.Console.WriteLine($"{contaCorrente.Titular.Nome}: conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}");
                }
            }
            Console.ReadLine();
        }
        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');
            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nome = campos[3];
            var titular = new Cliente();
            titular.Nome = nome;
            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;
            return resultado;

        }
    }
}

