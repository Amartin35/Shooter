using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScript : MonoBehaviour
{
    public Boss monBoss;

    public TextMeshProUGUI winTexte;
    public TextMeshProUGUI loseTexte;

    public void SpawnWinText()
    {
        winTexte.gameObject.SetActive(true);

    }
    public void SpawnLoseText()
    {
        loseTexte.gameObject.SetActive(true);

    }
}
