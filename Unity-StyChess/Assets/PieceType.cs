using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PieceType : ScriptableObject
{
    /*
     Piece Attributes:
        Colour
            Pawn    - Red
            Rook    - Green
            Knight  - Blue
            Bishop  - Orange
            Queen   - Pink
            King    - Purple

        Model   
        Health (int)
        Damage (int)
        
     */

    

    public Color piece_colour = Color.white;
    public Mesh piece_model;
    public int piece_health = 1;
    public int piece_damage = 1;
    public string piece_type = "empty";
    public bool white = true;

}
