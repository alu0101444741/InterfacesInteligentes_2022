using System.Collections;
using UnityEngine;


public class MonsterCameraPointer : MonoBehaviour {
  private const float _maxDistance = 10;
  private GameObject _gazedAtObject = null;

  private GameObject player;

  void Start(){
    this.player = GameObject.Find("PlayerCharacter");
  }
  
  public void Update() {
    this.transform.position = (this.player.transform.position + new Vector3(0, 1, 1));

    RaycastHit hit;
    if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance)){
      // GameObject detected in front of the camera.
      if (_gazedAtObject != hit.transform.gameObject){
        // New GameObject.
        _gazedAtObject?.SendMessage("OnPointerExit");
        _gazedAtObject = hit.transform.gameObject;
        _gazedAtObject.SendMessage("OnPointerEnter");
      }
    }
    else{
      // No GameObject detected in front of the camera.
      _gazedAtObject?.SendMessage("OnPointerExit");
      _gazedAtObject = null;
    }

    // Checks for screen touches.
    if (Google.XR.Cardboard.Api.IsTriggerPressed){
      _gazedAtObject?.SendMessage("OnPointerClick");
    }
  }
}
