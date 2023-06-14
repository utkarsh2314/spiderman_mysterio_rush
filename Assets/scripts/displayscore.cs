using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class displayscore : MonoBehaviour
{
    public TextMeshProUGUI cointext; 
    public TextMeshProUGUI enemy; 

    public void Setupcoin(int score)
    {
        cointext.text = score.ToString(); 
    }

    public void Setupenemy(int score)
    {
        enemy.text = score.ToString();
    }
}
