using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameboard : MonoBehaviour
{
    public static gameboard Instance;
    
    public List<tile> gameboard_tiles = new List<tile>();
    [SerializeField] GameObject text_prefab;

    public List<tile> Tiles => gameboard_tiles;
    public Dictionary<Piece, tile> _piecesDict = new Dictionary<Piece, tile>();

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
        //CreateCoordinates();

        foreach (var tile in gameboard_tiles)
        {
            if (tile.piece != null)
            {
                _piecesDict.Add(tile.piece, tile);
            }
        }

        //Debug.Log("Tile: " + gameboard_tiles[7], gameboard_tiles[7]);


        //Coordinates Button
        coordinate_button.onClick.AddListener(CreateCoordinates);
    }
    public Button coordinate_button;
    bool is_cordinates_open = false;
    private List<GameObject> cordinate_prefabs = new List<GameObject>();
    public void CreateCoordinates()
    {

        if (is_cordinates_open == false)
        {
            is_cordinates_open = true;
            for (int i = 0; i < gameboard_tiles.Count; i++)
            {
                //Debug.Log(gameboard_tiles.Count);
                var x = gameboard_tiles[i].transform.position.x;
                var y = gameboard_tiles[i].transform.position.y;
                var z = gameboard_tiles[i].transform.position.z;
                GameObject t = Instantiate(text_prefab, new Vector3(x - 3, y + 5, z), Quaternion.identity);
                cordinate_prefabs.Add(t);


                var TEXT = t.GetComponentInChildren<TMP_Text>();
                //var TEXT = t.Find("txt");
                if (TEXT != null)
                    TEXT.text = gameboard_tiles[i].x.ToString() + "," + gameboard_tiles[i].y.ToString();
                //else
                //Debug.Log("Text is null");
            }
        }
        else if (is_cordinates_open == true)
        {
            //cordinate_prefabs.Clear();

            // need to be able to toggle coords off
                        
            is_cordinates_open = false;
        }

    }

    public Piece selected_piece;
    public tile selected_tile;

    public void move_piece()
    {
        if(selected_piece != null && selected_tile != null)
        {
            if (selected_tile.piece == null)
            {
                selected_tile.piece = selected_piece;
                selected_piece.my_tile.piece = null;
                selected_piece.my_tile = selected_tile;

                //FIX MOVEMENT BUGS
                //PASS TURN


            }
        }
    }

    public void Update()
    {
        move_piece();
    }
}
