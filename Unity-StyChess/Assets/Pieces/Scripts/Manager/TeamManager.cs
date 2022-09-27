using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public bool team_white = true;
    public List<Piece> team_pieces = new List<Piece>();

    private void OnEnable()
    {
        GetPieces();
    }

    private void GetPieces()
    {
        Piece[] pieces = FindObjectsOfType<Piece>();

        if (team_pieces != null)
        {
            foreach (Piece _piece in pieces)
            {
                if (team_white)
                {
                    // If team_black
                    if (_piece.type.white)
                    {
                        team_pieces.Add(_piece);
                    }
                }
                else if (!team_white)
                {
                    // If team black
                    if (!_piece.type.white)
                    {
                        team_pieces.Add(_piece);
                    }
                }
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Color team_colour = Color.white;

        if(!team_white) { team_colour = Color.black; }


        foreach(Piece _piece in team_pieces)
        {
            Vector3 manager_pos = this.transform.position;
            Vector3 piece_pos = _piece.transform.position;
            float half_height = (manager_pos.y - piece_pos.y) * 0.5f;
            Vector3 offset = Vector3.up * half_height;

            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            Handles.DrawBezier(
                manager_pos,
                piece_pos,
                manager_pos - offset,
                piece_pos + offset,
                team_colour,
                EditorGUIUtility.whiteTexture,
                1.0f);
        }
    }
}
