using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // N'oubliez pas d'importer le module UI

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText; // Référence au composant Text pour afficher le score

    // Start is called before the first frame update
    void Start()
    {
        // Assurez-vous d'assigner le composant Text pour afficher le score dans l'inspecteur
        scoreText = GetComponent<Text>();
        score = 0; // Initialise le score à zéro
        UpdateScoreText();
    }

    // Méthode pour incrémenter le score
    public void IncrementScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // Méthode pour mettre à jour le texte du score
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
