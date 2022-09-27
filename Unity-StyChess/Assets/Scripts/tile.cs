using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Gameboard my_gameboard;
    public Piece piece;
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;

    [SerializeField]
    PieceMovementAttack piece_movement_attack_controller;
    private void Awake()
    {
        if(this.piece != null)
        {
            if (this.piece.GetComponent<PieceMovementAttack>() != null)
            {
                piece_movement_attack_controller = this.piece.GetComponent<PieceMovementAttack>();
                piece_movement_attack_controller.current_tile = this;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if( x == null || y == null)
        {
            x = 0;
            y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(piece != null)
        {
            piece.transform.position = this.transform.position;
        }
    }
}
