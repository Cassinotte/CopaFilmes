using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CopaFilme.Integration;
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

		private readonly ILogger<FilmesController> _logger;

		public FilmesController(ICopaFilmeBase copaFilmeBase, ILogger<FilmesController> logger)
		{
			_logger = logger;
			_copaFilmeBase = copaFilmeBase;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<FilmesResponse>), StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Get(CancellationToken ct)
		{
			var retorno = await _copaFilmeBase.GetFilmesAsync(ct);

			return Ok(retorno.OrderBy(x => x.titulo));
		}
	}
}
