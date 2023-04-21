using UnityEngine;

namespace HealthBars
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] Transform healthBarsContainer;
        [SerializeField] private GameObject defaultHealthBarPrefab;

        public HealthBar Register(int maxValue, int currentValue, Transform worldAnchor, GameObject healthBarPrefab)
        {
            var instance = Instantiate(healthBarPrefab, healthBarsContainer);
            var healthBar = instance.GetComponent<HealthBar>();
            healthBar.Setup(maxValue, currentValue);
            instance.GetComponent<FollowAnchor>().Setup(worldAnchor);
            return healthBar;
        }

        public HealthBar Register(int maxValue, int currentValue, Transform worldAnchor)
        {
            return Register(maxValue, currentValue, worldAnchor, defaultHealthBarPrefab);
        }
    }
}
