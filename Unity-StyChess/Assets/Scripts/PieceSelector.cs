using System;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    public event Action<Piece> OnPieceSelected;

    [SerializeField] private Camera camera;
    
    [Header("Visuals")]
    [Range(1, 2)] [SerializeField] private float selectorScale = 1.5f;
    [SerializeField] private GameObject selectionIndicator;
    [SerializeField] private Color selectionIndicatorColour;
    [SerializeField] private Color unitHighlightColour;
    
    private GameObject _highlightedObject;
    private GameObject _selectedObject;
    private Color _defaultColour;

    private void Start()
    {
        selectionIndicator.GetComponentInChildren<Renderer>().material.color = selectionIndicatorColour;
        selectionIndicator.transform.localScale = new Vector3(selectorScale, selectorScale, selectorScale);
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.root.gameObject;
            
            if (hitObject.GetComponent<Piece>() != null)
            {
                //HighlightObject(hitObject);

                if (Input.GetMouseButtonDown(0))
                {
                    SelectPiece(hitObject);
                }
            }
        }
        else
        {
            ClearSelection();
        }
    }

    private void SelectPiece(GameObject hitObject)
    {
        MeshFilter mf = hitObject.GetComponent<MeshFilter>();
        Vector3 objSize = mf.sharedMesh.bounds.size;
        Vector3 objScale = hitObject.transform.localScale;
        float objHeight = objSize.y * objScale.y;

        var hitObjectPos = hitObject.transform.position;
        selectionIndicator.transform.position = new Vector3(hitObjectPos.x, hitObjectPos.y - objHeight/2, hitObjectPos.z);

        float diameter = hitObject.GetComponent<Renderer>().bounds.size.x;
        selectionIndicator.transform.localScale = new Vector3(diameter * selectorScale, 1, diameter * selectorScale);

        _selectedObject = hitObject;
        var piece = _selectedObject.GetComponent<Piece>();
        OnPieceSelected?.Invoke(piece);
        //Debug.Log("<color=orange>" + piece + "</color> selected!");
    }

    private void HighlightObject(GameObject hitObject)
    {
        if (_highlightedObject != null)
        {
            if (hitObject == _highlightedObject)
            {
                return;
            }
            // Clear previous selection
            ClearSelection();
        }
        
        _highlightedObject = hitObject;
        _highlightedObject.GetComponent<Renderer>().material.color = unitHighlightColour;
    }

    private void ClearSelection()
    {
        if (_highlightedObject != null)
        {
            _highlightedObject.GetComponent<Renderer>().material.color = Color.white;
        }
        _highlightedObject = null;
    }
}
