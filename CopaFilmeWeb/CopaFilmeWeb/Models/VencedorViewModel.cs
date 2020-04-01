using CopaFilme.Integration;
using System;
using System.Collections.Generic;

namespace CopaFilmeWeb
{
	public class VencedorViewModel
	{
		public VencedorViewModel(KeyValuePair<FilmesResponse, FilmesResponse> chave)
		{
			this.Vencedor1 = chave.Key;
			this.Vencedor2 = chave.Value;
		}


		public FilmesResponse Vencedor1 { get; set; }

		public FilmesResponse Vencedor2 { get; set; }
	}
}
