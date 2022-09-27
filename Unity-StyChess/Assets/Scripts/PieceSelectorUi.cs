using TMPro;
using UnityEngine;

public class PieceSelectorUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pieceSelectedText;
    [SerializeField] private PieceSelector pieceSelector;

    private void OnEnable()
    {
        pieceSelector.OnPieceSelected += UpdatePieceSelectedText;
    }
    
    private void OnDisable()
    {
        pieceSelector.OnPieceSelected -= UpdatePieceSelectedText;
    }

    private void UpdatePieceSelectedText(Piece piece)
    {
        pieceSelectedText.text = "Selected: <color=orange>" + piece.name + "</color>";
    }
}
