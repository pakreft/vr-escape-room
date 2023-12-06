using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour { 

    [SerializeField]  Button log1Button;
    [SerializeField]  Button log2Button;
    [SerializeField]  Button log3Button;
    [SerializeField]  Button runButton;

    [SerializeField]  TextMeshProUGUI log1ButtonText;
    [SerializeField]  TextMeshProUGUI log2ButtonText;
    [SerializeField]  TextMeshProUGUI log3ButtonText;
    [SerializeField]  TextMeshProUGUI runButtonText;
    [SerializeField] TextMeshProUGUI underscoreText;

    [SerializeField] Image bgcolor;


    [SerializeField] Transform log1;
    [SerializeField] Transform log2;
    [SerializeField] Transform log3;

    private float underscoreTimer = 0f;

    private void Awake() {

        log1Button.onClick.AddListener(() => {
            log1.gameObject.SetActive(true);
        });

        log2Button.onClick.AddListener(() => {
            log2.gameObject.SetActive(true);
        });

        log3Button.onClick.AddListener(() => {
            log3.gameObject.SetActive(true);
        });

    }    

    private void Update() {

        UpdateUnderscore();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void UpdateUnderscore() {

        underscoreTimer += Time.deltaTime;

        if (underscoreTimer >= 1f) {
            underscoreTimer = 0f;
        }

        if (underscoreTimer <= .5f) {
            underscoreText.text = "_";
        } else { underscoreText.text = "";}


    }

    
}
