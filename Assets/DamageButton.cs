using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            var characters = FindObjectsByType<Character>(FindObjectsSortMode.None);
            foreach (var character in characters)
            {
                character.TakeDamage();
            }
        });
    }
}
