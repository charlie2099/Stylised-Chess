using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class turn_cycle : MonoBehaviour
{
    public TMP_Text TURN_COUNTER;
    public TMP_Text TO_MOVE;
    public int turn_counter_int;

    public Camera main_camera;
    public GameObject blackCoordinates;
    public GameObject whiteCoordinates;
    // Start is called before the first frame update
    void Start()
    {
        white_turn = true;
    }
    private void Update()
    {
        turn_counter_int_equals_text();
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

    [Space]
    [SerializeField]
    public List<GameObject> black_pieces = new List<GameObject>();
    [SerializeField]
    public List<GameObject> white_piece = new List<GameObject>();

    public bool white_turn;
    public bool black_turn;

    public void Awake()
    {
        white_turn = true;
        black_turn = false;
        turn_counter_int = 1;
        this.main_camera.transform.position = this.whiteCoordinates.transform.position;
    }
    public void next_turn()
    {
        if(white_turn == true)
        {
            //its now black's turn
            StartCoroutine(change_camera_location_to_black());
            white_turn = false;
            black_turn = false;

        }
        else if(black_turn == true)
        {
            // its now white's turn
            white_turn = false;
            black_turn = false;
            StartCoroutine(Change_camera_location_to_white());




        }
    }
    IEnumerator change_camera_location_to_black()
    {

        yield return new WaitForSeconds(2f);
        this.main_camera.transform.position = this.blackCoordinates.transform.position;
        TO_MOVE.text = "Black To Move";
        turn_counter_int++;
        white_turn = false;
        black_turn = true;
    }
    IEnumerator Change_camera_location_to_white()
    {
        yield return new WaitForSeconds(2f);
        this.main_camera.transform.position = this.whiteCoordinates.transform.position;
        TO_MOVE.text = "White To Move";
        white_turn = true;
        black_turn = false;
        turn_counter_int++;
    }


    public void turn_counter_int_equals_text()
    {
        TURN_COUNTER.text = "Turn : " + turn_counter_int.ToString();
    }
}
