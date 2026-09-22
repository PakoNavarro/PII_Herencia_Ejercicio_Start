
<!-- markdownlint-disable-next-line MD033 MD041 -->
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Programación II

# Ejercicio Herencia

## Objetivo

El objetivo de este ejercicio es el de aplicar los conceptos de herencia y
agregación, así como también sobrecarga y sobreescritura de métodos y clases
abstractas.

## Introducción

Un grupo de estudiantes ha tomado la iniciativa de crear un programa de
*ridesharing* gratuito entre profesores y alumnos de la universidad. Este nuevo
sistema, denominado UCURide funcionará de la siguiente forma: Tanto alumnos,
como profesores podrán postularse como voluntarios, ofreciendo sus vehículos
como medio compartido. A estos se los denominará `Drivers`. Todos los demás
usuarios serán los `Passengers`.

* Los `Drivers` tendrán ciertos atributos mínimos, como ser nombre, apellido,
   cédula, un vehículo[^1], calificación como conductor y una breve bio.

* Los `Passengers` tendrán sus propios atributos, como ser cédula, nombre,
   apellido, calificación como pasajero[^2].

[^1]: No es necesario modelar una clase para los vehículos, pero puedes hacerlo
    si te divierte.

[^2]: A los efectos de este sistema, no es necesario diferenciar entre profesores
    y alumnos.

A su vez, los conductores podrán ser identificados de dos formas:

* `Standard` Solamente levaran a un pasajero por vez.

* `Pool` Están dispuestos a realizar un viaje con multiples pasajeros.
  Para ello, es necesario saber la capacidad máxima de pasajeros que puede
  llevar.

Con el fin de promocionar este nuevo servicio, hay un canal de Discord en el
cual publicar cada nuevo registro de conductores y pasajeros. Cada vez que un
nuevo voluntario se registra como conductor, se publicará una foto del conductor
con su bio y un mensaje de bienvenida. Cada vez que un nuevo pasajero se
registra para utilizar la app se deberá publicar también su foto[^3] de perfil
con su nombre.

[^3]: Solamente un string con el path a la imagen es suficiente para este
    ejercicio

## Desafío 1

Deberás identificar todas las clases del problema y como estas se relacionan
entre si. Para representar esto, debes utilizar un diagrama de clases muy
básico, similar a los visto en los ejemplos. Podrás realizar esto en papel y
subir una foto.

## Desafío 2

Deberás programar todas estas clases junto con un ejemplo de ejecución en el
Program. En cuanto al funcionamiento del sistema, solamente es necesario
mantener una lista de conductores y pasajeros y realizar la publicación
correspondiente cuando se agrega un nuevo pasajero o conductor. Para ello,
podrás hacer uso de la clase [DiscordClient](./src/Discord/DiscordClient.cs)
provista.

> [!NOTE]
>
> Necesitarás el token de Discord y el ID del canal. Te lo daremos en clase.
>
> En MacOS deberás ejecutar:
>
> ```bash
> export DISCORD_BOT_TOKEN="AQUÍ_VA_EL_TOKEN"
> export CHANNEL_ID="AQUÍ_VA_EL_ID"
> ```
>
> En Windows deberás ejecutar:
>
> ```cmd
> set DISCORD_BOT_TOKEN="AQUÍ_VA_EL_TOKEN"
> set CHANNEL_ID="AQUÍ_VA_EL_ID"
> ```

<!-- ## Desafío 3 (!Desafío Bonus!)

Si bien la universidad espera que los usuarios, al ser adultos, no publiquen
fotos inadecuadas en Discord, todos pueden cometer errores y por lo tanto se
desea aplicar un filtro a las potenciales fotos a publicar:

 * Todas las fotos de perfil de los pasajeros deberán contener una cara.

 * Todas las fotos de perfil de los conductores deberán contener una cara y
   además estar sonriendo.

Para ello, podrás hacer uso de la API de Discord provista en el siguiente repo: https://github.com/ucudal/PII_CognitiveAPI -->

## Uso de ![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-000?logo=githubcopilot&logoColor=fff)

Es posible usar GitHub Copilot en este repositorio. Consulta [cómo usar Copilot
para aprender](./COPILOT.md).
