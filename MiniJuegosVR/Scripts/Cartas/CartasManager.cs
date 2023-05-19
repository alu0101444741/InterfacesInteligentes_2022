using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartasManager : MonoBehaviour {
  private Camera lobbyCamera;
  private Camera cartasCamera;
  private Transform cartasDoor;
  void Start(){
    cartasDoor = GameObject.Find("cartasDoor").GetComponent<Transform>();

    cartasCamera = GameObject.Find("CartasCamera").GetComponent<Camera>();
    lobbyCamera = GameObject.Find("LobbyCamera").GetComponent<Camera>();
  }

  void Update() {}

  public void OpenDoor(Transform doorTransform){
    if (cartasDoor == doorTransform){
      cartasCamera.enabled = false;
      cartasCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
      lobbyCamera.enabled = true;
      lobbyCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
    }
  }
}   
