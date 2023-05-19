using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBBehaviour : MonoBehaviour {
  private new Transform transform;
  private GameObject target;
  private Transform targetTransform;

  public PlayerController notificador;

  private float rotationSpeed = 1.0f;
  private bool isRotating;

  void Start(){
    this.transform = this.GetComponent<Transform>();

    this.target = GameObject.Find("Target");
    this.targetTransform = target.GetComponent<Transform>();

    this.notificador.changeObjectB += this.collisionWithObjectA;
    this.notificador.changeObjectAB += this.collisionWithObjectC;
    this.notificador.changeObjectBRotate += this.stayOnObjectC;

    this.isRotating = false;
  }  

  void collisionWithObjectA(){
    this.transform.localScale += new Vector3(0, 0.2f, 0);
  }

  void collisionWithObjectC(){
    this.isRotating = true;     
  }

  void stayOnObjectC(){
    this.isRotating = true;     
  }

  void Update(){
    if (this.isRotating) {
      Vector3 targetDirection = targetTransform.localPosition - this.transform.localPosition;
      Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, this.rotationSpeed * Time.deltaTime, 0.0f);   
      
      // *******************************  Debug  *******************************
      /*string objectPosition = this.objectsB[i].name +
                              "(X:" + objectTransform.localPosition.x.ToString() +
                              ", Z:" +  objectTransform.localPosition.z.ToString() + ")";
      string targetPosition = objectsBTarget.name +
                              "(X:" + targetTransform.localPosition.x.ToString() +
                              ", Z:" +  targetTransform.localPosition.z.ToString() + ")";

      Debug.Log("Drawing a line from " + objectPosition + " to " + targetPosition);*/
      // *******************************         *******************************

      Debug.DrawRay(this.transform.position, newDirection, Color.red, 1, false);
      this.transform.localRotation = Quaternion.LookRotation(newDirection);
      this.isRotating = false;
    }    
  }
}