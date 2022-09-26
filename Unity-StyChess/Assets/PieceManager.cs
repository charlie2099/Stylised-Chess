using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class PieceManager : MonoBehaviour
{
    public static List<Piece> all_pieces = new List<Piece>();

    private void OnDrawGizmos()
    {
        foreach(Piece piece in all_pieces)
        {
            Vector3 manager_pos = this.transform.position;
            Vector3 piece_pos = piece.transform.position;
            float half_height = (manager_pos.y - piece_pos.y) * 0.5f;
            Vector3 offset = Vector3.up * half_height;

            Handles.DrawBezier(
                manager_pos,
                piece_pos,
                manager_pos - offset,
                piece_pos + offset,
                piece.type.piece_colour,
                EditorGUIUtility.whiteTexture,
                1.0f);
        }
    }
}
