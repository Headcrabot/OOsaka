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
    [SerializeField] private List<tileElement> _elements;
    public List<tileElement> elements { get { return _elements; } }

    private bool bReversed = true;

    public void Colore(bool bAvailable)
    {
        //Debug.Log($"COLOR {_render.material.color} PLACED {bPlaced} INIT {bInitialized}");
        if (bPlaced || !bReversed || !bInitialized) { return; }
        ChangeColor(bAvailable ? Color.green : Color.red);
    }

    public void Initialize()
    {
        if (bInitialized)
            return;

        ChangeColor(Color.gray);
        // it stored in deck
        _master = gameMaster.master;
        bInitialized = true;
    }
    public void Place(int inx, int iny, int nid)
    {
        if (bPlaced)
            return;

        _id = nid;
        gameObject.name = $"tile{_id}";
        ChangeColor(Color.white);
        transform.position = new Vector3(inx * _master.tileSize, _master.groundY, iny * _master.tileSize);
        bPlaced = true;
    }

    // card pick up
    public void TurnOver()
    {
        bReversed = false;
        if (bReversed)
        {
            ChangeColor(Color.gray);
        }
    }

    private void ChangeColor(Color ncolor)
    {
        _render.material.color = ncolor;
    }
}
