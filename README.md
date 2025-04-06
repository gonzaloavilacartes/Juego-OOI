# Juego Noxus y Demacia

Este proyecto es un juego de combate por turnos entre personajes con diferentes habilidades y equipos. Está desarrollado en C# y utiliza .NET 8.0 como framework.

## Descripción

El juego presenta dos tipos de personajes principales: **Bárbaros** y **Sacerdotes**, cada uno con habilidades únicas. Los personajes pueden equiparse con armas y armaduras que modifican sus estadísticas de ataque y defensa. El objetivo es que los personajes se enfrenten en una batalla por turnos hasta que uno de ellos gane o se alcance el límite de rondas.

### Clases principales

- **Personaje**: Clase base que define las propiedades y comportamientos comunes de todos los personajes.
- **Sacerdote**: Subclase de `Personaje` con la habilidad de reducir el daño recibido en ciertas ocasiones.
- **Bárbaro**: Subclase de `Personaje` que puede realizar ataques furiosos si acumula suficiente furia.
- **Equipo**: Clase base para los objetos que los personajes pueden equipar.
  - **Arma**: Subclase de `Equipo` que aumenta el ataque.
  - **Armadura**: Subclase de `Equipo` que aumenta la defensa.

### Mecánicas principales

- **Ataque**: Los personajes pueden atacar a otros, infligiendo daño basado en su ataque y la armadura del objetivo.
- **Esquivar**: Existe una probabilidad del 15% de esquivar un ataque.
- **Equipamiento**: Los personajes pueden equiparse con armas y armaduras para mejorar sus estadísticas.
- **Batalla**: Los personajes se enfrentan en rondas hasta que uno de ellos gane o se alcance el límite de rondas.

## Requisitos

- .NET 8.0 SDK o superior.

## Cómo ejecutar el proyecto

1. Clona este repositorio o descarga los archivos.
2. Abre una terminal en la carpeta raíz del proyecto.
3. Ejecuta el siguiente comando para compilar y ejecutar el programa:

   ```bash
   dotnet run --project "Juego Darius y Garen/Juego Darius y Garen.csproj"
