using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class turn_cycle : MonoBehaviour
{
    public TMP_Text TURN_COUNTER;
    public TMP_Text TO_MOVE;
    
    public bool white_turn;
    public bool black_turn;
    // Start is called before the first frame update
    void Start()
    {
        white_turn = true;
    }

    public void white_plays_their_turn()
    {
        white_turn = false;
        black_turn = true;
    }
    public void black_plays_their_turn()
    {
        white_turn = true;
        black_turn = false;
    }

}
