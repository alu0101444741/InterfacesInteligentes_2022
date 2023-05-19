using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {
  private new Renderer renderer;
  private new Transform transform;
  int rotation_speed = 100;

  void Start(){
    this.renderer = GetComponent<Renderer>();
    this.renderer.material.color = Color.yellow;
    this.transform = GetComponent<Transform>();
  }

  void Update(){    
    this.transform.Rotate(new Vector3(Time.deltaTime * rotation_speed, 0, 0), Space.Self);
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == "Cube_Player") {
        this.transform.localScale += new Vector3(0.1f, 0, 0.1f);
    }
  }
}