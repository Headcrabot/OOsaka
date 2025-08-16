using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    private int _id = 0;
    public int id { get { return _id; } }


    private bool bInitialized = false;
    private bool bPlaced = false;
    private gameMaster _master;
    private tileVisuals _visual;
    [SerializeField] private List<tileElement> _elements;
    public List<tileElement> elements { get { return _elements; } }

    private bool bReversed = true;

    public void Colore(bool bAvailable)
    {
        //Debug.Log($"COLOR {_render.material.color} PLACED {bPlaced} INIT {bInitialized}");
        if (bPlaced || !bReversed || !bInitialized || !_visual) { return; }
        _visual.ChangeColor(bAvailable ? Color.green : Color.red);
    }

    public void Initialize()
    {
        if (bInitialized)
            return;

        if (_visual = GetComponent<tileVisuals>())
        {
            _visual.Initialize();
            _visual.ChangeColor(Color.white);
        }
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
        if (_visual)
        {
            _visual.ChangeColor(Color.white);
        }
        transform.position = new Vector3(inx * _master.tileSize, _master.groundY, iny * _master.tileSize);
        bPlaced = true;
    }

    // card pick up
    public void TurnOver()
    {
        bReversed = false;
        _visual.ChangeColor(Color.white);
        if (bReversed)
        {
            // ChangeColor(Color.gray);
        }
    }

}
