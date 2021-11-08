using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{

    //variables
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public TetrominoData[] tetrominos;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);
    public RectInt Bounds
    {
        get
        {
            Vector2Int pos = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
            return new RectInt(pos, this.boardSize);
        }
    }


    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < this.tetrominos.Length; i++)
        {
            this.tetrominos[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    //spawnear una pieza random
    public void SpawnPiece()
    {
        int randomPiece = Random.Range(0, this.tetrominos.Length);
        TetrominoData data = this.tetrominos[randomPiece];

        this.activePiece.Initialize(this, this.spawnPosition, data);

        if (!IsValidPosition(this.activePiece, this.spawnPosition))
        {
            TileReset();
        }
        else
        {
            Set(this.activePiece);
        }
    }

    //cuando se acaba se limpia toda la pantalla y se sigue jugando
    public void TileReset()
    {
        Debug.Log(Score.score);
        Score.score -= 10000;
        this.tilemap.ClearAllTiles();
    }

    //pone la pieza en el tilemap del tablero
    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePos = piece.cells[i] + piece.pos;
            this.tilemap.SetTile(tilePos, piece.data.tile);
        }
    }

    //remueve una tile del tilemap
    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePos = piece.cells[i] + piece.pos;
            this.tilemap.SetTile(tilePos, null);
        }
    }

    //evalua si la posicion es valida
    public bool IsValidPosition(Piece piece, Vector3Int pos)
    {
        RectInt bounds = this.Bounds;

        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + pos;

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    //evalua si la linea esta completa
    public bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int pos = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(pos))
            {
                return false;
            }
        }

        return true;
    }

    //elimina una linea 
    public void LineClear(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int pos = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(pos, null);
        }
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int pos = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(pos);

                pos = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(pos, above);
            }

            row++;
        }
    }

    //limpia las lineas del tilemap
    public void ClearLines()
    {
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;
        int rowCount = 0;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                rowCount++;
                LineClear(row);
                if (rowCount >= 4)
                {
                    Score.score += 4000;
                    Piece.totalGameTime += 30;
                }
                else Score.score += 1000;
            }
            else
            {
                row++;
            }
        }
    }





}
