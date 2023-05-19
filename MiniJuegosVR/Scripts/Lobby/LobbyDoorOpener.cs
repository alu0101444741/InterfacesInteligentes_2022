using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDoorOpener : MonoBehaviour{
  private new Transform transform;
  private GameObject lobbyManager;
  private float initialTime;
  private bool gazed = false;
  void Start(){
    this.transform = this.GetComponent<Transform>();
    this.lobbyManager = GameObject.Find("LobbyManager");
  }

  // Update is called once per frame
  void Update(){
    if (gazed && ((Time.time - initialTime) >= 3)){        
      gazed = false;
      lobbyManager.SendMessage("OpenDoor", this.transform);        
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
