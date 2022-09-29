using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InternalBoard : MonoBehaviour
{
    /*
     x = rank, y = file
     0 Empty

     1 wPawn        7 bPawn
     2 wRook        8 bRook
     3 wKnight      9 bKnight
     4 wBishop      10 bBishop
     5 wQueen       11 bQueen
     6 wKing        12 bKing
     
     */

    private enum TileDataType
    { 
        empty = 0, 
        wPawn = 1, wRook = 2, wKnight = 3, wBishop =  4, wQueen =  5, wKing =  6,
        bPawn = 7, bRook = 8, bKnight = 9, bBishop = 10, bQueen = 11, bKing = 12
    };


    #region GameObjects
    public GameObject tile_position;
    public GameObject piece_control;

    public GameObject wPawn;
    public GameObject wRook;
    public GameObject wKnight;
    public GameObject wBishop;
    public GameObject wQueen;
    public GameObject wKing;

    public GameObject bPawn;
    public GameObject bRook;
    public GameObject bKnight;
    public GameObject bBishop;
    public GameObject bQueen;
    public GameObject bKing;
    #endregion

    int[,] board_data = new int[8, 8]
          {
            { 02, 03, 04, 05, 06, 04, 03, 02 },
            { 01, 01, 01, 01, 01, 01, 01, 01 },
            { 00, 00, 00, 00, 00, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 00, 00 },
            { 00, 00, 00, 00, 00, 00, 00, 00 },
            { 07, 07, 07, 07, 07, 07, 07, 07 },
            { 08, 09, 10, 12, 11, 10, 09, 08 }
          };

    int instantiate_offset = 5;

    private List<GameObject> all_pieces = new List<GameObject>();
    [SerializeField] private List<GameObject> w_pieces = new List<GameObject>();
    [SerializeField] private List<GameObject> b_pieces = new List<GameObject>();

    private GameObject FindPiecesAtCoords(Vector2 _v)
    {
        foreach (GameObject _g in w_pieces)
        {
            if (_g.GetComponent<Piece>().GetCoords() == _v)
            {
                //Debug.Log("We've got a winner!");
                return _g;
            }
        }
        foreach (GameObject _g in b_pieces)
        {
            if (_g.GetComponent<Piece>().GetCoords() == _v)
            {
                //Debug.Log("We've got a winner!");
                return _g;
            }
        }

        return this.gameObject;
    }

    private void UpdatePiecePositions()
    {
        foreach (GameObject _g in w_pieces)
        {
            //_g.GetComponent<Piece>().SetCoords(new Vector2(3, 3));
            _g.GetComponent<Piece>().UpdatePosition(instantiate_offset);
        }
        foreach (GameObject _g in b_pieces)
        {
            _g.GetComponent<Piece>().UpdatePosition(instantiate_offset);
        }
    }

    private void SortPieces()
    {
        foreach (GameObject _g in all_pieces)
        {
            if (_g.GetComponent<Piece>().type.white) { w_pieces.Add(_g); }
            else { b_pieces.Add(_g); }
        }

        all_pieces.Clear();
    }

    private GameObject Create(GameObject _type, int _rank, int _file)
    {
        GameObject _object;

        _object = Instantiate(_type, new Vector3(_rank * instantiate_offset, 0, _file * instantiate_offset), Quaternion.identity);

        if (_type == tile_position)
        {
            _object.transform.parent = this.transform;
            _object.GetComponent<TileInfo>().SetCoords(new Vector2(_rank, _file));
        }
        else
        {
            all_pieces.Add(_object);
            _object.GetComponent<Piece>().SetCoords(new Vector2(_rank, _file));
            _object.transform.parent = piece_control.transform;
        }

        return _object;
    }

    private void CreateBasedOnID(int _id, int _rank, int _file)
    {
        switch (_id)
        {
            case 0:
                break;
            case 1:
                Create(wPawn, _rank, _file);
                break;
            case 2:
                Create(wRook, _rank, _file);
                break;
            case 3:
                Create(wKnight, _rank, _file);
                break;
            case 4:
                Create(wBishop, _rank, _file);
                break;
            case 5:
                Create(wQueen, _rank, _file);
                break;
            case 6:
                Create(wKing, _rank, _file);
                break;
            case 7:
                Create(bPawn, _rank, _file);
                break;
            case 8:
                Create(bRook, _rank, _file);
                break;
            case 9:
                Create(bKnight, _rank, _file);
                break;
            case 10:
                Create(bBishop, _rank, _file);
                break;
            case 11:
                Create(bQueen, _rank, _file);
                break;
            case 12:
                Create(bKing, _rank, _file);
                break;
        }
    }

    private String WhatPiece(int _i)
    {
        string s = "@";

        switch (_i)
        {
            case 0:
                s = "EMPTY";
                break;
            case 1:
                s = "wPawn";
                break;
            case 2:
                s = "wRook";
                break;
            case 3:
                s = "wKnight";
                break;
            case 4:
                s = "wBishop";
                break;
            case 5:
                s = "wQueen";
                break;
            case 6:
                s = "wKing";
                break;
            case 7:
                s = "bPawn";
                break;
            case 8:
                s = "bRook";
                break;
            case 9:
                s = "bKnight";
                break;
            case 10:
                s = "bBishop";
                break;
            case 11:
                s = "bQueen";
                break;
            case 12:
                s = "bKing";
                break;
            default:
                s = "That's not a piece, my guy";
                break;
        }

        return s;
    }

    // Need to point selected unit and selected tile to this
    // POWERFUL. HAS ABSOLUTE AUTHORITY TO MOVE A UNIT
    public void MoveAtoB(Vector2 _start, Vector2 _target)
    {
        int start_contents;
        int target_contents;

        start_contents = board_data[(int)_start.y, (int)_start.x];
        target_contents = board_data[(int)_target.y, (int)_target.x];

        //Debug.Log(WhatPiece(start_contents));
        //Debug.Log(WhatPiece(target_contents));

        // If start tile is not empty & target tile is unoccupied
        if (start_contents != 0 && target_contents == 0)
        {
            if (_start != _target)
            {
                // Find piece with matching coords
                // Set coords to target position
                FindPiecesAtCoords(_start).GetComponent<Piece>().SetCoords(_target);
                board_data[(int)_start.y, (int)_start.x] = 0; // clear start pos as tile is now empty
                board_data[(int)_target.y, (int)_target.x] = start_contents; // move start piece to target pos
                // clear start pos
                UpdatePiecePositions();

                // End turn
            }
            else
            {
                Debug.Log("You are trying to move contents of a tile to itself");
                // Don't end turn
            }
        }
        else
        {
            if (target_contents != 0) { Debug.Log("You are trying to move to an occupied tile"); }
            if (start_contents == 0) { Debug.Log("You are trying to move an empty tile"); }
            // Don't end turn
        }

    }

    

    private void Start()
    {
        Vector2 index = new Vector2(0, 0);
        foreach (int tile_contents in board_data)
        {
            //Create Tile based on rank and file
            Create(tile_position, (int)index.x, (int)index.y);

            // Create Pieces based on rank and file
            CreateBasedOnID(tile_contents, (int)index.x, (int)index.y);

            index.x++;
            if (index.x >= 8)
            {
                index.y++;
                index.x = 0;
            }
        }

        SortPieces();
        UpdatePiecePositions();        
    }

    private void Update()
    {
        // Test move pawn A2 to A4
        Vector2 origin = new Vector2(1, 0); // from
        Vector2 target = new Vector2(2, 2); // to
        if (Input.GetKeyDown(KeyCode.W)) { MoveAtoB(origin, target); }
    }

    private void OnDrawGizmos()
    {
        Vector2 index = new Vector2(0, 0);
        foreach (int _tile in board_data)
        {
            string piece = _tile.ToString();
            Handles.Label(new Vector3(index.x * instantiate_offset - 50, 1, index.y * instantiate_offset), piece);

            index.x++;
            if (index.x >= 8)
            {
                index.y++;
                index.x = 0;
            }
        }
    }
}