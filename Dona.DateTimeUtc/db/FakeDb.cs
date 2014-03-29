using Dona.DateTimeUtc.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dona.DateTimeUtc.db
{
    public class FakeDb
    {
        public ICollection<Pessoa> Pessoas 
        { 
            get
            {
                return new List<Pessoa>
                {
                    new Pessoa { Id = 1, Nome = "José", 
                        DtAniversario = new DateTime(1989, 2, 15, 0, 0, 0, DateTimeKind.Utc),
                        DtCriacao = new DateTime(2012, 5, 5, 18, 0, 0, DateTimeKind.Utc), IsActive = true
                    },
                    new Pessoa { Id = 2, Nome = "Manuel", 
                        DtAniversario = new DateTime(1986, 10, 5, 0, 0, 0, DateTimeKind.Utc),
                        DtCriacao = new DateTime(2013, 2, 1, 20, 0, 0, DateTimeKind.Utc), IsActive = true
                    },
                    new Pessoa { Id = 3, Nome = "Carla", 
                        DtAniversario = new DateTime(1997, 5, 11, 0, 0, 0, DateTimeKind.Utc),
                        DtCriacao = new DateTime(2013, 2, 12, 18, 0, 0, DateTimeKind.Utc), IsActive = true
                    },
                    new Pessoa { Id = 4, Nome = "Kimoto", 
                        DtAniversario = new DateTime(2000, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                        DtCriacao = new DateTime(2014, 1, 28, 15, 0, 0, DateTimeKind.Utc), IsActive = true
                    },
                    new Pessoa { Id = 5, Nome = "Ryu", 
                        DtAniversario = new DateTime(1975, 5, 6, 0, 0, 0, DateTimeKind.Utc),
                        DtCriacao = new DateTime(2012, 2, 1, 10, 0, 0, DateTimeKind.Utc), IsActive = true
                    }
                };
            }
        }
    }
}
