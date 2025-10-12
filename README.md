# Mi Juego de Aventura RPG

Este es un juego de rol y acci�n con vista desde arriba, desarrollado con Unity. Inspirado en los cl�sicos del g�nero como "The Legend of Zelda", el jugador explora mazmorras, lucha contra enemigos y recolecta tesoros para progresar en la aventura.

## Caracter�sticas Principales

*   **Exploraci�n de Mazmorras:** Navega a trav�s de diferentes tipos de habitaciones, desde el mundo exterior hasta las profundidades de las mazmorras.
*   **Combate en Tiempo Real:** Enfr�ntate a enemigos con un sistema de combate que incluye retroceso (`knockback`) y manejo de la salud del jugador.
*   **Sistema de Inventario:** Recolecta �tems y tesoros que se guardan en un inventario persistente.
*   **Sistema de Salud:** La vida del jugador se gestiona con un sistema de corazones, un cl�sico del g�nero.
*   **Interacci�n con el Entorno:** Interact�a con objetos como cofres, puertas, vasijas y dialoga con personajes.
*   **C�mara Din�mica:** El sistema de c�mara sigue al jugador y realiza transiciones suaves al cambiar de habitaci�n.
*   **Persistencia de Datos:** El estado del jugador (posici�n, salud, etc.) se mantiene entre escenas.
*   **Soporte para Mandos:** Compatible con mandos de PlayStation (PS4, PS5) y Xbox para una experiencia de juego m�s c�moda.

## Capturas de Pantalla

�Aqu� puedes ver el juego en acci�n!

![Descripci�n de la imagen](ruta/a/tu/imagen.png "T�tulo opcional de la imagen")
*(Reemplaza `ruta/a/tu/imagen.png` con la ruta a tu captura de pantalla. Se recomienda crear una carpeta `images` en la ra�z del proyecto para guardarlas).*

## Mec�nicas de Juego

El n�cleo del juego se basa en la exploraci�n y el combate:

*   **Movimiento y Exploraci�n:** El jugador se mueve en un mapa basado en habitaciones. Al llegar al borde de una, la c�mara transiciona a la siguiente, cargando el nuevo entorno.
*   **Combate:** Los enemigos, como el `Log`, patrullan las �reas. El jugador puede atacar y, al recibir da�o, tanto el jugador como el enemigo sufren un efecto de `knockback`.
*   **Gesti�n de Recursos:** El jugador debe vigilar su salud, representada por corazones. Puede encontrar objetos en cofres y vasijas para recuperarse o mejorar sus habilidades.
*   **Eventos y Se�ales:** El juego utiliza un sistema de Se�ales (`Signal`) para comunicar eventos de forma desacoplada. Por ejemplo, una `HealthSignal` notifica a otros sistemas (como la UI de corazones) cuando la salud del jugador cambia.

## Estructura del Proyecto

La l�gica principal del juego se encuentra en la carpeta `Assets/Scripts`.

*   `Assets/Scripts`: Contiene todos los scripts de C# que definen el comportamiento de los personajes, enemigos, �tems y la l�gica del juego.
*   `Assets/scriptableObjects`: Esta carpeta es crucial, ya que contiene `ScriptableObjects` que se utilizan para:
    *   Gestionar datos persistentes entre escenas (como `VectorValue` para la posici�n del jugador).
    *   Definir �tems y el inventario (`Item`, `Inventory`).
    *   Actuar como "Se�ales" para un sistema de eventos (`Signal`, `HealthSignal`).

## Scripts Clave

*   `Player Movement.cs`: Controla el movimiento del personaje principal.
*   `Enemy.cs` / `Log.cs`: Clase base para los enemigos y una implementaci�n espec�fica de un enemigo que patrulla.
*   `HeartManager.cs`: Gestiona la interfaz de usuario de la salud del jugador.
*   `Roommove.cs` / `Scene transition.cs`: Manejan la l�gica para cambiar entre habitaciones y escenas.
*   `Interactable.cs`: Clase base para todos los objetos con los que el jugador puede interactuar.
*   `Signal.cs` / `Signal Listener.cs`: Implementaci�n del patr�n Observer para crear un sistema de eventos robusto y desacoplado.

## C�mo Empezar

1.  Clona o descarga este repositorio.
2.  Abre el proyecto con **Unity Hub**, asegur�ndote de seleccionar una versi�n compatible de Unity (por ejemplo, 2020.3 LTS o superior).
3.  Una vez abierto el proyecto, busca la escena del men� principal en la carpeta `Assets/Scenes` y ejec�tala para empezar a jugar.

## Motor del Juego

*   **Unity**


