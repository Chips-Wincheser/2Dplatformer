using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteHandler : MonoBehaviour
{
    [SerializeField] private Inventory _inventoryPlayer;
    [SerializeField] private ImageCoin[] _coinsImages;
    [SerializeField] private Canvas _FinishCanvas;
    [SerializeField] private TeleportNextLevl _teleport;

    private List<Coin> _coins;

    private void OnEnable()
    {
        _teleport.FinishedLevl+=Finish;
    }

    private void OnDisable()
    {
        _teleport.FinishedLevl-=Finish;
    }

    private void Finish(Collider2D collision)
    {
        _FinishCanvas.gameObject.SetActive(true);

        if (_inventoryPlayer.ShowCoinsList().Count>0)
        {
            for (int i = 0; i < _inventoryPlayer.ShowCoinsList().Count; i++)
            {
                _coinsImages[i].gameObject.SetActive(true);
            }
        }
    }
}
