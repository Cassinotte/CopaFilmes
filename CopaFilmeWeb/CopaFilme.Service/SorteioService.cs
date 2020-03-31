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
        Task<KeyValuePair<FilmesResponse, FilmesResponse>> GetVencedorCopaFilme(string[] idsFilmes, CancellationToken ct);
    }

    public class SorteioService : ISorteioService
    {

        private ICopaFilmeBase CopaFilmeBase;

        public SorteioService(ICopaFilmeBase copaFilmeBase)
        {
            CopaFilmeBase = copaFilmeBase;
        }

        public async Task<KeyValuePair<FilmesResponse, FilmesResponse>> GetVencedorCopaFilme(string[] idsFilmes, CancellationToken ct )
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
                .Take((int)idsFilmes.Length / 2)
                .Select(x => new KeyValuePair<FilmesResponse, FilmesResponse>(x.elemt, selecao[(idsFilmes.Length - 1) - x.index]))
                .ToList();

            // Fase de Eliminatórias
            return CalcularVencedor(selecaoPrincipal);
        }

        private KeyValuePair<FilmesResponse, FilmesResponse> CalcularVencedor(List<KeyValuePair<FilmesResponse, FilmesResponse>> filme)
        {
            if (filme.Count == 1)
            {
                var ultimoItel = filme.LastOrDefault();
                FilmesResponse filmeOne = ultimoItel.Key, filmeTwo = ultimoItel.Value;

                if (!CheckVencedor(ultimoItel))
                {
                    new KeyValuePair<FilmesResponse, FilmesResponse>(filmeTwo, filmeOne);
                }
                
                return new KeyValuePair<FilmesResponse, FilmesResponse>(filmeOne, filmeTwo);
            }
            else
            {
                var listaParc = new List<FilmesResponse>();

                foreach (var item in filme)
                {
                    if (CheckVencedor(item))
                    {
                        listaParc.Add(item.Key);
                    }
                    else
                    {
                        listaParc.Add(item.Value);
                    }

                }

                var x = listaParc.Select((x, i) => new { elemt = x, index = i })
                    .Where(x => x.index % 2 == 0)
                    .Select(x => new KeyValuePair<FilmesResponse, FilmesResponse>(x.elemt, listaParc[x.index + 1]))
                    .ToList();

                return CalcularVencedor(x);
            }



        }

        private static bool CheckVencedor(KeyValuePair<FilmesResponse, FilmesResponse> item)
        {
            return item.Key.nota > item.Value.nota || item.Key.titulo.CompareTo(item.Value.titulo) > 0;
        }
    }
}
