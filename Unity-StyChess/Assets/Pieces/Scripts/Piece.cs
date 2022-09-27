using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour

{
    public PieceType type;
    public int piece_health = 0;
    public GameObject model;
    public Color col;

    static readonly int shPropColour = Shader.PropertyToID("_Color");

    //MaterialPropertyBlock mpb;

    //MaterialPropertyBlock MPB
    //{
    //    get
    //    {
    //        if (mpb == null)
    //        {
    //            mpb = new MaterialPropertyBlock();
    //        }
    //        return mpb;
    //    }
    //}

    private void Update()
    {
        if (Application.isPlaying)
        {
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    TakeDamage(1);
            //}

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
        //ApplyProperties();
        piece_health = this.type.piece_health;
        col = type.piece_colour;
        
        //Debug.Log(
        //    "Unit " +
        //    this.type.piece_type +
        //    " health = " +
        //    piece_health);
    }

    private void OnValidate()
    {
        //ApplyProperties();
    }

    private void OnEnable()
    {       
        PieceManager.all_pieces.Add(this);
        UpdateModel();
        Instantiate(model, this.transform);
    }

    private void OnDisable()
    {
        PieceManager.all_pieces.Remove(this);
    }

    //public void ApplyProperties()
    //{
    //    MeshRenderer rnd = this.GetComponentInChildren<MeshRenderer>();
    //    MPB.SetColor(shPropColour, type.piece_colour);
    //    rnd.SetPropertyBlock(MPB);
    //}

    private void UpdateModel()
    {
        model = this.type.model;
    }

    public void TakeDamage(int attack)
    {
        piece_health -= attack;
        if (IsDead())
        {

        }

    }

    public bool IsDead()
    {
        return this.type.piece_health <= 0;
    }


}