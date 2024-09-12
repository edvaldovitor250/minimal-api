using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using mininal_api.Dominio.Entidades;
using mininal_api.Dominio.Interfaces;

namespace mininal_api.Dominio.Servicos
{
    public class MotoServico : IMoto
    {

        private readonly DbContexto _contexto;
        public MotoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public void Apagar(Moto moto)
        {
            _contexto.Moto.Remove(moto);
            _contexto.SaveChanges();
        }

        public void Atualizar(Moto moto)
        {
            _contexto.Moto.Update(moto);
            _contexto.SaveChanges();
        }

        public Moto? BuscaPorId(int id)
        {
           return _contexto.Moto.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Incluir(Moto moto)
        {
            _contexto.Moto.Add(moto);
            _contexto.SaveChanges();
        }

       public List<Moto> Todos(int? pagina = 1, string? nome = null, string? marca = null, string? cor = null, int? ano = null)
{
    var query = _contexto.Moto.AsQueryable();

    // Filtro por nome
    if (!string.IsNullOrEmpty(nome))
    {
        query = query.Where(v => EF.Functions.Like(v.nome, $"%{nome}%"));
    }

    // Filtro por marca
    if (!string.IsNullOrEmpty(marca))
    {
        query = query.Where(v => EF.Functions.Like(v.marca, $"%{marca}%"));
    }

    if (!string.IsNullOrEmpty(cor))
    {
        query = query.Where(v => EF.Functions.Like(v.cor, $"%{cor}%"));
    }

    // Filtro por ano
    if (ano != null)
    {
        query = query.Where(v => v.ano == ano);
    }

    int itensPorPagina = 10;

    query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

    return query.ToList();
}

    }
}