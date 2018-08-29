using System;
using System.Linq;

namespace _001_Tratar_Retorno_Multipls_Linhas
{
    class Program
    {
        static void Main(string[] args)
        {
            String retorno = @"  |---------- Registro De Qualquer_Coisa -----------------------------------------------------------
  | Begin  : 29/08/2018 10:03:37
  | End    : 29/08/2018 10:03:41
  | Duration: 00:00:03:887
  | Dados do processamento :
  |  Erro na tentativa de coisar online Qualquer_Coisa 11437006: 
  |  Erro retornado pelo serviço de registro de Qualquer_Coisa:
  |  $dy51af1 - $oi0mvmv - 9017 - data limite menor que data atual
  |  
  |  
  |  
  |  
  |  
  |-------------------------------------------------------------------------------------------------";
            Console.WriteLine(retorno);
            Console.WriteLine("\n\n");
            retorno = RetornarMensagemTratada(retorno);
            Console.WriteLine(retorno);
            Console.WriteLine("Fim.");
            Console.ReadKey();
        }

        static String RetornarMensagemTratada(String retorno)
        {
            String[] lines =
                retorno.
                Split(new[] { Environment.NewLine }, StringSplitOptions.None).
                Select(x => x.Replace("-", "").Replace("|", "").Trim()).
                Where(x => !String.IsNullOrEmpty(x)).
                ToArray();

            String[] lines_new = new String[lines.Length];

            for (int i = 5, j = 0; i < lines.Length; i++, j++)
                lines_new[j] = lines[i];

            return String.Join(Environment.NewLine, lines_new.Where(x => !String.IsNullOrEmpty(x)).ToArray());
        }
    }
}