using UnityEngine;

public class tile : MonoBehaviour
{

    private int _id = 0;
    public int id { get { return _id; } }


    private bool bInitialized = false;
    private bool bPlaced = false;

    [SerializeField] private Renderer _render;

    public void Colore(bool bAvaliable)
    {
        if (!bPlaced || !bInitialized)
            return;

        if (bAvaliable)
        {
            _render.material.color = Color.green;
        }
        else
        {
            _render.material.color = Color.red;
        }
    }

    public void Initialize(int nid)
    {
        if (bInitialized)
            return;

        _id = nid;
        gameObject.name = $"tile{_id}";
        bInitialized = true;
    }
    public void Place()
    {
        if (bPlaced)
            return;

        bPlaced = true;
    }
}
