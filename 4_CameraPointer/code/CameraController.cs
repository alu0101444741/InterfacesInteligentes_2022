using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  private new Transform transform;
  public float rotationSpeed;
  public float mouseRotationSpeed;

  void Start(){
    this.transform = this.GetComponent<Transform>();
    this.rotationSpeed = 75f;
    this.mouseRotationSpeed = 5f;
  }

  void Update(){
    this.rotate();
    //this.mouseRotation();
  }

  private void rotate() {
    if (Input.GetKey(KeyCode.Q)) this.transform.Rotate(Vector3.up * rotationSpeed * -Time.deltaTime, Space.Self);
    if (Input.GetKey(KeyCode.E)) this.transform.Rotate(Vector3.up * rotationSpeed *  Time.deltaTime, Space.Self);
  }

  private void mouseRotation() {
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");
    this.transform.Rotate(new Vector3(-mouseY * mouseRotationSpeed, mouseX * mouseRotationSpeed, 0));
    this.transform.localRotation = this.transform.rotation;//.Rotate(new Vector3(-mouseY * rotationSpeed, -mouseX * rotationSpeed, 0));
  }
}