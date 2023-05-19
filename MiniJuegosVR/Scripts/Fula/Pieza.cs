using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza : MonoBehaviour {
  private bool moving = false;
  private float distanceToWall;
  private new Transform transform;

  private Camera fulaCamera;
  private Transform fulaCameraTransform;
  private FulaManager manager;

  void Start() {
    fulaCamera = GameObject.Find("FulaCamera").GetComponent<Camera>();
    fulaCameraTransform = GameObject.Find("FulaCamera").GetComponent<Transform>();
    this.transform = GetComponent<Transform>();
    this.manager = GameObject.Find("FulaManager").GetComponent<FulaManager>();

    distanceToWall = Vector3.Distance(fulaCamera.transform.position, GameObject.Find("Puzzle").GetComponent<Transform>().position);
  }

  void Update() {
    if (this.moving) {      
      // Moviendo      
      //this.transform.position = fulaCameraTransform.position + fulaCamera.transform.forward * distanceToWall * 1.2f;      
      Vector3 puzzlePosition = GameObject.Find("Puzzle").GetComponent<Transform>().position;
      this.transform.position = fulaCameraTransform.position + fulaCamera.transform.forward * distanceToWall * 2f;
      Vector3 newPosition = new Vector3(puzzlePosition.x + 2.15f, transform.position.y, transform.position.z);
      this.transform.position = newPosition;

      // Objetivo a mirar
      Vector3 targetToLook = this.transform.position - new Vector3(5f, 0, 0);
      // Pieza mirando a la cámara
      //this.transform.LookAt(fulaCameraTransform);
      this.transform.LookAt(targetToLook);
    }
  }

  void OnPointerEnter() {
    if (!(this.manager.GetMovingPiece())) {
      this.moving = true;
      this.manager.MovingPiece(true);
    }
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == this.name) {
      this.moving = false;
      collision.gameObject.GetComponent<SpriteMask>().enabled = true;
      this.gameObject.SetActive(false);
      manager.MovingPiece(false);
      manager.DecreasePiecesOnWallCount();
    }
  }
}