using Game.DI;
using Game.Input;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private SignalBus _signalBus;

        public Vector3 Position => transform.position;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void SetNewPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public Vector3 GetWorldPosition(PlayerInput playerInput)
        {
            Vector3 screenPosition = new(playerInput.Position.x, playerInput.Position.y, 0f);
            Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);

            return worldPosition;
        }

        public void Death()
        {
            _signalBus.Fire<OnPlayerDeadSignal>();

            Destroy(gameObject);
        }
    }
}