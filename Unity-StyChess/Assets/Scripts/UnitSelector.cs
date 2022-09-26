using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    public event Action<Unit> OnUnitSelected;

    [SerializeField] private Camera camera;
    
    [Header("Visuals")]
    [SerializeField] private GameObject selectionCrosshair;
    [SerializeField] private Color highlightColour;
    [SerializeField] private Color selectedColour;
    
    private Color _defaultColour = Color.white;

    private void Awake()
    {
        // cache Unit and Renderer components 
    }

    private void Start()
    {
        // GameBoard.Instance.Units
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            var hitRenderer = hitInfo.transform.GetComponent<Renderer>(); // Expensive operation, cache
            //hitRenderer.material.color = highlightColour;
            
            if(Input.GetMouseButtonDown(0) && hitInfo.transform.GetComponent<Unit>() != null) // Expensive
            {
               hitRenderer.material.color = selectedColour;
               selectionCrosshair.transform.position = hitInfo.transform.position + Vector3.down;
            }
            /*else
            {
                hitRenderer.material.color = highlightColour;
            }*/
            //Debug.Log("Selected Object: " + hitInfo.collider.name);
            // Get the Renderer component from the new cube
        }
    }

    // ====NOTES====
    // Fire a raycast from mouse position, check if it hits a unit
    // GameBoard singleton, stores a list of units accessible via callback method?

    // Highlight on hover
    // Active colour
    // Unit select crosshair at base of unit 
}
