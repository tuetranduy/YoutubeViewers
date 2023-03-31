﻿using System;
using System.Threading.Tasks;

namespace YoutubeViewers.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
