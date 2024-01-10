using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

    private enum State {
        PowerOff,
        PowerOn,
        PasswordEntered,
        DiscInserted,
        RedPillExe,      
    }
    private State state;


    private void Awake() {
        Instance = this;
        state = State.PowerOff;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.PowerOff:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.PowerOn:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.PasswordEntered:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.DiscInserted:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.RedPillExe:
                break;
        }
    }


    public bool IsPasswordEntered() {
        return state == State.PasswordEntered;
    }

    public bool IsPowerOff() {
        return state == State.PowerOff;
    }

    public bool IsPowerOn() {
        return state == State.PowerOn;
    }

    public bool IsDiskInserted() {
        return state == State.DiscInserted;
    }

    public void OnLeverMax() {
        state = State.PowerOn;
    }

    public void OnLeverMin() {
        state = State.PowerOff;
        Debug.Log(" Power Off");
    }

    public void OnPasswordEntered() {
        state = State.PasswordEntered;
    }

    public void OnDiscInserted() {
        state = State.DiscInserted;
        Debug.Log("DiscInserted");
    }

    public void ButtonTest() {
        Debug.Log("Button gedrückt");
    }
}
