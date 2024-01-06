using System;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInputUI : MonoBehaviour {

    [SerializeField] private Transform LogOnScreen;
    [SerializeField] private InputField passwordInputField; // Das UI-InputField für die Passworteingabe
    [SerializeField] private Transform welcomeScreenUI;

    public event EventHandler OnWelcomeTimerStarted;
    private float welcomeTimer = 0f;
    private float resetTimer = 0f;
    private bool executeTimer = false;
    private bool executeResetTimer = false;

    public static PasswordInputUI Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        OnWelcomeTimerStarted += PasswordInputUI_OnWelcomeTimerStarted;
        
    }

    private void PasswordInputUI_OnWelcomeTimerStarted(object sender, EventArgs e) {
        executeTimer = true;
    }
    private void Update() {
        CountdownWelcomeScreen();
        CountdownResetTimer();

        }
        
    
    private void CountdownResetTimer() {
        if (executeResetTimer) {
            resetTimer += Time.deltaTime;
            if (resetTimer > 2f) {
                executeResetTimer = false;
                resetTimer = 0f;
                passwordInputField.text = string.Empty;
            }
        }
    }
    private void CountdownWelcomeScreen() {

        if (executeTimer) {
            welcomeTimer += Time.deltaTime;
            welcomeScreenUI.gameObject.SetActive(true);
            if (welcomeTimer > 2f) {
                LogOnScreen.gameObject.SetActive(false);
            }
        }
    }
    public void OnSubmit(string userInputString) {
        CheckPassword(userInputString);
    }
    // Methode zur Überprüfung des Passworts (Beispiel: Überprüfung auf "geheimesPasswort")
    private void CheckPassword(string userInputString) {
        if (userInputString == "0394") {
            OnWelcomeTimerStarted?.Invoke(this, EventArgs.Empty);
            GameManager.Instance.OnPasswordEntered();
            passwordInputField.text = string.Empty;

            Debug.Log("Passwort korrekt!");
        } else {
            passwordInputField.text = "*DENIED*";
            executeResetTimer = true;
        }


    }


}       
        

    