using UnityEngine;

public class HealthBarReferences : MonoBehaviour
{
    [SerializeField] private GameObject simpleHealthBar;
    public GameObject SimpleHealthBar => simpleHealthBar;

    [SerializeField] private GameObject delayedHealthBar;
    public GameObject DelayedHealthBar => delayedHealthBar;
}
