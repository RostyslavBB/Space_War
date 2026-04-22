using Game.Player;

public class PlayerShooting
{
    private float _timer;
    private readonly float _rate;

    public PlayerShooting(PlayerModel model)
    {
        _rate = model.ShootRate;
    }

    public bool CanShoot(float deltaTime)
    {
        _timer += deltaTime;

        if (_timer >= _rate)
        {
            _timer = 0;
            return true;
        }

        return false;
    }
}