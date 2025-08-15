using UnityEngine;
using UnityEngine.UI;

public class guiMaster : MonoBehaviour
{
    [SerializeField] private Button pullButton;

    private gameMaster _master;
    private bool bInitialized = false;
    

    public void Initialize()
    {
        if (bInitialized)
            return;

        _master = gameMaster.master;
        pullButton.onClick.AddListener(_master.DeckPull);
        
        bInitialized = true;
    }

    private void OGUI()
    {

    }
}
