# Práctica: Realidad Aumentada con Vuforia y NavMesh en Unity
# 1. Descripción del Proyecto

Este proyecto consiste en una experiencia de Realidad Aumentada (AR) donde se integra el motor de detección de imágenes de Vuforia con el sistema de inteligencia artificial NavMesh (AI Navigation) de Unity.

La aplicación permite al usuario: 
  Detectar un escenario virtual (suelo de piedras) mediante un marcador físico (Imagen de Camaleón).

 Visualizar dos personajes 3D animados sobre dicho escenario.

Interactuar mediante pulsaciones en la pantalla (o clicks) para indicar a los personajes un destino, hacia el cual navegarán de forma autónoma evitando caerse del escenario gracias a una malla de navegación horneada.

# 2. Tecnologías y Assets utilizados

    Motor: Unity 2022.3.1f1 / Unity 6.

    AR Engine: Vuforia Engine.

    IA: AI Navigation Package (NavMesh).

    Modelos 3D: RPG Monster Duo PBR Polyart (Slime y Turtle).

    Scripting: C# para la lógica de Raycasting y navegación de agentes.

    
# 3. Desarrollo Realizado

    Configuración de Marcadores: Creación de una base de datos en el Vuforia Developer Portal y configuración de Image Targets en Unity.

    Construcción del Escenario: Implementación de un Plane con textura de piedra escalado adecuadamente para dispositivos móviles ( 0.1,0.1,0.1 ).

    Integración de Personajes: Uso de Prefabs de personajes animados, ajustando su jerarquía para que sean hijos del marcador del escenario.

        Sistema de Navegación:
            Configuración de NavMeshSurface en el suelo.

            Ajuste de los parámetros del agente (Radius a 0.05 y Height a 0.1) para adaptarse a la escala de Realidad Aumentada.

            Horneado (Bake) de la malla transitable.

    Interacción: Implementación de un script TouchNavigation que lanza un rayo desde la cámara de AR hacia el mundo virtual para obtener coordenadas de destino.

# 4. Problemas Encontrados y Soluciones
Durante el desarrollo surgieron varios retos técnicos que fueron superados:

-Pantalla Negra en el Editor y Dispositivo  Problema: Al dar a Play, la cámara no mostraba imagen o se quedaba en negro.
Solución: Se ajustó el Near Clipping Plane de la ARCamera de 0.3 a 0.01 para permitir la visualización de objetos cercanos. En Android, se desactivó la API gráfica Vulkan por incompatibilidad con Vuforia en ciertos terminales.


Conflicto de Marcadores:

   -Problema: El sistema no reconocía la imagen del móvil.

    Solución: Se verificó que el Image Target en el Inspector coincidiera exactamente con la imagen física mostrada (cambio de marcador "piedras" por "camaleon").

   
   -Error de Compilación: "Android SDK missing build-tools"

    Problema: Unity no permitía generar el APK por falta de herramientas de Android.

    Solución: Se actualizaron las rutas en Edit > Preferences > External Tools, desmarcando y volviendo a marcar las casillas de SDK/NDK instalados con Unity para forzar el reconocimiento de las rutas.


# 5. Requisitos Opcionales Implementados
  
 Se integró una esfera roja (TargetPointer) que se posiciona en el punto exacto del impacto del raycast para dar respuesta visual al usuario.

Sincronización de Múltiples Agentes: El sistema permite que dos o más personajes calculen sus rutas de forma independiente y simultánea hacia el mismo objetivo.

Materiales Personalizados: Creación y asignación de materiales con texturas de piedra optimizadas para el renderizado móvil.

# 6. Conclusión

La práctica ha permitido profundizar en la importancia de las escalas en Realidad Aumentada y en la gestión de dependencias dentro de Unity. La integración de NavMesh sobre objetos rastreados demuestra que es posible crear entornos interactivos y dinámicos que responden al mundo físico con precisión.