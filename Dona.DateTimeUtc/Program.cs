using Dona.DateTimeUtc.db;
using Dona.DateTimeUtc.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dona.DateTimeUtc
{
    class Program
    {
        private static FakeDb _db = new FakeDb();
        private static TimeZoneInfo UserTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        static void Main(string[] args)
        {
            Console.WriteLine("**** DATAS EM UTC/GMT");
            ICollection<Pessoa> PessoasUTC = _db.Pessoas;
            EscreverPessoas(PessoasUTC);

            Console.WriteLine("**** DATAS TRADUZIDAS PARA '{0}'", UserTimeZoneInfo.Id);
        }

        private static void EscreverPessoas(ICollection<Pessoa> Pessoas)
        {
            foreach (var Pessoa in Pessoas)
            {
                Console.Write("Id: ");
                Console.WriteLine(Pessoa.Id);
                Console.Write("Nome: ");
                Console.WriteLine(Pessoa.Nome);
                Console.Write("Data de Aniversário: ");
                Console.WriteLine(Pessoa.DtAniversario);
                Console.Write("Data de Registro: ");
                Console.WriteLine(Pessoa.DtCriacao);
                Console.WriteLine();
            }
        }
    }
}
