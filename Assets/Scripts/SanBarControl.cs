using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SanBarControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("SanBar UI")]
    [SerializeField] private TextMeshProUGUI SanText;

    private static SanBarControl instance;
    private static int SanValue;

    public Slider slider;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Found more than one San instance in the scene");
        }
        instance = this;
    }

    void Start()
    {
        SanValue = 100;
        slider.value = SanValue;
        SanText.SetText("100");
    }
    
    public void DecreaseSan(int value) {
        SanValue -= value;
        SanText.SetText(SanValue.ToString());
        slider.value = SanValue;
    }
}
