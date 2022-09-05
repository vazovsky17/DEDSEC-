﻿using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Players
{
    public class DeletePlayerCommand : AsyncCommandBase
    {
        private readonly PlayersStore _playersStore;
        private readonly IAuthenticatorService _authenticatorService;

        public DeletePlayerCommand(PlayersStore playersStore, 
            IAuthenticatorService authenticatorService)
        {
            _playersStore = playersStore;
            _authenticatorService = authenticatorService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
        }
    }
}
