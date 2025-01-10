using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM1.SportsData.Producer.Domain.Entities.Base;
using XM1.SportsData.Producer.Domain.Entities.Leagues;

namespace XM1.SportsData.Producer.Domain.Entities.Teams
{
    public class Times : BaseEntity
    {
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
        public Guid LigaId { get; set; }
        public Liga Liga { get; set; }

        public Times(string nome, Guid ligaId, int idApi, string logoUrl)
        {
            IdApi = idApi;
            Nome = nome; LigaId = ligaId;
            LogoUrl = logoUrl;
        }
    }
}
