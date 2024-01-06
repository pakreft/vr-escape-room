using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
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
    [SerializeField] Transform run;

    [SerializeField] Transform discReadyInfo;
    [SerializeField] Transform discReadyInfoBG;

    private float underscoreTimer = 0f;
    private float diskReadyTimer = 0f;

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

        runButton.onClick.AddListener(() => {
            run.gameObject.SetActive(true);
        });
    }

    private void Start() {
        runButton.gameObject.SetActive(false);
        runButtonText.gameObject.SetActive(false);

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameManager.Instance.IsDiskInserted()) {

            runButtonText.gameObject.SetActive(true);
            runButton.gameObject.SetActive(true);

        }
    }

    private void Update() {

        UpdateUnderscore();
        DiskReady();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void DiskReady() {
        if (GameManager.Instance.IsDiskInserted()) {
            discReadyInfoBG.gameObject.SetActive(true);
            diskReadyTimer += Time.deltaTime;

            if (diskReadyTimer >= 1) {
                diskReadyTimer = 0f;
            }

            if (diskReadyTimer <= .5f) {
            discReadyInfo.gameObject.SetActive(true);
                
            } else { discReadyInfo.gameObject.SetActive(false);}
        }
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
