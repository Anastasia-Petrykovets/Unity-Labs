using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Button nextLevelButton;
    private int currentCoins = 0;
    private int maxCoins;
    private void Start()
    {
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    public void InitializeText(int maxCoins)
    {
        this.maxCoins = maxCoins;
        coinsText.text = currentCoins + "/" + this.maxCoins;
    }

    public void ChangeText()
    {
        currentCoins++;
        coinsText.text = currentCoins + "/" + maxCoins;
        if (currentCoins >= maxCoins)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
    }

    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
