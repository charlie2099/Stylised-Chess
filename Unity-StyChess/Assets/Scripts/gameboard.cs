using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameboard : MonoBehaviour
{
    [SerializeField]
    List<Tile> gameboard_tiles = new List<Tile>();
    [SerializeField]
    GameObject text_prefab;
    public void create_cordinates()
    {
        for (int i = 0; i < gameboard_tiles.Count; i++)
        {
            Debug.Log(gameboard_tiles.Count);
            var x = gameboard_tiles[i].transform.position.x;
            var y = gameboard_tiles[i].transform.position.y;
            var z = gameboard_tiles[i].transform.position.z;
            GameObject t = Instantiate(text_prefab, new Vector3(x - 3 , y + 5 , z), Quaternion.identity);
            var TEXT = t.GetComponentInChildren<TMP_Text>();
            //var TEXT = t.Find("txt");
            if (TEXT != null)
                TEXT.text = gameboard_tiles[i].x.ToString() + "," + gameboard_tiles[i].y.ToString();
            else
                Debug.Log("Text is null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        create_cordinates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
