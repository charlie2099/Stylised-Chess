using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Piece> all_pieces = new List<Piece>();

    public turn_cycle turn_Cycle;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    AfightsB(all_pieces[0], all_pieces[1]);
        //}
    }

    public void AfightsB(Piece _a, Piece _b)
    {
        //Debug.Log(_b.type.piece_type + " taking " + _a.piece_damage + " damage!");
        if(turn_Cycle.white_turn && _b.am_i_black)
        {
            _b.TakeDamage(_a.piece_damage);
            turn_Cycle.next_turn();
        }
        if (turn_Cycle.black_turn && _b.am_i_white)
        {
            _b.TakeDamage(_a.piece_damage);
            turn_Cycle.next_turn();
        }


    }

    private void OnEnable()
    {
        GetPieces();
    }

    private void GetPieces()
    {
        Piece[] pieces = FindObjectsOfType<Piece>();

        foreach (Piece _piece in pieces)
        {
            all_pieces.Add(_piece);
        }
    }

    private void OnDrawGizmosSelected()
    {

        foreach (Piece _piece in all_pieces)
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
                Color.green,
                EditorGUIUtility.whiteTexture,
                1.0f);
        }
    }




}
