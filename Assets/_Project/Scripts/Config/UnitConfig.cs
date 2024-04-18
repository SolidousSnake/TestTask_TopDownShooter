using UnityEngine;

namespace _Project.Scripts.Config
{
    [CreateAssetMenu]
    public sealed class UnitConfig : ScriptableObject
    {
        public float Health;
        public float MovementSpeed;
        public float RotationSpeed;
    }
}