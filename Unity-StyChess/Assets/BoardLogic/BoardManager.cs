using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using UnityEditor;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    public static List<Piece> all_pieces = new List<Piece> ();

    [SerializeField]
    public static List<TileInfo> all_tiles = new List<TileInfo> ();

    public GameObject debug_pieces;
    public GameObject debug_tiles;

    //public InternalBoard int_board;


    // Selection control
    // MoveAtoB(unit -> tile)

    


    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            foreach (Piece piece in all_pieces)
            {
                Vector3 manager_pos = debug_pieces.transform.position;
                Vector3 piece_pos = piece.transform.position;
                float half_height = (manager_pos.y - piece_pos.y) * 0.5f;
                Vector3 offset = Vector3.up * half_height;

                Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
                Handles.DrawBezier(
                    manager_pos,
                    piece_pos,
                    manager_pos - offset,
                    piece_pos + offset,
                    piece.type.piece_colour,
                    EditorGUIUtility.whiteTexture,
                    1.0f);
            }

            foreach (TileInfo tile in all_tiles)
            {
                Vector3 manager_pos = debug_tiles.transform.position;
                Vector3 piece_pos = tile.transform.position;
                float half_height = (manager_pos.y - piece_pos.y) * 0.5f;
                Vector3 offset = Vector3.up * half_height;

                Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
                Handles.DrawBezier(
                    manager_pos,
                    piece_pos,
                    manager_pos - offset,
                    piece_pos + offset,
                    Color.magenta,
                    EditorGUIUtility.whiteTexture,
                    1.0f);
            }
        }
    }
}
