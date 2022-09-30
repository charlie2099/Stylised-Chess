using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public event Action<tile> OnTileSelected; 

    public gameboard my_gameboard;
    public Piece piece;
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;

    [SerializeField]
    public PieceSelector piece_selector;
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

            this.piece.my_tile = this;
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
            piece.transform.position = Vector3.Lerp(piece.transform.position, transform.position, 1.0f * Time.deltaTime);
            //piece.transform.position = transform.position;
        }
    }

    public void OnMouseDown()
    {
        this.my_gameboard.selected_tile = this;
        OnTileSelected?.Invoke(this);
        PieceSelector.Instance.selectionIndicator.SetActive(false);
    }
}
