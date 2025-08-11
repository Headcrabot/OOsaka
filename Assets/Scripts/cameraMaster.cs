using UnityEngine;

public class cameraMaster : MonoBehaviour
{
    [SerializeField] private Vector3 _startOffset = Vector3.zero;

    private Camera _camera;
    private gameMaster _master;

    private bool bInitialized = false;

    public void Initialize()
    {
        if (bInitialized)
            return;

        _master = gameMaster.master;
        _camera = Camera.main;
        _camera.transform.position = _startOffset;
    }
}
