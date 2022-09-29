using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAnimationController : MonoBehaviour
{
    [SerializeField] private PieceSelector pieceSelector;
    
    private void OnEnable()
    {
        /*foreach (var tile in gameboard.Instance.gameboard_tiles)
        {
            tile.piece.OnTakenDamage += PlayDamagedAnim;
            tile.piece.OnDeath += PlayDeathAnim;
        }*/
        // TODO: Should be checking for tile selected event (when a piece is moved)
        //gameboard.Instance.selected_tile.OnTileSelected += PlayAttackAnim;
        //pieceSelector.OnPieceSelected += PlayAttackAnim;
    }

    private void OnDisable()
    {
        /*foreach (var tile in gameboard.Instance.gameboard_tiles)
        {
            tile.piece.OnTakenDamage -= PlayDamagedAnim;
            tile.piece.OnDeath -= PlayDeathAnim;
        }*/
        //gameboard.Instance.selected_tile.OnTileSelected -= PlayAttackAnim;
        //pieceSelector.OnPieceSelected -= PlayAttackAnim;
    }
    
    private void PlayMoveAnim(Piece piece)
    {
        piece.GetComponentInChildren<Animator>().SetTrigger("walk");
    }
    
    private void PlayAttackAnim(Piece piece)
    {
        Debug.Log("ATTACK");
        piece.GetComponentInChildren<Animator>().SetTrigger("attack");
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
