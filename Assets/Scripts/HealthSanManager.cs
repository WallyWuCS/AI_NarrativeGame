using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSanManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Dialogue UI")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject sanBar;
    private HealthBarControl healthControlScript;
    private SanBarControl sanControlScript;
    void Start()
    {
        healthControlScript = healthBar.GetComponent<HealthBarControl>();
        sanControlScript = sanBar.GetComponent<SanBarControl>();
    }

    // Update is called once per frame
    void Update()
    {   
        //TODO: Need to limit the health and san value, should be 0-100
        if (Input.GetMouseButtonDown(1)) {
            healthControlScript.DecreaseHealth(5);
        }
        if (Input.GetMouseButtonDown(2)) {
            sanControlScript.DecreaseSan(5);
        }

    }
}
