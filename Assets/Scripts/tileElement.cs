using UnityEngine;

public enum elementTypes
{
    road,
    jinja,
    minka
}

public class tileElement : MonoBehaviour
{
    [SerializeField] private elementTypes _type = elementTypes.road;
    public elementTypes iType { get { return _type; } }

    // like so (0,1) is up, (-1,-1) is left down corner
    [SerializeField] private Vector2Int _position;
    public Vector2Int position { get { return _position; } }

}
