using EventCraft.Workers.Providers.BillBoardProvider;
using EventCraft.Workers.Providers.BillBoardProvider.BillBoardHotOneHundredMusic;
using Microsoft.Extensions.Hosting;
using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EventCraft.Workers.Workers;

public class BillBoardWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        

    }

}