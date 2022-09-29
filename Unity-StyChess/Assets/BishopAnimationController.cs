using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopAnimationController : MonoBehaviour
{
    [SerializeField] private PieceSelector pieceSelector;
    
    private void OnEnable()
    {
        // TODO: Should be checking for tile selected event (when a piece is moved)
        gameboard.Instance.selected_tile.OnTileSelected += PlayAttackAnim;
        //pieceSelector.OnPieceSelected += PlayAttackAnim;
    }

    private void OnDisable()
    {
        gameboard.Instance.selected_tile.OnTileSelected -= PlayAttackAnim;
        //pieceSelector.OnPieceSelected -= PlayAttackAnim;
    }
    
    private void PlayMoveAnim(Piece piece)
    {
        piece.GetComponentInChildren<Animator>().SetTrigger("walk");
    }
    
    private void PlayAttackAnim(tile tile)
    {
        Debug.Log("ATTACK");
        tile.piece.GetComponentInChildren<Animator>().SetTrigger("attack");
    }
    
    private void PlayDamagedAnim(Piece piece)
    {
        piece.GetComponentInChildren<Animator>().SetTrigger("damaged");
    }
    
    private void PlayDeathAnim(Piece piece)
    {
        piece.GetComponentInChildren<Animator>().SetTrigger("death");
    }
}
