using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorOpener : MonoBehaviour{
  private new Transform transform;
  private GameObject slideManager;
  private float initialTime;
  private bool gazed = false;
  void Start(){
    this.transform = this.GetComponent<Transform>();
    this.slideManager = GameObject.Find("SlideManager");
  }

  // Update is called once per frame
  void Update(){
    if (gazed && ((Time.time - initialTime) >= 3)){        
      gazed = false;
      slideManager.SendMessage("OpenDoor", this.transform);
    }
  }

  public void OnPointerEnter(){      
    initialTime = Time.time;
    gazed = true;
  }

  public void OnPointerExit(){
    gazed = false;
    initialTime = Time.time;
  }
}
