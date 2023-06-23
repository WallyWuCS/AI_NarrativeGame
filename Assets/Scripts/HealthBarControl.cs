using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("HealthBar UI")]
    [SerializeField] private TextMeshProUGUI healthText;

    private static HealthBarControl instance;
    private static int healthValue;

    public Slider slider;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Found more than one health instance in the scene");
        }
        instance = this;
    }

    void Start()
    {
        healthValue = 100;
        slider.value = healthValue;
        healthText.SetText("100");
    }
    
    public void DecreaseHealth(int value) {
        healthValue -= value;
        healthText.SetText(healthValue.ToString());
        slider.value = healthValue;
    }
}
