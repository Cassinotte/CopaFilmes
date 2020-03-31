using CopaFilme.Integration;
using CopaFilme.Service;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilme.TestUnit
{
    public class SorteioServiceTest
    {

        private Mock<ICopaFilmeBase> MoqSorteioService;
        private List<FilmesResponse> lista;

        private ISorteioService sorteioService;


        public SorteioServiceTest()
        {
            lista = new List<FilmesResponse>()
            {
                new FilmesResponse() { id = "1", titulo = "Os Incríveis 2", nota = 8.5 },
                new FilmesResponse() { id = "2", titulo = "Jurassic World: Reino Ameaçado", nota = 6.7 },
                new FilmesResponse() { id = "3", titulo = "Oito Mulheres e um Segredo", nota = 6.3 },
                new FilmesResponse() { id = "4", titulo = "Hereditário", nota = 7.8 },
                new FilmesResponse() { id = "5", titulo = "Vingadores: Guerra Infinita", nota = 8.8 },
                new FilmesResponse() { id = "6", titulo = "Deadpool 2", nota = 8.1 },
                new FilmesResponse() { id = "7", titulo = "Han Solo: Uma História Star Wars", nota = 7.2 },
                new FilmesResponse() { id = "8", titulo = "Thor: Ragnarok", nota = 7.9 },
            };


            MoqSorteioService = new Mock<ICopaFilmeBase>();

            MoqSorteioService.Setup(x => x.GetFilmesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(lista);

            sorteioService = new SorteioService(MoqSorteioService.Object);
        }

        [Fact]
        public async Task TestSorteioCorrect()
        {

            var retorno = await sorteioService.GetVencedorCopaFilme(lista.Select(x => x.id).ToArray(), CancellationToken.None) ;

            Assert.Equal("Vingadores: Guerra Infinita", retorno.Key.titulo);
            Assert.Equal("Os Incríveis 2", retorno.Value.titulo);

        }
    }
}
