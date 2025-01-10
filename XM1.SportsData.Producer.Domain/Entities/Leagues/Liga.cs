using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM1.SportsData.Producer.Domain.Entities.Base;

namespace XM1.SportsData.Producer.Domain.Entities.Leagues
{
    public class Liga : BaseEntity
    {
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
        public Guid PaisId { get; set; }
        public Pais Pais { get; set; }

        public Liga(string nome, Guid paisId, int idApi, string logoUrl)
        {
            IdApi = idApi;
            Nome = nome;
            PaisId = paisId;
            LogoUrl = logoUrl;
        }
    }
}
