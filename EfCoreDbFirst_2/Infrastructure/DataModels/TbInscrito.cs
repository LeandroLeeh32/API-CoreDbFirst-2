using System;
using System.Collections.Generic;

namespace EfCoreDbFirst_2.Infrastructure.DataModels
{
    public partial class TbInscrito
    {
        public int Id { get; set; }
        public int Jogador { get; set; }
        public int Instituicao { get; set; }
        public DateOnly? DataPub { get; set; }
        public int Genero { get; set; }

        public virtual TbGenero GeneroNavigation { get; set; } = null!;
        public virtual TbInstituicao InstituicaoNavigation { get; set; } = null!;
        public virtual TbJogador JogadorNavigation { get; set; } = null!;
    }
}
