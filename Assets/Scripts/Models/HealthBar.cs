using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private RectTransform _rectTransform;

        public float CurrentHealth
        {
            get => _slider.value;
            set => _slider.value = value;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}