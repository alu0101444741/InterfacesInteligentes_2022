using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LobbyManager : MonoBehaviour{
  private List<Transform> doors;

  private Camera slideCamera;
  private Camera fulaCamera;
  private Camera cartasCamera;  
  private Camera lobbyCamera;


  void Start(){
    doors = new List<Transform>();
    doors.Add(GameObject.Find("SlidingDoor").GetComponent<Transform>());
    doors.Add(GameObject.Find("FulaDoor").GetComponent<Transform>());
    doors.Add(GameObject.Find("CartasDoor").GetComponent<Transform>());
  
    slideCamera = GameObject.Find("SlideCamera").GetComponent<Camera>();
    fulaCamera = GameObject.Find("FulaCamera").GetComponent<Camera>();
    cartasCamera = GameObject.Find("CartasCamera").GetComponent<Camera>();    
    
   
    lobbyCamera = GameObject.Find("LobbyCamera").GetComponent<Camera>();
    DeactivateCameras();    
  }

  // Update is called once per frame
  void Update(){   
    RelocateCamera();    
  }

  public void OpenDoor(Transform doorTransform){
    if (doorTransform == doors[0]){
      slideCamera.enabled = true;
      slideCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
    }
    else if (doorTransform == doors[1]){
      fulaCamera.enabled = true;
      fulaCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
    }
    else if (doorTransform == doors[2]){
      cartasCamera.enabled = true;
      cartasCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
      if(GameObject.Find("CartasManager").GetComponent<CardGameInitializer>() == null) {
        GameObject.Find("CartasManager").AddComponent<CardGameInitializer>();
      }      
    }

    lobbyCamera.enabled = false;
    lobbyCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
  } 

  private void DeactivateCameras(){
    slideCamera.enabled = false;
    fulaCamera.enabled = false;    
    cartasCamera.enabled = false;

    slideCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
    fulaCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
    cartasCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
  }

  private void RelocateCamera(){
    Vector3 centerPosition = GameObject.Find("SlidingDoor").GetComponent<Transform>().localPosition;
    float newZ = centerPosition.z - GameObject.Find("CartasDoor").GetComponent<Transform>().localPosition.z;
    float newX = centerPosition.x - GameObject.Find("FulaDoor").GetComponent<Transform>().localPosition.x;
    centerPosition = new Vector3(newX / 1.2f, centerPosition.y + 4f, - newZ / 3f);
    lobbyCamera.GetComponent<Transform>().localPosition = centerPosition;
  } 
}

