using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButton : MonoBehaviour
{
  private bool puzzleSolved = false; 
  private Transform[] piecesOnTable;
  private Transform[] piecesOnWall;
  void Start(){      
    GameObject[] piecesTable = GameObject.FindGameObjectsWithTag("PieceOnTable");
    GameObject[] piecesWall = GameObject.FindGameObjectsWithTag("PieceOnWall");

    //piecesOnWall = GameObject.FindGameObjectsWithTag("PieceOnWall");
    piecesOnTable = new Transform[piecesTable.Length];
    piecesOnWall = new Transform[piecesTable.Length];

    for (int i = 0; i < piecesTable.Length; ++i){
      piecesOnTable[i] = piecesTable[i].GetComponent<Transform>();
      piecesOnWall[i] = piecesWall[i].GetComponent<Transform>();
    }
  }
  
  void Update(){}

  void OnPointerEnter() {
    if (!puzzleSolved){
      SolvePuzzle();
    }
      puzzleSolved = true;
  }

  void SolvePuzzle(){
    for (int i = 0; i < piecesOnWall.Length; ++i){
      piecesOnTable[i].position = piecesOnWall[i].position;

    }
  }
}