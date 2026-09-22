//------------------------------------------------------------------------------
// <copyright file="DiscordClient.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Discord;
using Discord.WebSocket;

namespace Ucu.Poo.Discord
{
    public class DiscordClient : IAsyncDisposable
    {
        private readonly DiscordSocketClient _client;
        private bool _isLoggedIn = false;

        public DiscordClient()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages
            };

            _client = new DiscordSocketClient(config);
            _client.Log += WriteLogAsync;
        }

        private static Task WriteLogAsync(LogMessage mensaje)
        {
            Console.WriteLine($"Discord [{mensaje.Severity}]: {mensaje.Message}");
            return Task.CompletedTask;
        }

        // Iniciar sesión con el token del bot
        public async Task LoginAsync(string token)
        {
            if (_isLoggedIn)
                return;

            await _client.LoginAsync(TokenType.Bot, token);

            // Esperar a que el cliente esté listo
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            _client.Ready += () =>
            {
                tcs.SetResult(true);
                return Task.CompletedTask;
            };

            await _client.StartAsync();
            Task completedTask = await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(15)));
            if (completedTask != tcs.Task)
                throw new TimeoutException("Discord no estuvo listo dentro del tiempo esperado.");

            _isLoggedIn = true;
        }

        // Enviar un mensaje de texto a un canal
        public async Task SendMessageAsync(ulong channelId, string contenido)
        {
            if (!_isLoggedIn)
                throw new InvalidOperationException("Primero llama a IniciarSesionAsync.");

            var channel = await _client.GetChannelAsync(channelId) as IMessageChannel;
            if (channel == null)
                throw new ArgumentException("No se encontró el canal con ese ID.");

            await channel.SendMessageAsync(contenido);
        }

        // Enviar una imagen (archivo) a un canal, con mensaje opcional
        public async Task SendImageAsync(ulong channelId, string rutaArchivo, string? mensajeOpcional = null)
        {
            if (!_isLoggedIn)
                throw new InvalidOperationException("Primero llama a IniciarSesionAsync.");

            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo de imagen.", rutaArchivo);

            var channel = await _client.GetChannelAsync(channelId) as IMessageChannel;
            if (channel == null)
                throw new ArgumentException("No se encontró el canal con ese ID.");

            await using var stream = File.OpenRead(rutaArchivo);
            var fileName = Path.GetFileName(rutaArchivo);

            await channel.SendFileAsync(stream, fileName, mensajeOpcional ?? string.Empty);
        }

        public async ValueTask DisposeAsync()
        {
            if (_isLoggedIn)
            {
                await _client.StopAsync();
                await _client.LogoutAsync();
                _isLoggedIn = false;
            }

            _client.Dispose();
        }
    }
}
