using UnityEngine;

public class gameMaster : MonoBehaviour
{
    public static gameMaster master;

    [SerializeField] private guiMaster _gui;
    [SerializeField] private float _tileSize = 1f;
    public float tileSize { get { return _tileSize; } }

    [SerializeField] private int iMapWidth = 10;
    [SerializeField] private int iMapHeight = 10;
    public Vector2Int iMapSize {get{ return new Vector2Int(iMapWidth, iMapHeight); }}

    private tile[,] _map;
    private int _tileCounter = 0;
    public int tileCounter { get { return _tileCounter; } }

    private void Awake()
    {
        master = this;
        InitializeMap();
    }

    private void InitializeMap()
    {
        _map = new tile[iMapWidth, iMapHeight];
        // for (int i = 0; i < iMapWidth; i++)
        // {
        //     for (int j = 0; j < iMapHeight; j++)
        //     {
        //         Debug.Log($"NULLING TILE {i} {j}");
        //         _map[i, j] = null;
        //     }
        // }
    }

    public bool isPlaceFree(int nx, int ny)
    {
        return (_map[nx, ny] == null);
    }

    public bool AppendToMap(int nx, int ny, tile ntile)
    {
        if (isPlaceFree(nx, ny))
        {
            _map[nx, ny] = ntile;
            _tileCounter++;
            return true;
        }
        return false;
    }
}
