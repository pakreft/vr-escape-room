using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHingeJoint : MonoBehaviour
{
    
    private Rigidbody rb;

    void Start() {
        // Zugriff auf das HingeJoint-Komponente erhalten
        
        rb = GetComponent<Rigidbody>();
        
    }

    public void LockJoint() {
        rb.freezeRotation = true;
    }
}
