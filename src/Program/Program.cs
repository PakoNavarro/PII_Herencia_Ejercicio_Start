//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ucu.Poo.Discord;

namespace Ucu.Poo.RideShare
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();

        }

        private static async Task MainAsync()
        {
            var botToken = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
            var channelText = Environment.GetEnvironmentVariable("CHANNEL_ID");
            if (string.IsNullOrWhiteSpace(botToken) || string.IsNullOrWhiteSpace(channelText))
            {
                Console.WriteLine("Faltan las variables de entorno.");
                return;
            }

            ulong channelId = ulong.Parse(channelText);

            DiscordClient discord = new DiscordClient();

            Console.WriteLine("Conectando con Discord...");
            await discord.LoginAsync(botToken);
            await discord.SendMessageAsync(channelId, "¡Hola desde C#!");
            await discord.SendImageAsync(channelId, "bill.jpg", "Mira esta imagen");
            Console.WriteLine("Mensajes enviados.");

            /*
            En éste método deberás mostrar un ejemplo de funcionamiento de tu
            programa. A continuación te planteamos un ejemplo de como hacerlo.
            Esto no significa que te limites a hacer solamente esto, debes
            pensar en grande!

            User pasajero1 = ...
            User pasajero2 = ...
            User pasajero3 = ...
            User conductor1 = ...
            User conductorPool1 = ...
            UcuRideShare rideShare = new UcuRideShare()

            rideShare.Add(conductor1)
            Se publica en Discord un nuevo conductor!

            rideShare.Add(conductorPool1)
            Se publica en Discord un nuevo conductor!

            rideShare.Add(pasajero1)
            Se publica en Discord nuevo registro de pasajero!

            rideShare.Add(pasajero2)
            Se publica en Discord nuevo registro de pasajero!

            rideShare.Add(pasajero3)
            Se publica en Discord nuevo registro de pasajero!
            */
            Console.WriteLine("Creando usuarios de ejemplo...");

            PoolDriver conductorPool1 = new PoolDriver("Ana", "Gómez", "87654321", "dan.jpg", 4.9, "Chevrolet Onix", "Manejo tranquilo, ideal para viajes largos.", 3);

            Passenger pasajero1 = new Passenger("Lucía", "Fernández", "11223344", "rick.jpg", 5.0);

            Console.WriteLine("Publicando conductor pool...");
            await discord.SendImageAsync(channelId, conductorPool1.ProfilePhoto,
            $"🚐 ¡Nuevo conductor pool en UcuRide! {conductorPool1.Name} {conductorPool1.LastName} ({conductorPool1.Car}). {conductorPool1.Bio} Capacidad: {conductorPool1.MaxCapacity} pasajeros.");

            Console.WriteLine("Publicando pasajero...");
            await discord.SendImageAsync(channelId, pasajero1.ProfilePhoto,
            $"🧍 ¡Nuevo pasajero en UcuRide! {pasajero1.Name} {pasajero1.LastName}");

            Console.WriteLine("Mensajes enviados.");
        }
    }
}
