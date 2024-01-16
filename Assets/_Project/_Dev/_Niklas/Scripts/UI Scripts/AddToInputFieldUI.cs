using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToInputFieldUI : MonoBehaviour
{


    
    
    [SerializeField] InputField inputField;

    public bool commandInputField = false;
     
    

    private void Start() {
        
    }


    public void AddToInputField(string Key = "") {

        if (inputField != null) {

            if (Key == "enter") {
                SubmitInput();

            } else if (Key == "back") {
                RemoveLastCharacter();
            } else {
                inputField.text += Key;
            }
        }
    }


    public void SubmitInput() {


        if (commandInputField) {
            if (CommandInputUI.Instance) {

                CommandInputUI.Instance.OnSubmit(inputField.text);
                
            }    
            
            }
        if (!commandInputField) {
            if (PasswordInputUI.Instance) {

                PasswordInputUI.Instance.OnSubmit(inputField.text);
                
            }



        }
    }
    // Funktion, um die letzte hinzugefügte Stelle des InputField zu löschen
    public void RemoveLastCharacter() {


        if (inputField != null && inputField.text.Length > 0) {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
}
