namespace Game.DI
{
    public readonly struct OnPlayerDeadSignal { }

    public struct OnEnemyDeadSignal 
    {
        public int Score;
    }
}