using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameInitializer : MonoBehaviour {
  private string[] types = {"Club", "Diamond", "Heart", "Spade"};
  public int number_cards = 20;
  private List<GameObject> cards = new List<GameObject>();
  private List<int> indexes;
  private List<GameObject> flipped_cards = new List<GameObject>();
  private float delaytime;
  private bool waiting = false;
  private bool gameOn = false;

  // Start is called before the first frame update
  void Start() {        
    indexes = new List<int>(20);
    for (int index = 0; index < indexes.Capacity; index++) {
      indexes.Add(index);
    }
    SelectRandomCards();
    InstantiateCards();

    delaytime = Time.time;
  }

  // Update is called once per frame
  void Update() {   
    if (!gameOn && (Time.time - delaytime >= 5)) {            
      gameOn = true;
      InitialFlip();
    }
    if (gameOn && !waiting && (flipped_cards.Count == 2)){
      waiting = true;
      delaytime = Time.time;
    }
    CheckCards();
    SearchFlippedCards();
  }

  string RandomType() {
    int random = Random.Range(0, 4);
    return types[random];
  }


  void SelectRandomCards() {
    GameObject go;
    for (int index = 0; index < 10; index++) {
      int random = Random.Range(1, 13);
      string type = types[Random.Range(0, 3)];
      if (random < 10) {
          go = Resources.Load("Red_PlayingCards_" + type + "0" + random + "_00") as GameObject;
      } else {
          go = Resources.Load("Red_PlayingCards_" + type + random + "_00") as GameObject;
      }
      go.tag = "Card";
      cards.Add(go);
      cards.Add(go);
    }
  }


  void InstantiateCards() {
    Vector3 tablePosition = GameObject.Find("Table").GetComponent<Transform>().position;
    float x = tablePosition.x + 0.3f;
    float y = tablePosition.y + 0.84f;        
    float z = tablePosition.z + 0.2f;
    for (int index_x = 0; index_x < 4; index_x++) {
      x = tablePosition.x + 0.3f;
      for (int index_y = 0; index_y < 5; index_y++) {
        GameObject inst = Instantiate(cards[SelectRandomCard()], new Vector3(x, y, z),  Quaternion.identity);
        // inst.GetComponent<Transform>().Rotate(0, 0, 0);
        inst.AddComponent<Card>();
        inst.AddComponent<BoxCollider>();
        x-= 0.15f;
      }
      z-= 0.10f;
    }
  }

  int SelectRandomCard() {
    if (indexes.Count - 1 != 0) {
      int random = Random.Range(0, (indexes.Count - 1));
      int aux = indexes[random];
      indexes.RemoveAt(random);
      return aux;
    }
    return indexes[0];
  }

  void SearchFlippedCards() {
    foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card")) {
      if (card.GetComponent<Card>().IsFlipped() && !flipped_cards.Contains(card) && card.GetComponent<Card>().IsFound() == false) {
        flipped_cards.Add(card);
      }
    }
  }

  void CheckCards() {
    if (flipped_cards.Count == 2) {
      if (flipped_cards[0].name == flipped_cards[1].name) {                
        flipped_cards[0].GetComponent<Card>().SetFound();
        flipped_cards[1].GetComponent<Card>().SetFound();                
      } else {
        if (Time.time - delaytime >= 2) {
          flipped_cards[0].GetComponent<Card>().Flip(false);
          flipped_cards[1].GetComponent<Card>().Flip(false);
          waiting = false;
        }                
      }
      flipped_cards.Clear();
    }
  }

  void InitialFlip() {        
    foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card")) {
      card.GetComponent<Card>().Flip(false);
    }     
  }
}
