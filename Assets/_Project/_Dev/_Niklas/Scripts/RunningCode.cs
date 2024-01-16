using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RunningCode : MonoBehaviour {


    [SerializeField] Texture[] Frames;
    
    private int i;
    Material codeFrames;
    int fps = 24;    

    void Awake() {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks * 1000);

    }

    // Use this for initialization
    void Start() {
        

        codeFrames = GetComponent<Renderer>().materials[0];
        
    }

    

    // Update is called once per frame
    void Update() {
        PlayCodeFrames();
        
    }

    private void PlayCodeFrames() {
                 

                i = (int)(Time.time * fps);
                i = i % Frames.Length;
                
                codeFrames.SetTexture("_EmissionMap", Frames[i]);  //_EmissiveColorMap (hdrp)

            }


        }

    


