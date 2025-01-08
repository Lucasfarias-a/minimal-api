using Microsoft.EntityFrameworkCore;
using minimal_api.Infraestrutura.Interfaces;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _dbContexto;

        public VeiculoServico(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void Incluir(Veiculo veiculo)
        {
            _dbContexto.Veiculos.Add(veiculo);
            _dbContexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _dbContexto.Veiculos.Update(veiculo);
            _dbContexto.SaveChanges();
        }

        public void Deletar(Veiculo veiculo)
        {
            _dbContexto.Veiculos.RemoveRange(veiculo);
            _dbContexto.SaveChanges();
        }

        public Veiculo? BuscaPorId(int id)
        {
            return _dbContexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            var query = _dbContexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
            }

            int itensPorPagina = 10;
            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }
    }
}