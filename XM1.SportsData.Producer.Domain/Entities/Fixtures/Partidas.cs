using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM1.SportsData.Producer.Domain.Entities.Base;
using XM1.SportsData.Producer.Domain.Entities.Teams;

namespace XM1.SportsData.Producer.Domain.Entities.Fixtures
{
    public class Partidas : BaseEntity
    {
        public Guid TimeCasaId { get; set; }
        public Times TimeCasa { get; set; }
        public Guid TimeVisitanteId { get; set; }
        public Times TimeVisitante { get; set; }
        public DateTime DataInicio { get; set; }
        public int Rodada { get; set; }
        public int? GolsTimeCasa { get; set; }
        public int? GolsTimeVisitante { get; set; }
        public bool? IsResultadoCompleto { get; set; }
        public bool? AoVivo { get; set; }
    }
}
