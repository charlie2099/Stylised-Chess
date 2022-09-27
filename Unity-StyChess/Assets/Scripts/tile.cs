using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public gameboard my_gameboard;
    public GameObject unit;
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;

    [SerializeField]
    PieceMovementAttack piece_movement_attack_controller;
    private void Awake()
    {
        if(this.unit != null)
        {
            if (this.unit.GetComponent<PieceMovementAttack>() != null)
            {
                piece_movement_attack_controller = this.unit.GetComponent<PieceMovementAttack>();
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
        if(unit != null)
        {
            unit.transform.position = this.transform.position;
        }
    }
}
