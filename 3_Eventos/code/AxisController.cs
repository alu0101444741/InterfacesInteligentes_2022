using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour {  
  private new Transform transform;
  public int movementSpeed;
  public int rotationSpeed;

  void Start(){
    this.transform = GetComponent<Transform>();

    this.movementSpeed = 5;
    this.rotationSpeed = 3;
  }

  void Update(){
    this.move();
    this.mouseRotation();
  }

  void move() {
    this.transform.position += Input.GetAxis("Vertical") * (this.transform.forward * Time.deltaTime) * this.movementSpeed;
    this.transform.position += Input.GetAxis("Horizontal") * (this.transform.right * Time.deltaTime) * this.movementSpeed; 
  }

  void mouseRotation() {
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");
    //float mouseZ = Input.GetAxis("Mouse Z");
    this.transform.Rotate(new Vector3(-mouseY * rotationSpeed, mouseX * rotationSpeed, 0));
    this.transform.localRotation = this.transform.rotation;//.Rotate(new Vector3(-mouseY * rotationSpeed, -mouseX * rotationSpeed, 0));
  }
}