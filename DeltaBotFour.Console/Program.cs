﻿using DeltaBotFour.DependencyResolver;
using System;
using System.Threading;
using DeltaBotFour.Infrastructure;
using DeltaBotFour.Infrastructure.Interface;
using DeltaBotFour.Persistence.Interface;
using DeltaBotFour.Reddit.Interface;
using DeltaBotFour.Shared;

namespace DeltaBotFour.Console
{
    public class Program
    {
        private static DeltaBotFourContainer _container;

        public static void Main(string[] args)
        {
            System.Console.WriteLine("------DB4 Startup-----");

            // Perform DI Container registrations. From this point on all dependencies are available
            _container = new DeltaBotFourContainer().Install(new RegistrationCatalogFactory().GetRegistrationCatalog());

            var appConfiguration = _container.Resolve<AppConfiguration>();

            var repository = _container.Resolve<IDB4Repository>();
            System.Console.Write("Running db migrations...");
            repository.Migrate();
            System.Console.WriteLine("done");

            System.Console.Write("Compacting database...");
            repository.CompactDb();
            System.Console.WriteLine("done");

            System.Console.Write("Cleaning up old snipe comments...");
            var deletedCount = repository.CleanOldDeltaComments();
            System.Console.WriteLine($"{deletedCount} deleted");

            // Start auto-restart manager
            var restartManager = _container.Resolve<AutoRestartManager>();
            restartManager.Start(appConfiguration.AutoRestartHours);

            // Start monitoring comments / edits / private messages
            var activityMonitor = _container.Resolve<IActivityMonitor>();

            activityMonitor.Start(appConfiguration.CommentScanIntervalSeconds,
                appConfiguration.EditScanIntervalSeconds,
                appConfiguration.PMScanIntervalSeconds);

            // Start queue dispatcher
            var queueDispatcher = _container.Resolve<IDB4QueueDispatcher>();
            queueDispatcher.Start();

            // Start health pinger
            var healthPinger = _container.Resolve<IHealthPinger>();
            healthPinger.Start();

            // Refresh deltaboards on startup
            var deltaboardEditor = _container.Resolve<IDeltaboardEditor>();
            deltaboardEditor.RefreshDeltaboards();

            while (true)
            {
                if (System.Console.KeyAvailable && System.Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    activityMonitor.Stop();
                    queueDispatcher.Stop();
                    healthPinger.Stop();
                    break;
                }

                Thread.Sleep(100);
            }

            System.Console.WriteLine("------DB4 Shutdown-----");
        }
    }
}