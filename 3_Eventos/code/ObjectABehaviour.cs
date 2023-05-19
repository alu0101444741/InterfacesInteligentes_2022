using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Objetos tipo A --> CÁPSULAS
public class ObjectABehaviour : MonoBehaviour {
  private new Renderer renderer;
  private new Rigidbody rigidbody;
  public bool isGrounded;
  private Vector3 movementForward;
  private GameObject objectC;
  public PlayerController notificador;

  void Start(){
    this.renderer = this.GetComponent<Renderer>();
    this.rigidbody = this.GetComponent<Rigidbody>();
    this.isGrounded = true;

    this.objectC = GameObject.Find("Sphere_1");

    this.notificador.changeObjectA += this.collisionWithObjectB;
    this.notificador.changeObjectAB += this.collisionWithObjectC;
  }

  void collisionWithObjectB(){
    this.transform.LookAt(this.objectC.transform.position);

    this.movementForward = this.transform.forward;
    this.movementForward.x = this.movementForward.x * 0.1f;
    this.movementForward.y = this.movementForward.y * 0.1f;
    this.movementForward.z = this.movementForward.z * 0.1f;

    this.transform.position += this.movementForward;
  }

  void collisionWithObjectC(){
    if (this.isGrounded) {
      this.rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);      
      this.renderer.material.color = Random.ColorHSV();
      this.isGrounded = false;
    }        
  }

  void Update(){
      
  }  

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == "Terrain") {
      this.isGrounded = true;
    }   
  }
}