using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificador : MonoBehaviour {
  
  public delegate void mensaje();
  public event mensaje OnMiEvento;
  public int counter;  
  private GameObject text;

  void Start(){
    this.text = GameObject.Find("Counter");
    this.counter = 0;
  }

  void Update(){
    this.text.GetComponent<TextMesh>().text = "Counter: " + this.counter.ToString();
    this.counter ++;
    if (this.counter % 100 == 0) {
      OnMiEvento();
    }
  }
}
