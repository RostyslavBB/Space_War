using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement 
    {
        private readonly PlayerModel _model;

        public PlayerMovement(PlayerModel model)
        {
            _model = model;
        }

        public float CalculateX(float current, float target, float deltaTime)
        {
            return Mathf.Lerp(current, target, _model.Speed * deltaTime);  
        }
    }
}