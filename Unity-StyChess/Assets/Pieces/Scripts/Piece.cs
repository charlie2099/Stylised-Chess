using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour

{
    public PieceType type;
    public GameObject model;
    public Color col;
    public int piece_health;
    public int piece_damage;

    static readonly int shPropColour = Shader.PropertyToID("_Color");

    public enum Promotion
    {
        queen,
        rook,
        bishop,
        knight

    };

    private void Start()
    {
        AssumeTypeAttributes();
    }

    private void FixedUpdate()
    {
        UpdateHealthBars();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.type.piece_type == "Pawn")
            {
                //Promote(Promotion.bishop);
                //TakeDamage(1);
            }
        }
    }

    private void OnEnable()
    {
        
    }

    private void AssumeTypeAttributes()
    {
        piece_health = this.type.piece_health;
        piece_damage = this.type.piece_damage;
        col = type.piece_colour;
        UpdateModel();
    }

    private void UpdateModel()
    {
        model = this.type.model;
        Instantiate(model, this.transform);
    }

    private void UpdateHealthBars()
    {
        if (this.GetComponentInChildren<Canvas>() != null &&
                this.GetComponentInChildren<Canvas>().GetComponentInChildren<Renderer>().material != null)
        {
            this.GetComponentInChildren<Canvas>().
                GetComponentInChildren<Renderer>().
                material.SetFloat("_Health", (float)piece_health / (float)type.piece_health);
        }
        if (IsDead()) 
        { 
            Destroy(this.gameObject);
        }
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
        return this.piece_health <= 0;
    }

    public void Promote(Promotion _p)
    {
        this.GetComponentInChildren<ModelColour>().DeleteMe();

        if (this.type.piece_type == "Pawn")
        {
            if (this.type.promotion_options != null)
            {
                switch (_p)
                {
                    case Promotion.queen:
                        this.type = type.promotion_options[0];
                        AssumeTypeAttributes();
                        break;
                    case Promotion.rook:
                        this.type = type.promotion_options[1];
                        AssumeTypeAttributes();
                        break;
                    case Promotion.bishop:
                        this.type = type.promotion_options[2];
                        AssumeTypeAttributes();
                        break;
                    case Promotion.knight:
                        this.type = type.promotion_options[3];
                        AssumeTypeAttributes();
                        break;

                    default:
                        this.type = type.promotion_options[0];
                        AssumeTypeAttributes();
                        break;
                }

            }
        }
        else
        {
            Debug.Log("You're trying to promote a " + this.type.piece_type + "???");
        }
        
    }

}
