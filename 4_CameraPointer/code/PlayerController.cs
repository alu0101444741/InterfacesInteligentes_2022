using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {  
  private new Transform transform;
  public new Camera camera;
  public float movementSpeed;
  public float rotationSpeed;

  void Start(){
    this.transform = this.GetComponent<Transform>();
    this.movementSpeed = 5f;
  }

  void Update(){
    this.rotate();
    this.move();
    
  }

  private void move() {
    /*Vector3 forward = this.camera.transform.forward;
    Vector3 right = this.camera.transform.right;
    forward.y = 0;
    forward.y = 0;*/
    this.transform.Translate(  Input.GetAxis("Vertical") * (this.camera.transform.forward * Time.deltaTime) * this.movementSpeed, Space.Self);
    this.transform.Translate(Input.GetAxis("Horizontal") * (this.camera.transform.right   * Time.deltaTime) * this.movementSpeed, Space.Self); 
  }

  private void rotate() {
    if (Input.GetKey(KeyCode.Q)) this.transform.Rotate(Vector3.up * rotationSpeed * -Time.deltaTime, Space.Self);
    if (Input.GetKey(KeyCode.E)) this.transform.Rotate(Vector3.up * rotationSpeed *  Time.deltaTime, Space.Self);
  }
}