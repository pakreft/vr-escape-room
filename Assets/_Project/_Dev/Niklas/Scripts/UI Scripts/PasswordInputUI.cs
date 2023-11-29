using System;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInputUI : MonoBehaviour {

    [SerializeField] private Transform LogOnScreen;
    [SerializeField] private InputField passwordInputField; // Das UI-InputField für die Passworteingabe
    [SerializeField] private Transform welcomeScreenUI;

    public event EventHandler OnWelcomeTimerStarted;
    private float welcomeTimer = 0f;
    private bool executeTimer = false;

    private void Start() {
        OnWelcomeTimerStarted += PasswordInputUI_OnWelcomeTimerStarted;
    }

    private void PasswordInputUI_OnWelcomeTimerStarted(object sender, EventArgs e) {
        executeTimer = true;
    }
    private void Update() {
        CountdownWelcomeScreen();

        }
        /*
        OnPasswordEntered();
    }
    // Wird aufgerufen, wenn der Benutzer das Passwort eingibt und Enter drückt
    public void OnPasswordEntered() {
        string enteredPassword = passwordInputField.text;

        // Hier kannst du das eingegebene Passwort verwenden oder überprüfen
        CheckPassword(enteredPassword);
        */
    

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
        if (userInputString == "1234") {
            OnWelcomeTimerStarted?.Invoke(this, EventArgs.Empty);

            Debug.Log("Passwort korrekt!");
        } else {
            passwordInputField.text = "--------";
        }


    }


}       
        

    