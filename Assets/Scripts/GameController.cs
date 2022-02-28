using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectionMenu;
    [SerializeField] private GameObject exitMenu;
    private bool inExitMenu;
    [SerializeField] private TMPro.TMP_InputField inputField;
    [SerializeField] private AudioClip clip;
    public bool playerIsMale;
    public string playerName;

    public static GameController instancia = null;

    private void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        exitMenu.SetActive(false);
        inExitMenu = false;
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Game Scene")
        {
            SoundManager.CreateSound(clip, transform.position, false, 1);

            if (inExitMenu)
            {
                exitMenu.SetActive(false);
                inExitMenu = false;
            }
            else
            {
                exitMenu.SetActive(true);
                inExitMenu = true;
            }
            
        }
    }

    public void LoadSelectScreen()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        mainMenu.SetActive(false);
        selectionMenu.SetActive(true);
    }

    public void SelectMale()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        playerIsMale = true;
    }

    public void SelectFemale()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        playerIsMale = false;
    }

    public void StartPlay()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        playerName = inputField.text;
        selectionMenu.SetActive(false);
        SceneManager.LoadScene("Game Scene");
    }

    public void BackToMainMenu()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
        exitMenu.SetActive(false);
        SceneManager.LoadScene("Menu Scene");
    }

    public void CloseExitMenu()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        exitMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SoundManager.CreateSound(clip, transform.position, false, 1);
        Application.Quit();
    }
}
