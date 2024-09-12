using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mininal_api.Dominio.Entidades;

namespace mininal_api.Dominio.Interfaces
{
    public interface IMoto
    {
            List<Moto> Todos(int? pagina = 1, string? nome = null, string? marca = null, string? cor = null, int? ano = null);
    Moto? BuscaPorId(int id);
    void Incluir(Moto moto);
    void Atualizar(Moto moto);
    void Apagar(Moto moto);
    }
}