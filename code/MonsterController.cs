using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {  
  private new Transform transform;
  public new Camera camera;

  public float movementSpeed;
  public float rotationSpeed;

  private GameObject chestMonster;
  private GameObject[] eggs;
  private GameObject[] spiders;

  private GameObject text;
  private float maxHealth = 100f;
  private float health;
  private int proximity_sensitivity = 2;

  void Start(){
    this.camera = Camera.main;
    this.transform = this.GetComponent<Transform>();
    this.movementSpeed = 5f;

    // Referencias a objetos que reaccionan a las acciones del usuario
    this.chestMonster = GameObject.Find("ChestMonster");
    this.eggs = GameObject.FindGameObjectsWithTag("Egg");
    this.spiders = GameObject.FindGameObjectsWithTag("Spider");

    // Contador de vida
    this.text = GameObject.Find("Health");
    this.health = maxHealth;
  }

  void Update(){
    this.rotate();
    this.move();
    this.teleport();
    this.camera.transform.LookAt(this.transform);

    this.checkSpiderProximity();

    // Actualización del contador de vida
    this.text.GetComponent<TextMesh>().text = "Health: " + this.health.ToString();
    this.text.GetComponent<TextMesh>().transform.position = (this.transform.position + new Vector3(-2, 3, 0));
  }

  private void move() {
    this.transform.Translate(  Input.GetAxis("Vertical") * (this.transform.forward * Time.deltaTime) * this.movementSpeed, Space.Self);
    this.transform.Translate(Input.GetAxis("Horizontal") * (this.transform.right   * Time.deltaTime) * this.movementSpeed, Space.Self); 
  }

  private void rotate() {
    if (Input.GetKey(KeyCode.Q)) this.transform.Rotate(Vector3.up * rotationSpeed * -Time.deltaTime, Space.Self);
    if (Input.GetKey(KeyCode.E)) this.transform.Rotate(Vector3.up * rotationSpeed *  Time.deltaTime, Space.Self);
  }

  private void teleport() {
    if (Input.GetKey(KeyCode.T)) this.transform.position += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == this.chestMonster.name) {
      for (int i=0; i < this.eggs.Length; ++i) {
        this.eggs[i].transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
      }  
    } 
  }

  void checkSpiderProximity() { 
    for (int i=0; i < this.spiders.Length; ++i) {
      if (Mathf.Abs(this.spiders[i].transform.position.x - this.transform.position.x) <= this.proximity_sensitivity) {
        if (Mathf.Abs(this.spiders[i].transform.position.z - this.transform.position.z) <= this.proximity_sensitivity) {
          this.health -= 0.01f;
        }
      }
    }    
  }
}