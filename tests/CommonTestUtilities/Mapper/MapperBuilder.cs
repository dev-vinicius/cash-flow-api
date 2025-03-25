using System;
using AutoMapper;
using CashFlow.Application.AutoMapper;

namespace CommonTestUtilities.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        });

        return configuration.CreateMapper();
    }
}
