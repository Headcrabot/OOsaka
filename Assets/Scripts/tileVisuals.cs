using UnityEngine;

[RequireComponent(typeof(tile))]
public class tileVisuals : MonoBehaviour
{
    [SerializeField] private Renderer[] _render;
    private gameMaster _master;
    private bool bInitialized = false;

    public void Initialize()
    {
        if (bInitialized)
            return;

        _render = GetComponentsInChildren<Renderer>();
        _master = gameMaster.master;
        bInitialized = true;
    }

    public void ChangeColor(Color ncolor)
    {
        if (!bInitialized)
            return;
            
        foreach (var render in _render)
        {
            render.material.color = ncolor;
        }
    }
}
