using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM1.SportsData.Producer.Domain.Entities.Base;

namespace XM1.SportsData.Producer.Domain.Entities.Leagues
{
    public class Pais : BaseEntity
    {
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<Liga> Ligas { get; set; }

        public Pais(string nome, string logoUrl, int idApi)
        {
            Nome = nome;
            LogoUrl = logoUrl;
            IdApi = idApi;
            Ligas = new List<Liga>();

        }
    }
}
