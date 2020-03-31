using CopaFilme.Integration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CopaFilme.Service
{

    public interface ISorteioService
    {

    }

    public class SorteioService : ISorteioService
    {

        private ICopaFilmeBase CopaFilmeBase;

        public SorteioService(ICopaFilmeBase copaFilmeBase)
        {
            CopaFilmeBase = copaFilmeBase;
        }

        public async Task GetVencedorCopaFilme(string[] idsFilmes, CancellationToken ct )
        {
            var retorno = await CopaFilmeBase.GetFilmesAsync(ct);

            // Ordenar os filmes alfabeticamente
            var selecao = retorno.Where(x => idsFilmes.Contains(x.id))
                    .OrderBy(x => x.titulo);

            // Fazer com que os filmes disputem em eliminatórias da seguinte forma: o filme na primeira
            // posição disputará contra o da última posição, o segundo com o penúltimo


        }

    }
}
