namespace Game.Player
{
    public class PlayerModel
    {
        public float Speed { get; }
        public float ShootRate  { get; }

        public PlayerModel(PlayerSettings playerSettings)
        {
            Speed = playerSettings.Speed;
            ShootRate = playerSettings.ShootRate;
        }
    }
}