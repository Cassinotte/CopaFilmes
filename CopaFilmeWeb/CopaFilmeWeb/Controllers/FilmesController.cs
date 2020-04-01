using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CopaFilme.Integration;
using CopaFilme.Service;
using CopaFilmeWeb.Models;
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
		private readonly IMapper _mapper;

		private readonly ILogger<FilmesController> _logger;

		public FilmesController(ICopaFilmeBase copaFilmeBase, ISorteioService sorteioService, 
								ILogger<FilmesController> logger, IMapper mapper)
		{
			_copaFilmeBase = copaFilmeBase;
			_sorteioService = sorteioService;
			_logger = logger;

			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<FilmeViewModel>), StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Get(CancellationToken ct)
		{
			var retorno = await _copaFilmeBase.GetFilmesAsync(ct);

			var map = _mapper.Map<IEnumerable<FilmeViewModel>>(retorno);

			return Ok(map.OrderBy(x => x.titulo));
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
