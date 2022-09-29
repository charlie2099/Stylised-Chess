using System;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    public event Action<Piece, tile> OnPieceSelected;

    [SerializeField] private Camera camera;
    
    [Header("Visuals")]
    [Range(1, 5)] [SerializeField] private float selectorScale = 1.5f;
    [SerializeField] private GameObject selectionIndicator;
    [SerializeField] private Color selectionIndicatorColour;
    [SerializeField] private Color unitHighlightColour;
    [SerializeField] private bool scaleIndicatorWithPiece;
    
    private GameObject _highlightedObject;
    private GameObject _selectedObject;
    private GameObject _lastSelectedObject;
    private Color _defaultColour;



    public void ClearSelected()
    {
        _selectedObject = null;
        _lastSelectedObject = null;
    }

    public GameObject GetSelectedObject()
    {
        if (_selectedObject != null)
        {
            return _selectedObject;
        }
        // return garbage if _selectedObject null
        GameObject go = new GameObject();
        return go;
    }

    public GameObject GetLastSelectedObject()
    {
        if (_lastSelectedObject != null)
        {
            return _lastSelectedObject;
        }
        // return garbage if _selectedObject null
        GameObject go = new GameObject();
        return go;
    }

    private void Start()
    {
        selectionIndicator.GetComponentInChildren<Renderer>().material.color = selectionIndicatorColour;
        selectionIndicator.transform.localScale = new Vector3(selectorScale, selectorScale, selectorScale);
    }

    private void Update()
    {
/*        //Debug
        Debug.Log("Selected Object"+ _selectedObject.ToString());
        Debug.Log("Last Selected Object" + _lastSelectedObject.ToString());*/

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            
            if (hitObject.GetComponent<Piece>() != null)
            {
                //HighlightObject(hitObject);
                if (Input.GetMouseButtonDown(0))
                {
                    try
                    {
                        SelectPiece(hitObject);
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                    }

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
        Debug.Log("Selected Object" + _selectedObject.ToString());
        Debug.Log("Last Selected Object" + _lastSelectedObject.ToString());


        ConfigureIndicatorPosAndScale(hitObject);

        if (_selectedObject != null)
        {
            _lastSelectedObject = _selectedObject;
        }
        _selectedObject = hitObject;
        
        var piece = _selectedObject.GetComponent<Piece>();
        var tile = gameboard.Instance._piecesDict[piece];
        OnPieceSelected?.Invoke(piece, tile);
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
    
    private void ConfigureIndicatorPosAndScale(GameObject hitObject)
    {
        MeshFilter mf = hitObject.GetComponent<MeshFilter>();
        Vector3 objSize = mf.sharedMesh.bounds.size;
        Vector3 objScale = hitObject.transform.localScale;
        float objHeight = objSize.y * objScale.y;

        var hitObjectPos = hitObject.transform.position;
        selectionIndicator.transform.position = new Vector3(hitObjectPos.x, hitObjectPos.y - objHeight / 2, hitObjectPos.z);

        if (scaleIndicatorWithPiece)
        {
            float diameter = hitObject.GetComponent<Renderer>().bounds.size.x;
            selectionIndicator.transform.localScale = new Vector3(diameter * selectorScale, 1, diameter * selectorScale);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 scale = new Vector3(3, 3, 3);
        Vector3 offset = new Vector3(0, 3, 0);
        Gizmos.color = Color.magenta;
        if (_selectedObject != null) { Gizmos.DrawWireCube(_selectedObject.transform.position + offset, scale); }
        if (_lastSelectedObject != null) { Gizmos.DrawWireCube(_lastSelectedObject.transform.position + offset, scale); }
    }
}



// MoveAtoB(lastSelected.GetCoords(), selected.GetCoords())
