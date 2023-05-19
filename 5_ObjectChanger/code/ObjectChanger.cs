using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChanger : MonoBehaviour{
  bool found;
  Vector3 rotation;

  void Start()    {
    this.found = false;
    this.rotation = new Vector3(0, 0.1f, 0);
  }

  void Update(){
    if (this.found) {
      this.transform.Rotate(this.rotation, Space.Self); 
    }
  }

  public void OnTargetFound(bool found){
    this.found = found;
  }
}