using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suscriptor : MonoBehaviour {

  private new Renderer renderer;
  public Notificador notificador;

  void Start(){
    this.renderer = GetComponent<Renderer>();
    this.notificador.OnMiEvento += this.miRespuesta;
  }

  void Update(){
      
  }

  void miRespuesta(){
    this.renderer.material.color = Random.ColorHSV();
  }
}