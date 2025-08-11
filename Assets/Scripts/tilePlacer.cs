using UnityEngine;

public class tilePlacer : MonoBehaviour
{
    private tile selectedTile = null;

    [SerializeField] private tile tilePrefab;

    private gameMaster _master;
    private Camera _camera;

    private int iPlacingX = 0;
    private int iPlacingY = 0;

    private void Start()
    {
        _master = gameMaster.master;
        _camera = Camera.main;
    }

    public void StartPlacingTile(tile ntile)
    {
        if (selectedTile != null)
        {
            Destroy(selectedTile.gameObject);
        }
        selectedTile = Instantiate(ntile);
        selectedTile.Initialize(_master.tileCounter);
    }

    private void PlaceTile()
    {
        selectedTile.Place();
        selectedTile = null;
    }

    private void Update()
    {
        if (selectedTile != null)
        {
            Plane worldPlane = new Plane(Vector3.up, Vector3.zero);
            Ray pointerRay = _camera.ScreenPointToRay(Input.mousePosition);
            float intersectionDistance = 0f;
            if (worldPlane.Raycast(pointerRay, out intersectionDistance))
            {
                // real position of mouse pointer ray and placing plane
                Vector3 worldPosition = pointerRay.GetPoint(intersectionDistance);

                // position in placing grid
                iPlacingX = Mathf.Clamp(Mathf.RoundToInt(worldPosition.x), 0, _master.iMapSize.x-1);
                iPlacingY = Mathf.Clamp(Mathf.RoundToInt(worldPosition.z), 0, _master.iMapSize.y-1);

                // real position in world
                float wpx = iPlacingX * _master.tileSize;
                float wpz = iPlacingY * _master.tileSize;

                selectedTile.transform.position = new Vector3(wpx, 0f, wpz);
            }

            bool bAvaliable = false;
            //Debug.Log($"CHECKING TILE {iPlacingX} {iPlacingY}");
            bAvaliable = _master.isPlaceFree(iPlacingX, iPlacingY);

            selectedTile.Colore(bAvaliable);
            if (Input.GetMouseButtonDown(1) && bAvaliable)
            {
                _master.AppendToMap(iPlacingX, iPlacingY, selectedTile);
                PlaceTile();
            }
        }
    }
}
