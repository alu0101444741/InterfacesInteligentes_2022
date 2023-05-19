using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryController : MonoBehaviour {
  public int movement_speed;
  private new Transform transform;
  void Start(){
    this.transform = GetComponent<Transform>();
    this.movement_speed = 5;
  }
  
  void Update(){
    this.move();    
  }

  private void move() {
    if (Input.GetKey(KeyCode.I)) this.transform.position += (Vector3.forward * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.J)) this.transform.position += (Vector3.left * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.M)) this.transform.position += (Vector3.back * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.L)) this.transform.position += (Vector3.right * Time.deltaTime) * this.movement_speed;
  }
}
