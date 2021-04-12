using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject characterMenu;
    public GameObject controlsMenu;
    public GameObject deathScreen;
    public Text escToExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == false && deathScreen.activeInHierarchy == false)
        { 
            if (characterMenu.activeInHierarchy == true || controlsMenu.activeInHierarchy == true)
            {
                characterMenu.SetActive(false);
                controlsMenu.SetActive(false);
            }
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == true) pauseMenu.SetActive(false);
        if ( pauseMenu.activeSelf == true || characterMenu.activeInHierarchy == true || controlsMenu.activeInHierarchy == true || deathScreen.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else Cursor.lockState = CursorLockMode.Locked;


    }

    public void ControlsPage() 
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
    public void CharacterPage()
    {
        pauseMenu.SetActive(false);
        characterMenu.SetActive(true);
    }
    public void BackToPauseMenu()
    {
        characterMenu.SetActive(false);
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
