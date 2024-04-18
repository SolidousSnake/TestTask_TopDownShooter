using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Weapon
{
    public interface IWeapon
    {
        public UniTask Use();
    }
}