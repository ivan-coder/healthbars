using HealthBars;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform healthBarTransform;
    [SerializeField] private bool useDelayedHealthBar;
    private HealthBar healthBar;

    private int Health { get; set; } = 100;
    private int MaxHealth { get; set; }

    private void Start()
    {
        MaxHealth = Health;

        // Because there might be different types of health bars, we use a component to grab the one needed here.
        var factory = FindObjectOfType<HealthBarReferences>();
        GameObject healthBarPrefab = useDelayedHealthBar ? factory.DelayedHealthBar : factory.SimpleHealthBar;

        // Let know the health bar manager that a new character has been created,
        // so it can spawn a new health bar that will track this character health.
        var healthBarManager = FindObjectOfType<HealthBarManager>();
        healthBar = healthBarManager.Register(MaxHealth, Health, healthBarTransform, healthBarPrefab);
    }

    public void TakeDamage()
    {
        Health -= 10;
        if (Health < 0)
        {
            Health = MaxHealth;
        }

        healthBar.SetValue(Health);
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(direction.normalized * (Time.deltaTime * speed));
    }
}
