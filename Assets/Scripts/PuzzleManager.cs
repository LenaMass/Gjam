using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour {
  [SerializeField] private Transform gameTransform;
  [SerializeField] private Transform piecePrefab;
  private CameraSwitch cameraSwitchScript;
  [SerializeField] private GameObject Cam;
  [SerializeField] private GameObject PuzzleBoard;
  public SoundManager sm;

  [SerializeField] private Image HintImage;
  [SerializeField] private TextMeshProUGUI HintText;





  private List<Transform> pieces;
  private int emptyLocation;
  private int size;
  private bool shuffling = false;

  // Create the game setup with size x size pieces.
  private void CreateGamePieces(float gapThickness) {
    // This is the width of each tile.
    float width = 1 / (float)size;
    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        pieces.Add(piece);
        // Pieces will be in a game board going from -1 to +1.
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                          +1 - (2 * width * row) - width,
                                          0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        // We want an empty space in the bottom right.
        if ((row == size - 1) && (col == size - 1)) {
          emptyLocation = (size * size) - 1;
          piece.gameObject.SetActive(false);
        } else {
          // We want to map the UV coordinates appropriately, they are 0->1.
          float gap = gapThickness / 2;
          Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
          Vector2[] uv = new Vector2[4];
          // UV coord order: (0, 1), (1, 1), (0, 0), (1, 0)
          uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
          uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
          uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
          uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
          // Assign our new UVs to the mesh.
          mesh.uv = uv;
        }
      }
    }
  } 
  private void Start()
  {
    cameraSwitchScript = Cam.GetComponent<CameraSwitch>();
  }
 

  private void StartPuzzle() {
    cameraSwitchScript.CamSwitch();
    pieces = new List<Transform>();
    size = 3;
    CreateGamePieces(0.01f);

    // Check for completion.
    if (!shuffling) {
      shuffling = true;
      StartCoroutine(WaitShuffle(0.5f));
    }
  }

  // Update is called once per frame
  private void OnTriggerEnter(Collider other)
  {  
    if (other.gameObject.CompareTag("Player"))
    {
      HintImage.enabled = true;
      HintText.enabled = true;
      
      //StartPuzzle();
    }

  }

  private void OnTriggerExit(Collider other)
  {
      if(other.CompareTag("Player"))
      {
        HintImage.enabled = false;
        HintText.enabled = false;
            
      }
  }

  void Update()
  {


    if(HintImage.enabled)
      {
        if(Input.GetKeyDown(KeyCode.E))
          {
            HintImage.enabled = false;
            HintText.enabled = false;
            StartPuzzle();

          }
          
          
      }

      // On click send out ray to see if we click a piece.
      if (Input.GetMouseButtonDown(0)) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit && (!CheckCompletion())) {
          // Go through the list, the index tells us the position.
          for (int i = 0; i < pieces.Count; i++) {
            if (pieces[i] == hit.transform) {
              // Check each direction to see if valid move.
              // We break out on success so we don't carry on and swap back again.
              if (SwapIfValid(i, -size, size)) { break; }
              if (SwapIfValid(i, +size, size)) { break; }
              if (SwapIfValid(i, -1, 0)) { break; }
              if (SwapIfValid(i, +1, size - 1)) { break; }
            }
          }
        }
        else if(CheckCompletion())
        {
          sm.PlaySolvePuzzle();
          Destroy(PuzzleBoard, 1f);
          StartCoroutine(endPuzzle(1.2f));
          
        }
          
      }
  }

  // colCheck is used to stop horizontal moves wrapping.
  private bool SwapIfValid(int i, int offset, int colCheck) {
    if (((i % size) != colCheck) && ((i + offset) == emptyLocation)) {
      // Swap them in game state.
      (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
      // Swap their transforms.
      (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
      // Update empty location.
      emptyLocation = i;
      return true;
    }
    return false;
  }

  // We name the pieces in order so we can use this to check completion.
  private bool CheckCompletion() {
    for (int i = 0; i < pieces.Count; i++) {
      if (pieces[i].name != $"{i}") {
        return false;
      }
    }
    return true;
  }

  private IEnumerator WaitShuffle(float duration) {
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
  }

  // Brute force shuffling.
  private void Shuffle() {
    int count = 0;
    int last = 0;
    while (count < (size * size * size)) {
      // Pick a random location.
      int rnd = Random.Range(0, size * size);
      // Only thing we forbid is undoing the last move.
      if (rnd == last) { continue; }
      last = emptyLocation;
      // Try surrounding spaces looking for valid move.
      if (SwapIfValid(rnd, -size, size)) {
        count++;
      } else if (SwapIfValid(rnd, +size, size)) {
        count++;
      } else if (SwapIfValid(rnd, -1, 0)) {
        count++;
      } else if (SwapIfValid(rnd, +1, size - 1)) {
        count++;
      }
    }
  }


IEnumerator endPuzzle(float delayTime)
{
   //Wait for the specified delay time before continuing.
   yield return new WaitForSeconds(delayTime);
   cameraSwitchScript.RevertCam();
 
   //Do the action after the delay time has finished.
}

 



}
