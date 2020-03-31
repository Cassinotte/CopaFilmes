using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CopaFilme.Integration;
using CopaFilme.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaFilmeWeb.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FilmesController : ControllerBase
	{
		private readonly ICopaFilmeBase _copaFilmeBase;
		private readonly ISorteioService _sorteioService;

		private readonly ILogger<FilmesController> _logger;

		public FilmesController(ICopaFilmeBase copaFilmeBase, ISorteioService sorteioService, 
								ILogger<FilmesController> logger)
		{
			_copaFilmeBase = copaFilmeBase;
			_sorteioService = sorteioService;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<FilmesResponse>), StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Get(CancellationToken ct)
		{
			var retorno = await _copaFilmeBase.GetFilmesAsync(ct);

			return Ok(retorno.OrderBy(x => x.titulo));
		}

		[HttpPost("copaInitial")]
		[ProducesResponseType(typeof(VencedorViewModel), StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GerarCampeonato([FromBody] string[] selecionados, CancellationToken ct)
		{
			var retorno = await _sorteioService.GetVencedorCopaFilme(selecionados, ct);

			return Ok(new VencedorViewModel(retorno));
		}
	}
}
