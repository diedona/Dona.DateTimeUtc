using Dona.DateTimeUtc.db;
using Dona.DateTimeUtc.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            ICollection<Pessoa> PessoasConvertidas = ConverterDeUTC(PessoasUTC);
            EscreverPessoas(PessoasConvertidas);
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

        private static ICollection<T> ConverterDeUTC<T>(ICollection<T> ListaOriginal) where T: class, new()
        {
            ICollection<T> ListaNova = new List<T>();

            foreach (T Item in ListaOriginal)
            {
                T ItemNovo = ConverterDeUTC(Item);
                ListaNova.Add(ItemNovo);
            }

            return ListaNova;
        }

        private static T ConverterDeUTC<T>(T Item) where T: class, new()
        {
            T Newitem = new T();

            //todas as propriedades
            PropertyInfo[] Properties = typeof(T).GetProperties();

            //todas as que são data
            PropertyInfo[] DateProperties = Properties.Where(x => x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(DateTime?)).ToArray();

            //todas as outras
            PropertyInfo[] OtherProperties = Properties.Except(DateProperties).ToArray();

            //convertendo as de data para a zona do usuário
            foreach (var DateProperty in DateProperties)
            {
                DateTime UTCDate = Convert.ToDateTime(DateProperty.GetValue(Item));
                DateTime UserTimeZoneDate = ConverterDeUTC(UTCDate);

                DateProperty.SetValue(Newitem, UserTimeZoneDate);
            }

            //preenchendo os outros dados para o objeto
            foreach (var OtherProperty in OtherProperties)
            {
                OtherProperty.SetValue(Newitem, OtherProperty.GetValue(Item));
            }

            return Newitem;
        }

        private static DateTime ConverterDeUTC(DateTime? ParamDate)
        {
            if (ParamDate.HasValue) return ConverterDeUTC(ParamDate.Value);
            else return new DateTime();
        }

        private static DateTime ConverterDeUTC(DateTime ParamDate)
        {
            if(ParamDate.Kind == DateTimeKind.Utc)
            {
                return TimeZoneInfo.ConvertTime(ParamDate, TimeZoneInfo.Utc, UserTimeZoneInfo);
            }
            else
            {
                return new DateTime();
            }
        }
    }
}
