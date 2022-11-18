# Prueba 1. Unity
### MonsterController
Controlador para el monstruo (jugador).

El movimiento viene dado por las teclas WASD y está restringido a los ejes XZ. Es posible rotar en el eje Y mediante las teclas Q y E.

Presionando la tecla T, se teletransportará a una distancia aleatoria entre 0 y 0.5 unidades en los ejes XZ.

El monstruo tiene asociado un objeto de texto que indica la vida restante, que empieza con valor 100 y disminuye si se acerca lo suficiente a alguna araña.

Si el monstruo colisiona con el cofre (monster chest), los huevos de la escena aumentan su tamaño, es decir aumenta 0.1 unidades su escala en los tres ejes.

![](https://github.com/alu0101444741/InterfacesInteligentes_Examen_1/blob/main/ScriptsGIFs/MonsterController.gif)

### MonsterCameraPointer
Script CameraPointer para lanzar eventos cuando la mirada del jugador se cruce con un objeto.

### ChestController
Si el jugador mira directamente al cofre, las arañas verdes saltarán y las rojas rotarán en su eje Y.

![](https://github.com/alu0101444741/InterfacesInteligentes_Examen_1/blob/main/ScriptsGIFs/ChestController.gif)
