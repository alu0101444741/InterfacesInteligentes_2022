using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour{
  private Camera lobbyCamera;
  private Camera slideCamera;
  Transform slideDoor;

  public new Transform transform;
  public Transform piecePrefab;
  private List<Transform> pieces;
  private int emptyLocation;
  private int size;
  private bool shuffling = false;
  private bool finished = false;
  private GameObject lastPiece;

  // Start is called before the first frame update
 void Start(){
    slideDoor = GameObject.Find("slideDoor").GetComponent<Transform>();

    slideCamera = GameObject.Find("SlideCamera").GetComponent<Camera>();
    lobbyCamera = GameObject.Find("LobbyCamera").GetComponent<Camera>();

    size = 3;
    pieces = new List<Transform>();
    CreateGamePieces(0.01f);
    CenterColliders();

    shuffling = true;
    StartCoroutine(WaitShuffle(0.5f));
  }

  // Update is called once per frame
  void Update(){
    RelocateCamera();
    if(!finished && !shuffling && CheckCompletion()){
      finished = true;
      lastPiece.SetActive(true);
      GameObject[] slidePieces = GameObject.FindGameObjectsWithTag(lastPiece.gameObject.tag);
      for (int i = 0; i < slidePieces.Length; i++){
        slidePieces[i].AddComponent<Rigidbody>();
        slidePieces[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.Range(0.5f, 1.2f), -Random.Range(0.5f, 1.2f)), ForceMode.Impulse); 
      }
    }
  }

  public void OpenDoor(Transform doorTransform){
    if (slideDoor == doorTransform){
      slideCamera.enabled = false;
      slideCamera.gameObject.GetComponent<CameraPointer>().enabled = false;
      lobbyCamera.enabled = true;
      lobbyCamera.gameObject.GetComponent<CameraPointer>().enabled = true;
    }
  }

  public void MovePiece(Transform pieceTransform){
    if (!finished) {
      int numberOfPieces = pieces.Count;
      for (int i = 0; i < numberOfPieces; ++i){
        if (pieceTransform == pieces[i]){
          if(SwapIfValid(i, -size, size)) break;
          if(SwapIfValid(i,  size, size)) break;
          if(SwapIfValid(i,    -1,    0)) break;
          if(SwapIfValid(i,     1, size - 1)) break;
        }
      }
    }       
  }

  

  private void CreateGamePieces(float gapThickness){
    float width = 1 / (float)size;
    float gap = gapThickness / 2;
    Vector2[] uv = new Vector2[4];

    for (int row = 0; row < size; ++row){
      for (int column = 0; column < size; ++column){
        Transform piece = Instantiate(piecePrefab, this.transform);
        pieces.Add(piece);
        piece.localPosition = new Vector3(-1 + (2 * width * column) + width,
                                           1 - (2 * width * row)    - width,  0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + column}";
        piece.gameObject.AddComponent<PieceController>();

        // Necesario para que reviente al finalizar
        piece.gameObject.tag = "SlidePieces";
        // ****************************************

        if ((row == size - 1) && (column == size - 1)){
          emptyLocation = (size * size) - 1;
          lastPiece = piece.gameObject;
          piece.gameObject.SetActive(false);
        }
        
        Mesh mesh = piece.GetComponent<MeshFilter>().mesh;         

        uv[0] = new Vector2((width *  column)       + gap, 1 - ((width * (row + 1)) - gap));
        uv[1] = new Vector2((width * (column  + 1)) - gap, 1 - ((width * (row + 1)) - gap));
        uv[2] = new Vector2((width *  column)       + gap, 1 - ((width * row)       + gap));
        uv[3] = new Vector2((width * (column + 1))  - gap, 1 - ((width * row)       + gap));

        mesh.uv = uv;
        
      }
    }
  }

  private bool CheckCompletion(){
    int numberOfPieces = pieces.Count;
    for (int i = 0; i < numberOfPieces; ++i){
      if (pieces[i].name != $"{i}") return(false);
    }
    return(true);
  }

  private void Shuffle(){
    int count = 0;
    int lastMove = 0;
    while (count < /*(size * size * size)*/size){
      int randomLocation = Random.Range(0, size * size);
      if (randomLocation == lastMove) continue;
      lastMove = emptyLocation;
      if(SwapIfValid(randomLocation, -size, size)) count++;
      else if(SwapIfValid(randomLocation,  size, size)) count++;
      else if(SwapIfValid(randomLocation,    -1,    0)) count++;
      else if(SwapIfValid(randomLocation,     1, size - 1)) count++;
    }
  }
  private bool SwapIfValid(int index, int offset, int column){
    if (((index % size) != column) && ((index + offset) == emptyLocation)){
      (pieces[index], pieces[index + offset]) = (pieces[index + offset], pieces[index]);
      (pieces[index].localPosition, pieces[index + offset].localPosition) = (pieces[index + offset].localPosition, pieces[index].localPosition);
      emptyLocation = index;
      return(true);
    }
    return(false);
  }

  private IEnumerator WaitShuffle(float duration){
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
  }

  private void CenterColliders(){
    int numberOfPieces = pieces.Count;
    for (int i = 0; i < numberOfPieces; ++i){
      pieces[i].GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
    }
  }

  private void RelocateCamera(){
    Vector3 centerPosition = slideDoor.localPosition;
    centerPosition += new Vector3(-0.45f, -2.3f, 5);
    slideCamera.GetComponent<Transform>().localPosition = centerPosition;
  } 
}