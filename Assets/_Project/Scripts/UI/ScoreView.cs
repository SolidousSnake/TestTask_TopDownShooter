using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        
        [SerializeField] private string _format = "Score: ";

        public void SetAmount(float amount)
        {
            _label.text = _format + $"{amount}";
        }
    }
}