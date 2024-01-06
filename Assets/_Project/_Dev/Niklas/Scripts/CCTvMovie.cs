using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CCTvMovie : MonoBehaviour 

{
    [ColorUsageAttribute(true, true)] public Color MaxBright = Color.black;
    public int BoostBright = 10;
    public bool IsReverse;
    public float Speed;
    public int MatId;
    public Texture[] Frames;
    int i;
    Material _Material;

    
    private bool IsPasswordEntered = true;
    private float startUpDelay;

    void Awake()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks * 1000);
        
    }

	// Use this for initialization
	void Start () 
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        startUpDelay = Random.Range(1f, 7f);

        _Material = GetComponent<Renderer>().materials[MatId];
        //bright
        float random = Random.Range(1.0f, 1.5f);
        random += BoostBright;
        //color variations
        float random2 = Random.Range(0.2f, 0.8f);
        float random3 = Random.Range(0.2f, 0.8f);
        float random4 = Random.Range(0.2f, 0.8f);
        _Material.SetColor("_EmissionColor", new Color(random + random2, random + random3, random + random4));
        //emission level
        if (MaxBright != Color.black) GetComponent<Renderer>().materials[MatId].SetColor("_EmissionColor", MaxBright);
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {

        if (GameManager.Instance.IsPowerOff()) {
            
            IsPasswordEntered = false;
        }

        if (GameManager.Instance.IsPasswordEntered()) {

            
            IsPasswordEntered = true;
            

        }
    }

    // Update is called once per frame
    void Update () 
    {
        PlayFrames();
        //Debug.Log(gameObject.name + "  " + startUpDelay);
    }

    private void PlayFrames() {
        if(IsPasswordEntered) {

            
            startUpDelay -= Time.deltaTime;
            if (startUpDelay < 0f) {

                i = (int)(Time.time * Speed);
                i = i % Frames.Length;
                if (IsReverse) i = (Frames.Length - 1) - i;
                _Material.SetTexture("_EmissionMap", Frames[i]);  //_EmissiveColorMap (hdrp)

            }

            
        }
        
    }
}
