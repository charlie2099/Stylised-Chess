using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gameboard : MonoBehaviour
{
    public static Gameboard Instance;
    
    [SerializeField] List<Tile> gameboard_tiles = new List<Tile>();
    [SerializeField] GameObject text_prefab;

    public List<Tile> Tiles => gameboard_tiles;
    public Dictionary<Piece, Tile> _piecesDict = new Dictionary<Piece, Tile>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of the GameBoard in the scene!");
        }
    }

    void Start()
    {
        CreateCoordinates();

        foreach (var tile in gameboard_tiles)
        {
            if (tile.piece != null)
            {
                _piecesDict.Add(tile.piece, tile);
            }
        }
        
        //Debug.Log("Tile: " + gameboard_tiles[7], gameboard_tiles[7]);
    }
    
    public void CreateCoordinates()
    {
        for (int i = 0; i < gameboard_tiles.Count; i++)
        {
            Debug.Log(gameboard_tiles.Count);
            var x = gameboard_tiles[i].transform.position.x;
            var y = gameboard_tiles[i].transform.position.y;
            var z = gameboard_tiles[i].transform.position.z;
            GameObject t = Instantiate(text_prefab, new Vector3(x - 3 , y + 5 , z), Quaternion.identity);
            var TEXT = t.GetComponentInChildren<TMP_Text>();
            //var TEXT = t.Find("txt");
            if (TEXT != null)
                TEXT.text = gameboard_tiles[i].x.ToString() + "," + gameboard_tiles[i].y.ToString();
            else
                Debug.Log("Text is null");
        }
    }
}
