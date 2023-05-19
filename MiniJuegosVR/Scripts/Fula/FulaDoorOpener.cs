using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulaDoorOpener : MonoBehaviour{
    private new Transform transform;
    private GameObject fulaManager;
    private float initialTime;
    private bool gazed = false;
    void Start(){
      this.transform = this.GetComponent<Transform>();
      this.fulaManager = GameObject.Find("FulaManager");
    }

    // Update is called once per frame
    void Update(){
      if (gazed && ((Time.time - initialTime) >= 3)){        
        gazed = false;
        fulaManager.SendMessage("OpenDoor", this.transform);
      }
    }

    public void OnPointerEnter(RaycastHit hit){      
      initialTime = Time.time;
      gazed = true;
    }

    public void OnPointerExit(){
      gazed = false;
      initialTime = Time.time;
    }
}
