using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Movement playerScript;
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    private void Update()
    {
        healthBar.value = playerScript.currentHealth;
        healthBar.maxValue = playerScript.maxHealth;
        healthText.text = $"{healthBar.value} / {healthBar.maxValue}";
    }
}
