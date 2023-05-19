using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulaManager : MonoBehaviour{
    private Camera lobbyCamera;
    private Camera fulaCamera;
    private Transform fulaDoor;

    private bool movingPiece = false;
    private GameObject[] piecesOnWall;
    private int piecesOnWallCount;
    private bool puzzleSolved = false;
    
    void Start(){
      fulaDoor = GameObject.Find("fulaDoor").GetComponent<Transform>();

      fulaCamera = GameObject.Find("FulaCamera").GetComponent<Camera>();
      lobbyCamera = GameObject.Find("LobbyCamera").GetComponent<Camera>();

      this.piecesOnWall = GameObject.FindGameObjectsWithTag("PieceOnWall");
      piecesOnWallCount = piecesOnWall.Length;
      for (int i = 0; i < piecesOnWallCount; i++){
        piecesOnWall[i].GetComponent<SpriteMask>().enabled = false;
        Vector3 newSize = piecesOnWall[i].GetComponent<BoxCollider>().size;
        piecesOnWall[i].GetComponent<BoxCollider>().size.Set(newSize.x, newSize.y, newSize.z + 0.5f);
      }
    }

    // Update is called once per frame
    void Update(){
      if ((piecesOnWallCount <= 0) && !puzzleSolved){
        puzzleSolved = true;
        for (int i = 0; i < piecesOnWall.Length; i++){
          piecesOnWall[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
      }
      RelocateCamera(); 
    }

    public void OpenDoor(Transform doorTransform){
      if (fulaDoor == doorTransform){
        fulaCamera.enabled = false;
        fulaCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
        lobbyCamera.enabled = true;
        lobbyCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
      }
    }

    public void MovingPiece(bool moving){
      movingPiece = moving;
    }

    public bool GetMovingPiece(){
      return(movingPiece);
    }

    public void DecreasePiecesOnWallCount(){
      piecesOnWallCount--;
    }

    private void RelocateCamera(){
      Vector3 centerPosition = GameObject.Find("TablePuzzle").GetComponent<Transform>().localPosition;
      centerPosition -= new Vector3(0, -3.5f, 5);
      fulaCamera.GetComponent<Transform>().localPosition = centerPosition;
    }
}
