using UnityEngine;

namespace Commands
{
    public class Move : ICommand
    {
        private Piece _piece;
        private Tile _tile;
        private Tile _previousTile;
        
        public Move(Piece piece, Tile tile) 
        {
            _piece = piece;
            _tile = tile;
            _previousTile = piece.GetComponent<Tile>();
        }
        
        public void Execute()
        {
            _piece.transform.position = new Vector3(_tile.x, 0, _tile.y);
        }

        public void Undo()
        {
            _piece.transform.position = new Vector3(_previousTile.x, 0, _previousTile.y);
        }
    }
}
