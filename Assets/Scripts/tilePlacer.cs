using System.Collections.Generic;
using UnityEngine;

public class tilePlacer : MonoBehaviour
{
    [SerializeField] private tile selectedTile = null;
    public bool bPlacing {get{ return selectedTile != null; } }
    [SerializeField] private tile tilePrefab;
    [SerializeField] private float fSelectedOffset = 1f;
    [SerializeField] private bool bDeck = false;

    private gameMaster _master;
    private Camera _camera;

    private int iPlacingX = 0;
    private int iPlacingY = 0;

    private bool bInitialized = false;

    public void Initialize()
    {
        if (bInitialized)
            return;
        _master = gameMaster.master;
        _camera = Camera.main;
        bInitialized = true;
    }

    public void StartPlacingTile(tile ntile)
    {
        if (ntile == null)
            return;

        if (bDeck)
        {
            if (bPlacing)
            {
                _master.PutBackTile(selectedTile);
            }
            selectedTile = ntile;
        }
        else
        {
            if (bPlacing)
            {
                Destroy(selectedTile.gameObject);
            }
            selectedTile = Instantiate(ntile);
        }
        selectedTile.Initialize();
    }

    private void PlaceTile()
    {
        selectedTile.Place(iPlacingX, iPlacingY, _master.tileCounter);
        selectedTile = null;
    }

    private void Update()
    {
        if (bPlacing)
        {
            Plane worldPlane = new Plane(Vector3.up, Vector3.zero);
            Ray pointerRay = _camera.ScreenPointToRay(Input.mousePosition);
            float intersectionDistance = 0f;
            if (worldPlane.Raycast(pointerRay, out intersectionDistance))
            {
                // real position of mouse pointer ray and placing plane
                Vector3 worldPosition = pointerRay.GetPoint(intersectionDistance);

                // position in placing grid
                iPlacingX = Mathf.Clamp(Mathf.RoundToInt(worldPosition.x), 0, _master.iMapSize.x - 1);
                iPlacingY = Mathf.Clamp(Mathf.RoundToInt(worldPosition.z), 0, _master.iMapSize.y - 1);

                // real position in world
                float wpx = iPlacingX * _master.tileSize;
                float wpz = iPlacingY * _master.tileSize;

                selectedTile.transform.position = new Vector3(wpx, _master.groundY + fSelectedOffset, wpz);
            }

            bool bAvaliable = false;

            bAvaliable = _master.PlaceFree(iPlacingX, iPlacingY);
            //Debug.Log($"CHECKING TILE {iPlacingX} {iPlacingY} IS {bAvaliable}");
            selectedTile.Colore(bAvaliable);
            if (Input.GetMouseButtonDown(1) && bAvaliable)
            {
                _master.AppendToMap(iPlacingX, iPlacingY, selectedTile);
                PlaceTile();
            }

            // Debug
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(_master.CheckNeighbours(iPlacingX, iPlacingY, selectedTile));
            }
        }
    }
}
