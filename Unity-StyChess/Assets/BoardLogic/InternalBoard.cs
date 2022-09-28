using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    [SerializeField]
    public List<int[]> files = new List<int[]>();

    int[,] _files = new int[8, 8] 
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

    int instantiate_offset = 5;

    private GameObject Create(GameObject _type, int _rank, int _file)
    {
        GameObject _object;

        _object = Instantiate(_type, new Vector3(_rank * instantiate_offset, 0, _file * instantiate_offset), Quaternion.identity);

        if (_type == tile_position)
        {
            _object.transform.parent = this.transform;
            _object.GetComponent<TileInfo>().x = _rank;
            _object.GetComponent<TileInfo>().y = _file;
        }
        else
        {
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
        }

        return s;
    }

    // Takes in an X and Y coordinate
    public void MoveAtoB(Vector2 start, Vector2 target)
    {
        int start_contents;
        int target_contents;

        Vector2 index = new Vector2(0,0);
        foreach (int tile in _files)
        {
            index.x++;
            if (index.x >= 8)
            {
                index.y++;
                index.x = 0;
            }
        }
    }

    private void Start()
    {
        //PopulateList();

        Vector2 index = new Vector2(0, 0);
        foreach (int tile in _files)
        {
            //Create Tile based on rank and file
            Create(tile_position, (int)index.x, (int)index.y);

            // Create Pieces based on rank and file
            CreateBasedOnID(tile, (int)index.x, (int)index.y);

            index.x++;
            if (index.x >= 8)
            {
                index.y++;
                index.x = 0;
            }
        }

        // Test move pawn A2 to A4
        Vector2 origin = new Vector2(0, 1);
        Vector2 target = new Vector2(0, 3);
        //MoveAtoB(origin, target);
    }

    
}
