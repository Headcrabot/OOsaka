using UnityEngine;

public class tileElement : ScriptableObject
{
    [SerializeField] private string _sname = "road";
    public string sName { get { return _sname; } }

    // like so (0,1) is up, (-1,-1) is left down corner
    [SerializeField] private Vector2 _position;
    public Vector2 position { get { return _position; } }
    
}
