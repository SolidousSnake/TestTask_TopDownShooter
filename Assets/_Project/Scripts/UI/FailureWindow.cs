using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public sealed class FailureWindow : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(Restart);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}