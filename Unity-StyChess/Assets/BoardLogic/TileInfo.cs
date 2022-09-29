using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public Vector2 int_board_coordinates;

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
