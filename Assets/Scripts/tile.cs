using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    private int _id = 0;
    public int id { get { return _id; } }


    private bool bInitialized = false;
    private bool bPlaced = false;
    private gameMaster _master;
    [SerializeField] private Renderer _render;
    [SerializeField] private List<tileElement> elements;

    public void Colore(bool bAvailable)
    {
        //Debug.Log($"COLOR {_render.material.color} PLACED {bPlaced} INIT {bInitialized}");
        if (bPlaced || !bInitialized) { return; }
        ChangeColor(bAvailable ? Color.green : Color.red);
    }

    public void Initialize(int nid)
    {
        if (bInitialized)
            return;

        _id = nid;
        gameObject.name = $"tile{_id}";

        _master = gameMaster.master;
        bInitialized = true;
    }
    public void Place(int inx, int iny)
    {
        if (bPlaced)
            return;
        ChangeColor(Color.white);
        transform.position = new Vector3(inx * _master.tileSize, _master.groundY, iny * _master.tileSize);
        bPlaced = true;
    }

    private void ChangeColor(Color ncolor)
    {
        _render.material.color = ncolor;
    }
}
