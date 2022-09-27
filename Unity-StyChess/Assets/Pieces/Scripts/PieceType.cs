using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[RequireComponent(typeof(GameObject))]
public class PieceType : ScriptableObject
{
    public bool white = true;
    public GameObject model;
    public Color piece_colour = Color.white;
    public string piece_type = "empty";
    public int piece_health = 1;
    public int piece_damage = 1;

    public PieceType[] promotion_options;
    public PieceType[] weaknesses;
}
