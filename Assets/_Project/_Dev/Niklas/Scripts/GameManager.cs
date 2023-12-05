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
        StickInserted,
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
            case State.StickInserted:
                break;
            case State.RedPillExe:
                break;
        }
    }

    public bool IsPowerOff() {
        return state == State.PowerOff;
    }

    public bool IsPowerOn() {
        return state == State.PowerOn;
    }

    public void OnLeverMax() {
        state = State.PowerOn;
    }
    
}
