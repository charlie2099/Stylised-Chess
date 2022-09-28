using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int x;
    public int y;

    private void OnDrawGizmos()
    {
        string _x = x.ToString();
        string _y = y.ToString();

        // Draw debug values
        Handles.Label(this.transform.position + new Vector3(-0.25f, 1, 0), _x);
        Handles.Label(this.transform.position + new Vector3(0.25f, 1, 0), _y);
    }
}
