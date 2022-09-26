using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Piece : MonoBehaviour

{
    public PieceType type;

    static readonly int shPropColour = Shader.PropertyToID("_Color");

    MaterialPropertyBlock mpb;

    MaterialPropertyBlock MPB
    {
        get 
        { 
            if (mpb == null)
            {
                mpb = new MaterialPropertyBlock(); 
            }
            return mpb; 
        }
    }

    private void OnValidate()
    {
        ApplyProperties();
    }

    private void OnEnable()
    {
        ApplyProperties();
        PieceManager.all_pieces.Add(this);
    }

    private void OnDisable()
    {
        PieceManager.all_pieces.Remove(this);
    }

    public void ApplyProperties()
    {
        MeshRenderer rnd = GetComponent<MeshRenderer>();
        MPB.SetColor(shPropColour, type.piece_colour);
        rnd.SetPropertyBlock(MPB);
    }


}
