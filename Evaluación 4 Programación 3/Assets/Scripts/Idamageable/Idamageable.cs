// Define el contrato de recibir daño para cualquier entidad del juego.
// Implementada por al menos dos tipos distintos: el jugador y objetos del entorno (ej. barril, cactus).

namespace RPG.Combat
{
    public interface IDamageable
    {
        // Recibe una cantidad de daño. Cada clase decide cómo reacciona.
        void RecibirDanio(float cantidad);
    }
}
