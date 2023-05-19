using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClumsyController : MonoBehaviour {
  public int movement_speed;
  public int rotation_speed;
  private new Transform transform;
  
  private int score;
  GameObject text;
  void Start(){
    this.transform = GetComponent<Transform>();
    this.text = GameObject.FindWithTag("Score");
    this.movement_speed = 5;
    this.rotation_speed = 40;
    this.score = 0;
  }

  void Update(){
    this.move();
    this.rotate();
    this.getCoinOut();
  }

  private void move() {
    if (Input.GetKey(KeyCode.W)) this.transform.position += (Vector3.forward * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.A)) this.transform.position += (Vector3.left * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.S)) this.transform.position += (Vector3.back * Time.deltaTime) * this.movement_speed;
    if (Input.GetKey(KeyCode.D)) this.transform.position += (Vector3.right * Time.deltaTime) * this.movement_speed;
  }

  private void rotate() {
    if (Input.GetKey(KeyCode.Q)) this.transform.Rotate(new Vector3(0, Time.deltaTime * rotation_speed, 0), Space.Self);
    if (Input.GetKey(KeyCode.E)) this.transform.Rotate(new Vector3(0, -Time.deltaTime * rotation_speed,  0), Space.Self);
  }

  private void OnCollisionEnter(Collision collision) {
    switch (collision.gameObject.name) {
      case "Coin_1":
      case "Coin_2":
      case "Coin_3":
      case "Coin_4":
        this.score += 5;
        this.text.GetComponent<TextMesh>().text = this.score.ToString();
        break;
    }
  }

  void getCoinOut() {
    GameObject nonRigidCoin = GameObject.Find("Coin_4");
    if (Input.GetKey(KeyCode.Space)) {
      if (Mathf.Abs(nonRigidCoin.transform.position.x - this.transform.position.x) <= 1) {
        if (Mathf.Abs(nonRigidCoin.transform.position.z - this.transform.position.z) <= 1) {
          nonRigidCoin.transform.position += new Vector3(1,0,1);
        }
      }  
    }    
  }
}
