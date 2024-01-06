using System;
using UnityEngine;
using UnityEngine.UI;

public class CommandInputUI : MonoBehaviour {

    
    [SerializeField] private InputField commandInputField; // Das UI-InputField für die Passworteingabe
    

    
   
    private float resetTimer = 0f;
    
    private bool executeResetTimer = false;

    public static CommandInputUI Instance { get; private set; }

    private void Awake() {

        Instance = this;
    }

    private void Start() {
        commandInputField.text = string.Empty;

    }

    
    private void Update() {
        
        CountdownResetTimer();

    }
    

    private void CountdownResetTimer() {
        if (executeResetTimer) {
            resetTimer += Time.deltaTime;
            if (resetTimer > 1f) {
                executeResetTimer = false;
                resetTimer = 0f;
                commandInputField.text = string.Empty;
            }
        }
    }
    
    public void OnSubmit(string userInputString) {
        CheckInput(userInputString);
    }
    // Methode zur Überprüfung des Passworts (Beispiel: Überprüfung auf "geheimesPasswort")
    private void CheckInput(string userInputString) {
        if (userInputString == "CHKDSK32") {
            commandInputField.text = string.Empty;

            Debug.Log("CHKDSK!");
        } else {
            commandInputField.text = "*UNKNOWN PROMPT*";
            executeResetTimer = true;
        }


    }


}


