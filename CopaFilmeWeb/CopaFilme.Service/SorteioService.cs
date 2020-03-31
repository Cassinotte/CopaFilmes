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
        Task<FilmesResponse> GetVencedorCopaFilme(string[] idsFilmes, CancellationToken ct);
    }

    public class SorteioService : ISorteioService
    {

        private ICopaFilmeBase CopaFilmeBase;

        public SorteioService(ICopaFilmeBase copaFilmeBase)
        {
            CopaFilmeBase = copaFilmeBase;
        }

        public async Task<FilmesResponse> GetVencedorCopaFilme(string[] idsFilmes, CancellationToken ct )
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
                .Select(x => new KeyValuePair<FilmesResponse, FilmesResponse>(x.elemt,selecao[idsFilmes.Length - x.index]))
                .ToList()

            // Fase de Eliminatórias
            return CalcularVencedor(selecaoPrincipal);
        }

        private FilmesResponse CalcularVencedor(List<KeyValuePair<FilmesResponse, FilmesResponse>> filme)
        {

            var listaParc = new List<FilmesResponse>();

            foreach (var item in filme)
            {
                if (item.Key.nota > item.Value.nota || item.Key.titulo.CompareTo(item.Value.titulo) > 0)
                {
                    listaParc.Add(item.Key);
                }
                else
                {
                    listaParc.Add(item.Value);
                }

            }

            if (listaParc.Count == 1)
            { 
                return listaParc.FirstOrDefault();
            }
            else
            {
                var x = listaParc.Select((x, i) => new { elemt = x, index = i })
                    .Take((int)listaParc.Count() / 2)
                    .Select(x => new KeyValuePair<FilmesResponse, FilmesResponse>(x.elemt, listaParc[x.index + 1]))
                    .ToList();

                return CalcularVencedor(x);
            }



        }

    }
}
