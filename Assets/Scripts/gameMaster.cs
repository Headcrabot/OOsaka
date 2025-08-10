using UnityEngine;

public class gameMaster : MonoBehaviour
{
    public static gameMaster master;

    [SerializeField] private guiMaster _gui;
    [SerializeField] private float _tileSize = 1f;
    public float tileSize {get{ return _tileSize; }}

    private void Awake()
    {
        master = this;
    }
}
