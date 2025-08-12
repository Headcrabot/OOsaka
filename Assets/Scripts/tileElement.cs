using UnityEngine;


public class tileElement : ScriptableObject
{
    [SerializeField] private string _sname = "road";
    public string sName { get { return _sname; } }

    [SerializeField] private int _type = 0;
    public int iType { get { return _type; } }

    // like so (0,1) is up, (-1,-1) is left down corner
    [SerializeField] private Vector2 _position;
    public Vector2 position { get { return _position; } }

}
