using System;
using System.Collections.Generic;

namespace EfCoreDbFirst_2.Infrastructure.DataModels
{
    public partial class TbJogador
    {
        public TbJogador()
        {
            TbInscritos = new HashSet<TbInscrito>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public DateOnly? DataNasc { get; set; }

        public virtual ICollection<TbInscrito> TbInscritos { get; set; }
    }
}
