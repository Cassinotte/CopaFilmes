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

            if ( idsFilmes.Length % 2 != 0)
            {
                throw new FormatException();
            }

            var retorno = await CopaFilmeBase.GetFilmesAsync(ct);

            // Ordenar os filmes alfabeticamente
            var selecao = retorno.Where(x => idsFilmes.Contains(x.id))
                    .OrderBy(x => x.titulo);

            var metade = (int)idsFilmes.Length / 2;

            // Fazer com que os filmes disputem em eliminatórias da seguinte forma: o filme na primeira
            // posição disputará contra o da última posição, o segundo com o penúltimo
            var selecaoPrincipal = retorno.Take(metade);

            var x = from sp in selecaoPrincipal
                    let elementoPar = retorno.IndexOf(sp).

        }

    }
}
