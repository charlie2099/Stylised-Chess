using TMPro;
using UnityEngine;

public class PieceSelectorUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pieceSelectedText;
    [SerializeField] private TextMeshProUGUI tileSelectedText;
    [SerializeField] private PieceSelector pieceSelector;

    private void OnEnable()
    {
        pieceSelector.OnPieceSelected += UpdatePieceSelectedText;
    }
    
    private void OnDisable()
    {
        pieceSelector.OnPieceSelected -= UpdatePieceSelectedText;
    }

    private void UpdatePieceSelectedText(Piece piece, tile tile)
    {
        pieceSelectedText.text = "Piece: <color=orange>" + piece.name + "</color>";
        tileSelectedText.text = "Tile: <color=green>(" + tile.x + "," + tile.y + ")</color>";
    }
}
