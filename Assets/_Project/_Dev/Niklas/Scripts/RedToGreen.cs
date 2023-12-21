using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedToGreen : MonoBehaviour
{

    [SerializeField] Texture greenEmissionMap;
    [SerializeField] Texture redEmissionMap;

    Material material;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameManager.Instance.IsPowerOn()) {

            GreenLight();
        }

        if (GameManager.Instance.IsPowerOff()) {

            RedLight();
        }
    }

    private void RedLight() {

        if (redEmissionMap != null) {

            material = GetComponent<Renderer>().material;

            material.SetTexture("_EmissionMap", redEmissionMap);
        }
    }

    private void GreenLight() {

        material = GetComponent<Renderer>().material;

        if (greenEmissionMap != null) {
            material.SetTexture("_EmissionMap", greenEmissionMap);
        }
    }
}
