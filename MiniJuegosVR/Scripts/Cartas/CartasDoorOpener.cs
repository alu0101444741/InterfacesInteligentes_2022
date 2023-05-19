using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartasDoorOpener : MonoBehaviour{   
  private float initial_time = 0;
  private bool gazed = false;
  private GameObject CartasManager;
  private new Transform transform;
  // Start is called before the first frame update
  void Start() {   
    CartasManager = GameObject.Find("CartasManager");
    transform = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update() {
    if (gazed && Time.time - initial_time >= 2) {
      gazed = false;
      CartasManager.SendMessage("OpenDoor", this.transform);
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
}
