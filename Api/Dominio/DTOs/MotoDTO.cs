using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mininal_api.Dominio.DTOs
{
    public record MotoDTO
    {
        public string nome { get; set; } = default!;

        public string marca { get; set; } = default!;

        public string cor { get; set; } = default!;

        public int ano { get; set; } = default!;
    }
}