# Scripts
## ClumsyController
Controlador para el cubo.

El movimiento viene dado por las teclas WASD y está restringido a los ejes XZ.

Es posible rotar en el eje Y mediante las teclas Q y E.

El cubo tiene asociado un objeto de texto que indica la puntuación, cuyo valor aumenta en 5 tras cada colisión con una moneda.
Si hubiera un cilindro (moneda) dentro del cubo, es posible sacarlo mediante la barra espaciadora. Este cilindro se moverá una unidad en ambos ejes XZ.

![](https://github.com/alu0101444741/InterfacesInteligentes_2/blob/main/ScriptsGIFs/CubeController.gif)

## CoinBehaviour
Por defecto, una moneda gira constantemente en el eje X.

Si el cubo manejado por el jugador colisiona con una moneda, esta aumentará su tamaño.

## SecondaryController
Controlador para la esfera.

El movimiento viene dado por las teclas IJML y está restringido a los ejes XZ.


## ProximityModifier
Modificador por proximidad.

La escala en el eje Y aumentará si se acerca un objeto etiquetado como "Esfera", y disminuirá si se acerca el objeto de nombre "Cube_Player".

La proximidad viene dada solamente por los ejes XZ.

![](https://github.com/alu0101444741/InterfacesInteligentes_2/blob/main/ScriptsGIFs/ProximityChanges.gif)
