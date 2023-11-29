using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LogUI : MonoBehaviour
{
    [SerializeField] Button logCloseButton;

    public static LogUI Instance { get; private set; }


    private void Awake() {
        Hide();
        logCloseButton.onClick.AddListener(() => {
            Hide();
        });
    }
    

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Show() {
        gameObject.SetActive(true);
        Debug.Log("Showing Log1");
    }
}
