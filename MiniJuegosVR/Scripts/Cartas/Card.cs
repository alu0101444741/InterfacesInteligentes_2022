using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour{   
  private bool flipped = false;
  private bool found = false;
  private float initial_time = 0;
  private bool gazed = false;

  
  void Start(){}

  // Update is called once per frame
  void Update(){     
    if (gazed && Time.time - initial_time >= 2) {
      gazed = false;
      if (!flipped && !found) {
        Flip(true);
      }
    }
  }
  
  public void OnPointerEnter() {
    initial_time = Time.time;
    gazed = true;
  }

  public void OnPointerExit() {
    initial_time = Time.time;
    gazed = false;
  }

  public bool IsFlipped() {
    return flipped;
  }

  public void SetFound() {
    found = true;
  }

  public void Flip(bool flip) {
    this.gameObject.transform.Rotate(0, 0, 180);
    flipped = flip;
  }

  public bool IsFound() {
    return found;
  }
}
