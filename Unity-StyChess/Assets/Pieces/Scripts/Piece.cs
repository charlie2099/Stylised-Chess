using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public event Action<Piece> OnTakenDamage;
    public event Action<Piece> OnDeath;
    
    public PieceType type;
    public GameObject model;
    public Color col;
    public int piece_health;
    public int piece_damage;
    public tile my_tile;
    static readonly int shPropColour = Shader.PropertyToID("_Color");
    [SerializeField] private Vector2 int_board_coords;
    //private Animator _animator;

    private void Awake()
    {
        //_animator = GetComponentInChildren<Animator>();
    }

    public void UpdatePosition(int _offset)
    {
        this.transform.position = new Vector3(int_board_coords.x * _offset, 0, int_board_coords.y * _offset);
    }

    public void SetCoords(Vector2 _v)
    {
        int_board_coords = _v;
        //Debug.Log(type.piece_type + " " + _v.x + _v.y);
    }

    public Vector2 GetCoords()
    {
        return int_board_coords;
    }

    [Space]
    [Header("Black & White")]
    [SerializeField]
    public bool am_i_white;
    [SerializeField]
    public bool am_i_black;

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
        //Interractable


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.type.piece_type == "Pawn")
            {
                Promote(Promotion.bishop);
                //TakeDamage(1);
            }
        }
    }

    private void OnEnable()
    {
        BoardManager.all_pieces.Add(this);
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
            StartCoroutine(BeginDeathAnimation());
        }
    }

    private IEnumerator BeginDeathAnimation()
    {
        OnDeath?.Invoke(this); // Destroyed before animation can start

        if (GetComponentInChildren<Animator>() != null)
        {
            GetComponentInChildren<Animator>().SetTrigger("death");
        }

        yield return new WaitForSeconds(2.0f);
        
        Destroy(this.gameObject);
    }

    public void TakeDamage(int attack)
    {
        piece_health -= attack;
        //Debug.Log("ATTACK");
        OnTakenDamage?.Invoke(this);
        
        
        GetComponentInChildren<Animator>().SetTrigger("damaged");
        
        
        //PASS TURN


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
    public gameboard my_gameboard;
    void OnMouseDown()
    {
        //Pass information if its their respective turns
        try
        {
            if (my_gameboard.turn_Cycle.white_turn == true && am_i_white)
                this.my_gameboard.selected_piece = this;
            else if (my_gameboard.turn_Cycle.black_turn == true && am_i_black)
                this.my_gameboard.selected_piece = this;
        }
        catch(Exception e)
        {

        }
    }
}

