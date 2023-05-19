using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public int movement_speed;
  public int rotation_speed;
  private new Transform transform;
  private new Rigidbody rigidbody;

  // Campos para Eventos
  public delegate void mensajeA();
  public event mensajeA changeObjectA;
  public delegate void mensajeB();
  public event mensajeB changeObjectB;
  public delegate void mensajeC();
  public event mensajeC changeObjectAB;
  public delegate void mensajeD();
  public event mensajeD changeObjectBRotate;

  void Start(){
    this.transform = GetComponent<Transform>();
    this.rigidbody = GetComponent<Rigidbody>();
    this.movement_speed = 5;
    this.rotation_speed = 100;
  }

  void Update(){
    this.move();
    this.rotate();
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "TypeA") {
      changeObjectB();
    }
    if (collision.gameObject.tag == "TypeB") {
      changeObjectA();
    }
    if (collision.gameObject.tag == "TypeC") {
      changeObjectAB();
    }
  }

  void OnCollisionStay(Collision collision) {
    if (collision.gameObject.tag == "TypeC") {
      changeObjectBRotate();
    }
  }

  private void move() {
    if (Input.GetKey(KeyCode.W)) this.transform.position += (Vector3.forward * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.A)) this.transform.position += (Vector3.left * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.S)) this.transform.position += (Vector3.back * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.D)) this.transform.position += (Vector3.right * Time.deltaTime) * this.movement_speed;  
  }

  private void rotate() {
    if (Input.GetKey(KeyCode.Q)) this.transform.Rotate(new Vector3(0, -Time.deltaTime * rotation_speed, 0), Space.World);
    if (Input.GetKey(KeyCode.E)) this.transform.Rotate(new Vector3(0, Time.deltaTime * rotation_speed,  0), Space.World);
  }
}
