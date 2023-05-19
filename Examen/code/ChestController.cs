
using System.Collections;
using UnityEngine;

public class ChestController : MonoBehaviour {
  
  private const float _minObjectDistance = 2.5f;
  private const float _maxObjectDistance = 3.5f;
  private const float _minObjectHeight = 0.5f;
  private const float _maxObjectHeight = 3.5f;

  private GameObject[] spiders;
  public float rotationSpeed = 75f;

  private bool redSpidersRotating;

  public void Start(){
    this.spiders = GameObject.FindGameObjectsWithTag("Spider");
    this.triggerActions(false);
    this.redSpidersRotating = false;
  }

  void Update() {
    for (int i=0; i < this.spiders.Length; ++i) {
      if ((this.redSpidersRotating) && (this.spiders[i].name.Contains("Red"))) {
        this.spiders[i].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
      }
    }
  } 
  
  public void OnPointerEnter(){
    triggerActions(true);
    this.redSpidersRotating = true;
  }
  
  public void OnPointerExit(){
    triggerActions(false);
    this.redSpidersRotating = false;
  }

  private void triggerActions(bool gazedAt){
    if (gazedAt) {
      for (int i=0; i < this.spiders.Length; ++i) {
        if (this.spiders[i].name.Contains("Green")) {
          this.spiders[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
      }
    }
  }
}
