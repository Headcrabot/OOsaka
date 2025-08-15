using System.Collections.Generic;
using UnityEngine;

public class deckMaster : MonoBehaviour
{
    [SerializeField] private List<tile> _deck;
    public List<tile> deck { get { return _deck; } }

    [SerializeField] private Vector3 deckPosition;

    private bool bInitialized = false;

    public void Initialize()
    {
        if (bInitialized)
            return;

        bInitialized = true;

        foreach (var i in _deck)
        {
            i.Initialize();
        }
    }

    public tile PullOut()
    {
        if (!bInitialized)
            return null;

        tile pull = _deck[_deck.Count - 1];
        _deck.Remove(pull);
        return pull;
    }
    public void PutBack(tile ntile)
    {
        if (!bInitialized)
            return;

        ntile.gameObject.transform.position = deckPosition;
        ntile.Colore(false);
        _deck.Add(ntile);
    }
}
