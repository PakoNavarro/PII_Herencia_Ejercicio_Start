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

            await discord.LoginAsync(botToken);
            Console.WriteLine("Mensajes enviados.");

            Console.WriteLine("Creando usuarios de ejemplo...");

            PoolDriver conductorPool1 = new PoolDriver("Ana", "Gómez", "87654321", "dan.jpg", 4.9, "Chevrolet Onix", "Manejo tranquilo, ideal para viajes largos.", 3);
            PoolDriver conductorPool2 = new PoolDriver("Pepe", "Gómez", "67676767", "bill.jpg", 4.9, "BMW M3", "Manejo rapido, ideal para viajes cortos.", 7);

            Passenger pasajero1 = new Passenger("Lucía", "Fernández", "11223344", "rick.jpg", 5.0);


            Console.WriteLine("Publicando conductor pool...");
            await discord.SendImageAsync(channelId, conductorPool1.ProfilePhoto,
            $"🚐 ¡Nuevo conductor pool en UcuRide! {conductorPool1.Name} {conductorPool1.LastName} ({conductorPool1.Car}). {conductorPool1.Bio} Capacidad: {conductorPool1.MaxCapacity} pasajeros.");

            Console.WriteLine("Publicando conductor pool...");
            await discord.SendImageAsync(channelId, conductorPool2.ProfilePhoto,
            $"🚐 ¡Nuevo conductor pool en UcuRide! {conductorPool2.Name} {conductorPool2.LastName} ({conductorPool2.Car}). {conductorPool2.Bio} Capacidad: {conductorPool2.MaxCapacity} pasajeros.");
            
            Console.WriteLine("Publicando pasajero...");
            await discord.SendImageAsync(channelId, pasajero1.ProfilePhoto,
            $"🧍 ¡Nuevo pasajero en UcuRide! {pasajero1.Name} {pasajero1.LastName}");



            Console.WriteLine("Mensajes enviados.");
        }
    }
}

