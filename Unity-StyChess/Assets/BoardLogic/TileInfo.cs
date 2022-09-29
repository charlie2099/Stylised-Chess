using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public Vector2 int_board_coordinates;

    [SerializeField]
    public PieceSelector tile_piece_selector;

    private void OnMouseDown()
    {
        if(tile_piece_selector._selectedTile == null)
        {
            Debug.Log("Giving my info to the selector");
            this.tile_piece_selector._selectedTile = this;
            
        }
    }
    private void OnEnable()
    {
        BoardManager.all_tiles.Add(this);
    }

    public void SetCoords(Vector2 _v)
    {
        int_board_coordinates = _v;
    }

    public Vector2 GetCoords()
    {
        return int_board_coordinates;
    }

    private void OnDrawGizmos()
    {
        string _x = int_board_coordinates.x.ToString();
        string _y = int_board_coordinates.y.ToString();

        // Draw debug values
        Handles.Label(this.transform.position + new Vector3(-0.25f, 1, 0), _x);
        Handles.Label(this.transform.position + new Vector3(0.25f, 1, 0), _y);
    }
}
