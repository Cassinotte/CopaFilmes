using CopaFilme.Integration;
using System;
using System.Collections.Generic;
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
                    .OrderBy(x => x.titulo).ToList();

            // Fazer com que os filmes disputem em eliminatórias da seguinte forma: o filme na primeira
            // posição disputará contra o da última posição, o segundo com o penúltimo
            var selecaoPrincipal = selecao.Select((x, i) => new { elemt = x, index = i })
                .Select(x => new KeyValuePair<FilmesResponse, FilmesResponse>(x.elemt,selecao[idsFilmes.Length - x.index]))
                .Take((int)idsFilmes.Length / 2);

            // Fase de Eliminatórias

        }

        private (FilmesResponse, List<KeyValuePair<FilmesResponse, FilmesResponse>> filme) CalcularVencedor(List<KeyValuePair<FilmesResponse, FilmesResponse>> filme)
        {
            var vencedor = filme.FirstOrDefault();
            filme.Remove(vencedor);

            if (vencedor.Key.nota > vencedor.Value.nota || vencedor.Key.titulo.CompareTo(vencedor.Value.titulo) > 0)
            {
                return (vencedor.Key, filme);
            }

            return (vencedor.Value, filme);


        }

    }
}
