using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesControl : MonoBehaviour
{
    public void DeleteSelf()
    {
        this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }
}
