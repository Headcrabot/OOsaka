using UnityEngine;

public class gameMaster : MonoBehaviour
{
    public static gameMaster master;

    [Header("OTHER MASTERS LINKS")]
    [SerializeField] private guiMaster _gui;
    [SerializeField] private cameraMaster _camera;

    [Header("MAP PARAMETERS")]
    [SerializeField] private float _tileSize = 1f;
    public float tileSize { get { return _tileSize; } }

    [SerializeField] private float _groundY = 0f;
    public float groundY { get { return _groundY; } }

    
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
        _camera.Initialize();
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

    public bool PlaceFree(int nx, int ny)
    {
        return (_map[nx, ny] == null);
    }

    public bool CheckNeighbours(int nx, int ny)
    {
        int rightBorder = iMapWidth-1;
        int upperBorder = iMapHeight-1;
        Debug.Log($"CHECKING NEIGHBOUR OF ({nx},{ny}) FROM ({((nx - 1 >= 0) ? nx - 1 : 0)},{((ny - 1 >= 0) ? ny - 1 : 0)}) TO ({((nx + 1 < rightBorder) ? nx + 1 : rightBorder)},{((ny + 1 < upperBorder) ? ny + 1 : upperBorder)})");
        for (int x = (nx - 1 >= 0) ? nx - 1 : 0; x <= ((nx + 1 < rightBorder) ? nx + 1 : rightBorder); x++)
        {
            for (int y = (ny - 1 >= 0) ? ny - 1 : 0; y <= ((ny + 1 < upperBorder) ? ny + 1 : upperBorder); y++)
            {
                if (x == nx && y == ny)
                    continue;
                Debug.Log($"CHECKED NEIGHBOUR AT ({x},{y})");
            }
        }

        return false;
    }

    public bool AppendToMap(int nx, int ny, tile ntile)
    {
        if (PlaceFree(nx, ny))
        {
            _map[nx, ny] = ntile;
            _tileCounter++;
            return true;
        }
        return false;
    }
}
