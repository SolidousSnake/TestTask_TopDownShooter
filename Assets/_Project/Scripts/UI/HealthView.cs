using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Image _healthBar;

        [SerializeField] private string _format = " HP";
        [SerializeField] private float _maxBarValue;
        
        public void SetAmount(float amount)
        {
            _label.text = $"{amount}" + _format;
            _healthBar.fillAmount = amount / _maxBarValue;
        }
    }
}