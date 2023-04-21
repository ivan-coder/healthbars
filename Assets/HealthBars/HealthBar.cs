using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image fill;
        private int maxValue;
        private int value;

        public void Setup(int maxValue, int currentValue)
        {
            this.maxValue = maxValue;
            SetValue(currentValue);

            var delayedHealthBar = GetComponent<DelayedHealthBar>();
            if (delayedHealthBar != null)
            {
                delayedHealthBar.SetMaxValue(maxValue);
                delayedHealthBar.SetValue(currentValue);
            }
        }

        public void SetValue(int value)
        {
            fill.fillAmount = value / (float)maxValue;

            var delayedHealthBar = GetComponent<DelayedHealthBar>();
            if (delayedHealthBar != null)
            {
                delayedHealthBar.SetValue(value);
            }
        }
    }
}
