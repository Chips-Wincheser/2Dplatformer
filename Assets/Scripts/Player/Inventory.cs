using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Coin> Coins { get; private set; }
    public List<Heart> Hearts { get; private set; }

    private void Start()
    {
        Coins= new List<Coin>();
        Hearts= new List<Heart>();
    }
}
