using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LampColor : MonoBehaviour
{

    [ColorUsageAttribute(true, true)] public Color powerOffColor = new Color(0.3745098f, 0.0845623f, 0.07560857f, 0f);
    [ColorUsageAttribute(true, true)] public Color powerOnColor = new Color(0.3843137f, 0.945098f, 0.3411765f, 0f);

    [SerializeField] Light lamp;
    [SerializeField] Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameManager.Instance.IsPowerOn()) {
            
            LampPowerOn();
        }

        if (GameManager.Instance.IsPowerOff()) {

            LampPowerOff();
        }
    }

    private void LampPowerOn() {

        lamp.intensity = 3;
        lamp.color = new Color(0.3843137f, 0.945098f, 0.3411765f, 0f);

        material = GetComponent<Renderer>().material;

        material.SetColor("_EmissionColor", powerOnColor);

    }

    private void LampPowerOff() {

        lamp.intensity = 1f;
        lamp.color = powerOffColor;

        material = GetComponent<Renderer>().material;

        material.SetColor("_EmissionColor", powerOffColor);


    }
}
