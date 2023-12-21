using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloppyDistance : MonoBehaviour
{

    [SerializeField] Transform floppyDisc;
    [SerializeField] GameObject floppyDiscProjection;

    public float proximityThreshold = 1f;


    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector3.Distance(transform.position, floppyDisc.position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        
    }


    private void CheckDistance() {
        float distance = Vector3.Distance(transform.position, floppyDisc.position);
        Debug.Log("Distanz zur Disc:  " + distance);
        if (distance < proximityThreshold) {
            Show();
        } else {
            Hide();
        }
    }
    private void Show() {
        floppyDiscProjection.SetActive(true);
    }

    private void Hide() {
        floppyDiscProjection.SetActive(false);
    }
}
