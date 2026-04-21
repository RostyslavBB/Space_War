using UnityEngine;

namespace Game.Player
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public float Speed = 5f;
    }
}