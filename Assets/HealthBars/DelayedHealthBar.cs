using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    public class DelayedHealthBar : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float delay;
        private int value;
        private float delayedTarget;
        private bool updatingDelayedSlider;
        private float smoothCurrentVelocity;

        private bool updatingBar;
        private int maxValue = -1;

        public void SetMaxValue(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public void SetValue(int value)
        {
            int oldValue = this.value;
            this.value = value;
            delayedTarget = this.value / (float)maxValue;

            if (oldValue > this.value)
            {
                StartCoroutine(WaitToStartUpdatingBar());
            }
            else
            {
                updatingBar = true;
            }
        }

        void Update()
        {
            if (maxValue == -1) return;

            const float tolerance = 0.01f;

            if (!updatingBar) return;

            image.fillAmount = Mathf.SmoothDamp(image.fillAmount, delayedTarget, ref smoothCurrentVelocity, Time.deltaTime * 20);
            if (Math.Abs(image.fillAmount - delayedTarget) >= tolerance) return;

            image.fillAmount = delayedTarget;
            updatingBar = false;
        }

        private IEnumerator WaitToStartUpdatingBar()
        {
            yield return new WaitForSeconds(delay);
            updatingBar = true;
        }
    }
}
