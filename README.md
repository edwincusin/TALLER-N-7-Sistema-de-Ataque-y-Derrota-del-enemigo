# Plataforma2D - Taller N° 7: Sistema de Ataque y Derrota del Enemigo

Proyecto de plataformas 2D desarrollado en **Unity 6.3 LTS (6000.3.25f1)**.
En este taller se implementa el sistema de combate cuerpo a cuerpo (melé) del personaje principal y la derrota del enemigo.

## 🎥 Video demostrativo

El video del taller **está incluido en este repositorio**:

📁 **`VIDEOTALLER7.mp4`**

En el video se muestra el modo Play con el personaje atacando con la tecla **Z** o **clic izquierdo** y eliminando a un enemigo tras **3 espadazos consecutivos**.

## 🎯 Objetivo

Implementar un sistema de combate que incluye:

- Animación de ataque activada por **Trigger**.
- Zona de impacto (Hitbox) con `Physics2D.OverlapCircleAll`.
- Destrucción del enemigo cuando se queda sin vidas.

## 🎮 Controles

| Acción | Tecla / Botón |
|--------|---------------|
| Atacar | `Z` o `Clic izquierdo` |

## 📜 Scripts del taller

| Script | Objeto donde va | Función |
|--------|-----------------|---------|
| `PlayerAttack.cs` | `Personaje` | Detecta la tecla Z / clic, activa la animación `Attack` y detecta enemigos dentro del radio de ataque. |
| `EnemyHealth.cs` | Prefab `Enemy` | Maneja la vida del enemigo (`vidaMaxima = 3`). Con `TakeDamage` resta vida y destruye al enemigo al llegar a 0. |

## ⚙️ Configuración en Unity

### 1. Animator
- Parámetro de tipo **Trigger** llamado `Attack`.
- Transición `Any State → ATTACK`: **sin** Has Exit Time.
- Transición `ATTACK → Idle`: **con** Has Exit Time y `Exit Time = 1`.

### 2. Marcador de ataque (Hitbox)
- Objeto vacío llamado `AttackPoint`, hijo de `Personaje`, ubicado al frente en la posición de la espada.

### 3. Capas e Inspector
- Capa `Enemy` asignada a los enemigos del mapa.
- En el componente `PlayerAttack` del personaje se conectan:
  - **Punto Ataque** → `AttackPoint`
  - **Capa Enemigos** → `Enemy`

## 🧠 Cómo funciona

1. El jugador presiona **Z** o **clic izquierdo**.
2. Se activa el trigger `Attack` y se reproduce la animación del espadazo.
3. Se crea un círculo en `AttackPoint` con `Physics2D.OverlapCircleAll(puntoAtaque.position, rangoAtaque, capaEnemigos)`.
4. A cada enemigo dentro del círculo se le llama `TakeDamage(danioAtaque)`.
5. Cuando la `vidaActual` del enemigo llega a 0, se ejecuta `Destroy(gameObject)`.

## 📂 Estructura del repositorio (resumen)

```
Plataforma2D/
├── Assets/
│   ├── Animations/
│   ├── Prefabs/
│   ├── Scenes/
│   ├── Scripts/
│   │   ├── EnemyHealth.cs
│   │   └── PlayerAttack.cs
│   └── Sprites/
├── VIDEOTALLER7.mp4      ← Video demostrativo
└── README.md
```

## ▶️ Cómo probar el proyecto

1. Clona el repositorio y ábrelo con **Unity 6.3 LTS**.
2. Abre la escena `Nivel1`.
3. Presiona **Play**.
4. Acércate a un enemigo y golpéalo 3 veces con **Z** o **clic izquierdo**.

## 👤 Autor

- **Nombre:** _(EdwinCsn)_
- **Taller:** Taller N° 7
