using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGridUI : MonoBehaviour
{

    [SerializeField] Image powerIcon;

    float powerIconTimer = 0f;

    // Update is called once per frame

    private void Start() {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {

        if (GameManager.Instance.IsPowerOn()) {
            Hide();
        }
    }

    void Update()
    {
        UpdateIcon();
    }

    private void UpdateIcon() {
        if (powerIcon != null) {

            powerIconTimer += Time.deltaTime;

            if (powerIconTimer >= 1f) {
                powerIconTimer = 0f;
            }

            if (powerIconTimer <= .5f) {
                powerIcon.gameObject.SetActive(false);
            } else { powerIcon.gameObject.SetActive(true); }
        }
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

   
    }

