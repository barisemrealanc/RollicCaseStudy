using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Button startButton, nextLevelButton;
    public GameObject menuUI, inGameUI, endUI;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        SetBindings();
    }

    private void SetBindings()
    {
        startButton.onClick.AddListener(() =>
        {
            _gameManager.StartGame();
            menuUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        
        );

        nextLevelButton.onClick.AddListener(() =>
        {
            endUI.SetActive(false);
            _gameManager.StartNextGame();
            inGameUI.SetActive(true);
        }

        );
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = "Level " + (level+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndLevel()
    {
        inGameUI.SetActive(false);
        endUI.SetActive(true);
    }
}
