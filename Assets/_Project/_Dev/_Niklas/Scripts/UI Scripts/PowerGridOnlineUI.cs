using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGridOnlineUI : MonoBehaviour
{

    [SerializeField] Image flashImage;
    [SerializeField] Button hideGridOnlineScreenButton;
    [SerializeField] GameObject logOnScreen;
    // Start is called before the first frame update

    float flashIconTimer = 0f;
    void Start()
    {
        hideGridOnlineScreenButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
            logOnScreen.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateImage();
    }

    private void UpdateImage() {
        if (flashImage != null) {
            flashIconTimer += Time.deltaTime;

            if (flashIconTimer >= 2f) {
                flashIconTimer = 0f;
            }

            if (flashIconTimer <= 1f) {
                flashImage.gameObject.SetActive(false);
            } else { flashImage.gameObject.SetActive(true); }
        }
    }


    }

