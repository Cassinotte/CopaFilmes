using CopaFilme.Integration;
using CopaFilme.Service;
using Moq;
using System;
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


        public SorteioServiceTest()
        {
            lista = new List<FilmesResponse>()
            {
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
                new FilmesResponse() {},
            };


            MoqSorteioService = new Mock<ICopaFilmeBase>();

            MoqSorteioService.Setup(x => x.GetFilmesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(x => Task.FromResult(lista));
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
