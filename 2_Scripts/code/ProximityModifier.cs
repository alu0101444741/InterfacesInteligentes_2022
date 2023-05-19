using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityModifier : MonoBehaviour{
  private new Transform transform;
  GameObject player;
  GameObject[] spheres;
  private int proximity_sensitivity;
  void Start(){  
    this.transform = GetComponent<Transform>();
    this.player = GameObject.Find("Cube_Player");
    this.spheres = GameObject.FindGameObjectsWithTag("Esfera");
    this.proximity_sensitivity = 2;
  }

  void Update(){
    this.checkPlayerIsNear();
    this.checkSpheresAreNear();
  }

  void checkPlayerIsNear() {    
    if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= this.proximity_sensitivity) {
      if (Mathf.Abs(player.transform.position.z - this.transform.position.z) <= this.proximity_sensitivity) {
        this.transform.localScale += new Vector3(0, -0.001f, 0);
      }
    }
  }

  void checkSpheresAreNear() { 
    for (int i=0; i < this.spheres.Length; ++i) {
      if (Mathf.Abs(spheres[i].transform.position.x - this.transform.position.x) <= this.proximity_sensitivity) {
        if (Mathf.Abs(spheres[i].transform.position.z - this.transform.position.z) <= this.proximity_sensitivity) {
          this.transform.localScale += new Vector3(0, 0.001f, 0);
        }
      }
    }    
  }
}
