using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Piece : MonoBehaviour

{
    public PieceType type;
    public int piece_health;

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

    private void Update()
    {
        if (Application.isPlaying)
        {
            if (this.GetComponentInChildren<Canvas>() != null &&
            this.GetComponentInChildren<Canvas>().GetComponentInChildren<Renderer>().material != null)
            {
                this.GetComponentInChildren<Canvas>().
                    GetComponentInChildren<Renderer>().
                    material.SetFloat("_Health", (float)piece_health / (float)type.piece_health);
            }
        }
    }

    private void Start()
    {
        piece_health = this.type.piece_health;
        //Debug.Log(
        //    "Unit " + 
        //    this.type.piece_type + 
        //    " health = " + 
        //    piece_health);
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

    public void TakeDamage(int attack)
    {
        this.type.piece_health -= attack;
        if (IsDead())
        {

        }

    }

    public bool IsDead()
    {
        return this.type.piece_health <= 0;
    }


}
