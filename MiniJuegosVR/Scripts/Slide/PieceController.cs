using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceController : MonoBehaviour{
    private GameObject slideManager;
    void Start(){
      this.slideManager = GameObject.Find("SlideManager");
    }

    public void OnPointerEnter(RaycastHit hit){
      slideManager.SendMessage("MovePiece", this.transform);
    }

    // Update is called once per frame
    void Update(){ }
}
