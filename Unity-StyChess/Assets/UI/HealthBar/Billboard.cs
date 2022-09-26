using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        this.transform.LookAt(Camera.main.transform.position, Vector3.down);
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - Camera.main.transform.position);
    }
}
