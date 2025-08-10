using UnityEngine;

public class tilePlacer : MonoBehaviour
{
    private tile selectedTile;

    [SerializeField] private tile tilePrefab;

    private gameMaster _master;
    private Camera _camera;

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
                Vector3 worldPosition = pointerRay.GetPoint(intersectionDistance);

                float wpx = Mathf.RoundToInt(worldPosition.x)*_master.tileSize;
                float wpz = Mathf.RoundToInt(worldPosition.z)*_master.tileSize;

                selectedTile.transform.position = new Vector3(wpx, 0f, wpz);
            }
        }
    }
}
