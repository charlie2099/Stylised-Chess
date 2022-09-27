using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject unit;
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;


    // Start is called before the first frame update
    void Start()
    {
        if( x == null || y == null)
        {
            x = 0;
            y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
