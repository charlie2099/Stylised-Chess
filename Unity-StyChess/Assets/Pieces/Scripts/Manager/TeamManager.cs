using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public bool team_white = true;
    public List<Piece> team_pieces = new List<Piece>();
    public PieceSelector ps;

    private void Start()
    {
        GetPieces();
    }

    private void FixedUpdate()
    {
        DebugSelected();
        TestFunction();
    }

    private void TestFunction()
    {
        // if last selected on my team and selected on enemy team
        // apply damage from last selected to selected
        // clear selected

        if (ps.GetSelectedObject().GetComponent<Piece>() != null &&
            ps.GetLastSelectedObject().GetComponent<Piece>() != null)
        {
            // We can evaluate whether to apply damage or not
            if (ps.GetLastSelectedObject().GetComponent<Piece>().type.white == team_white &&
                ps.GetSelectedObject().GetComponent<Piece>().type.white != team_white)
            {
                // Different teams selected
                GetComponentInParent<CombatManager>().AfightsB(
                    ps.GetLastSelectedObject().GetComponent<Piece>(), 
                    ps.GetSelectedObject().GetComponent<Piece>());

                ps.ClearSelected();
            }
        }
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

    private void DebugSelected()
    {
        string str = "A";
        if (team_white) { str = "White"; }
        if (!team_white) { str = "Black"; }

        if (ps.GetSelectedObject().GetComponent<Piece>() != null)
        {
            foreach (Piece _p in team_pieces)
            {
                if (ps.GetSelectedObject().GetComponent<Piece>() == _p)
                {
                    //Debug.Log(str + " " + ps.GetSelectedObject().GetComponent<Piece>().type.piece_type + " selected");
                    Debug.Log(str + " " + _p.type.piece_type + " selected");
                }
            }
        }
        if (ps.GetLastSelectedObject().GetComponent<Piece>() != null)
        {
            foreach (Piece _p in team_pieces)
            {
                if (ps.GetLastSelectedObject().GetComponent<Piece>() == _p)
                {
                    //Debug.Log(str + " " + ps.GetSelectedObject().GetComponent<Piece>().type.piece_type + " last selected");
                    Debug.Log(str + " " + _p.type.piece_type + " last selected");
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
