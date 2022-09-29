using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovementAttack : MonoBehaviour
{
    public bool am_i_white;
    /*

    0 -> pawn
        white
            +y1 // move forward
            +y1, +x1 // Take diag right
                cannot make this move if on x 7 ( right edge of board)
            +y1, -x1 // Take diag left
                cannot make this move if on x 0 ( left edge of board)
            
        black
            -y1 // move forward
            -y1, -x1 // Take diag right
                cannot make this move if on x 7 ( right edge of board)
            -y1, +x1 // Take diag left
                cannot make this move if on x 0 ( left edge of board)
    
    1 -> knight
    White knight & Black knight
        +y3, +x1 // big Up + right
        +y3, -x1 // big Up + left
        +y1, +x3 // Up + big right
        +y1, -x3 // up + big left
        -y3, -x1 // down + big left
        -y3, +x1 // big down + right
        -y1, -x3 // down + big left
        -y1, +x3 // down + big right
        
    2 -> bishop
        +yn, +xn // diag up + right
        +yn, -xn // diag up + left
        -yn, +xn // diag down + right
        -yn, -xn // diag down + left

    3 -> castle
        +yn // move up
        -yn // move down
        +xn // move right
        -xn // move left

    4 -> queen
        +yn, +xn // diag up + right
        +yn, -xn // diag up + left
        -yn, +xn // diag down + right
        -yn, -xn // diag down + left
        +yn // move up
        -yn // move down
        +xn // move right
        -xn // move left

    5 -> king
        +y1, +x1 // diag up + right
        +y1, -x1 // diag up + left
        -y1, +x1 // diag down + right
        -y1, -x1 // diag down + left
        +y1 // move up
        -y1 // move down
        +x1 // move right
        -x1 // move left

    */
    public int my_type;
    public tile current_tile;
    public int my_cordinate_x;
    public int my_cordinate_y;
    public List<List<int>> all_cordinates = new List<List<int>>();

    /*public void where_can_i_attack_or_move()
    {
        all_cordinates.Clear();
        if (this.my_type == 0)
        {

            //PAWN POSIBBLE LOCATIONS TO ATTACK/MOVE
            List<int> row1 = new List<int>();
            row1.Add(this.my_cordinate_x + 1);
            row1.Add(this.my_cordinate_y + 1);

            List<int> row2 = new List<int>();
            row2.Add(this.my_cordinate_x + 1);
            row2.Add(this.my_cordinate_y - 1);

            List<int> row3 = new List<int>();
            row3.Add(this.my_cordinate_x + 1);
            row3.Add(this.my_cordinate_y);


            all_cordinates.Add(row1);
            all_cordinates.Add(row2);
            all_cordinates.Add(row3);

        }
    }*/

    /*public void show_possible_tiles()
    {
        Debug.Log("Showing Posibble Tiles");
        if(current_tile != null)
        {
            //Checks all tiles
            for (int i = 0; i < current_tile.my_gameboard.gameboard_tiles.Count; i++)
            {

                if(current_tile.my_gameboard.gameboard_tiles[i] != null)
                {
                    //Checks which tiles are avaliable for given cordinates
                    for (int e = 0; e < all_cordinates.Count; e++){

                        if(current_tile.my_gameboard.gameboard_tiles[i].x == all_cordinates[e][0] && current_tile.my_gameboard.gameboard_tiles[i].y == all_cordinates[e][1])
                        {
                            //Change its colour to green
                            current_tile.my_gameboard.gameboard_tiles[i].GetComponent<Renderer>().material.color = Color.green;
                        }

                    }
        
                }
            }
        }

    }*/

    public void OnMouseDown()
    {
   /*     show_possible_tiles();*/
    }

    void update_cordinates()
    {
        if (current_tile != null)
        {
            my_cordinate_x = current_tile.x;
            my_cordinate_y = current_tile.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        update_cordinates();
    }

    // Update is called once per frame
    void Update()
    {
        update_cordinates();
    }
}
