using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class ModelColour : MonoBehaviour
{
    static readonly int shPropColour = Shader.PropertyToID("_Color");

    // Hardcoded colour
    private Color col = Color.magenta;

    MaterialPropertyBlock mpb;

    MaterialPropertyBlock MPB
    {
        get
        {
            if (mpb == null)
            {
                mpb = new MaterialPropertyBlock(); 
            }

            return mpb;
        }
    }

    private void Start()
    {
        ApplyProperties();
    }

    private void ApplyProperties()
    {
        col = this.GetComponentInParent<Piece>().col;
        MeshRenderer[] rnds = this.GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer _rnd in rnds)
        {
            //Debug.Log("This is happening");
            MPB.SetColor(shPropColour, col);
            _rnd.SetPropertyBlock(MPB);
        }


    }

    public void DeleteMe()
    {
        Destroy(this.gameObject);
    }
}
