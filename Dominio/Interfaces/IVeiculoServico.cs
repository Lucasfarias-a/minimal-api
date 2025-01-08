using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> Todos(
            int? pagina = 1,
            string? nome = null,
            string? marca = null
        );

        Veiculo? BuscaPorId(
            int id
        );

        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Deletar(Veiculo veiculo);
    }
}