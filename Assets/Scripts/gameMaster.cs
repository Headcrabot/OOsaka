using Unity.VisualScripting;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
    public static gameMaster master;

    [Header("OTHER MASTERS LINKS")]
    [SerializeField] private guiMaster _gui;
    [SerializeField] private cameraMaster _camera;
    [SerializeField] private deckMaster _deck;
    [SerializeField] private tilePlacer _placer;

    [Header("MAP PARAMETERS")]
    [SerializeField] private float _tileSize = 1f;
    public float tileSize { get { return _tileSize; } }

    [SerializeField] private float _groundY = 0f;
    public float groundY { get { return _groundY; } }


    [SerializeField] private int iMapWidth = 10;
    [SerializeField] private int iMapHeight = 10;
    public Vector2Int iMapSize { get { return new Vector2Int(iMapWidth, iMapHeight); } }

    private int iRightBorder = 9;
    private int iUpperBorder = 9;


    private tile[,] _map;
    private int _tileCounter = 0;
    public int tileCounter { get { return _tileCounter; } }

    private void Awake()
    {
        master = this;
        InitializeMap();
        _placer.Initialize();
        _camera.Initialize();
        _deck.Initialize();
        _gui.Initialize();
    }

    private void InitializeMap()
    {
        iRightBorder = iMapWidth - 1;
        iUpperBorder = iMapHeight - 1;
        _map = new tile[iMapWidth, iMapHeight];
    }

    public bool PlaceFree(int nx, int ny) => (_map[nx, ny] == null);

    // check correctfull neighbourhood
    public bool CheckNeighbours(int nx, int ny, tile ntile, bool bOnlyStraight = true)
    {
        //Debug.Log($"CHECKING NEIGHBOUR OF ({nx},{ny}) FROM ({((nx - 1 >= 0) ? nx - 1 : 0)},{((ny - 1 >= 0) ? ny - 1 : 0)}) TO ({((nx + 1 < iRightBorder) ? nx + 1 : iRightBorder)},{((ny + 1 < iUpperBorder) ? ny + 1 : iUpperBorder)})");
        tile[] neighbours;
        if (bOnlyStraight)
        {
            neighbours = StraightNeighbours(nx, ny);
        }
        else
        {
            neighbours = StraightNeighbours(nx, ny);
        }
        foreach (var e in ntile.elements)
        {
            // road
            if (e.iType == 0)
            {
                foreach (var i in neighbours)
                {
                    if (i == null)
                        continue;
                    //Debug.Log(i.id);



                }
            }
        }

        // foreach (var i in neighbours)
        // {
        //     if (i == null)
        //         continue;
        //     //Debug.Log(i.id);

        // }
        return false;
    }
    // added to map
    public bool AppendToMap(int nx, int ny, tile ntile)
    {
        if (!(IsInBounds(nx, ny) && PlaceFree(nx, ny)))
            return false;

        _map[nx, ny] = ntile;
        _tileCounter++;
        return true;
    }

    // return those neighbours
    //   #
    //  #.#
    //   #
    private tile[] StraightNeighbours(int nx, int ny)
    {
        tile[] neighbours = new tile[4];
        if (!IsInBounds(nx, ny))
            return neighbours;

        neighbours[0] = (nx > 0) ? (_map[nx - 1, ny]) : (null);
        neighbours[1] = (ny > 0) ? (_map[nx, ny - 1]) : (null);
        neighbours[2] = (nx < iMapWidth - 1) ? (_map[nx + 1, ny]) : (null);
        neighbours[3] = (nx < iMapHeight - 1) ? (_map[nx, ny + 1]) : (null);

        return neighbours;
    }

    // return those neighbours
    //  ###
    //  #.#
    //  ###
    private tile[] AllNeighbours(int nx, int ny)
    {
        tile[] neighbours = new tile[8];
        if (!IsInBounds(nx, ny))
            return neighbours;

        for (int x = (nx - 1 >= 0) ? nx - 1 : 0; x <= ((nx + 1 < iRightBorder) ? nx + 1 : iRightBorder); x++)
        {
            for (int y = (ny - 1 >= 0) ? ny - 1 : 0; y <= ((ny + 1 < iUpperBorder) ? ny + 1 : iUpperBorder); y++)
            {
                if (x == nx && y == ny)
                    continue;

                neighbours[x * 3 + y] = _map[x, y];
            }
        }
        return neighbours;
    }

    // checks tile coordinate in map
    public bool IsInBounds(int nx, int ny)
    {
        if (nx < 0 || nx > iMapWidth - 1)
            return false;
        if (ny < 0 || ny > iMapHeight - 1)
            return false;
        return true;
    }


    public void DeckPull()
    {
        if (!_placer.bPlacing)
            _placer.StartPlacingTile(_deck.PullOut());
    }

    public void PutBackTile(tile ntile) => _deck.PutBack(ntile);
}
