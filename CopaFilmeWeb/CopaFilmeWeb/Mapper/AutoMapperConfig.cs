using AutoMapper;
using CopaFilme.Integration;
using CopaFilmeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmeWeb.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilmesResponse, FilmeViewModel>();
            });

            return configuration.CreateMapper();
        }
    }
}
