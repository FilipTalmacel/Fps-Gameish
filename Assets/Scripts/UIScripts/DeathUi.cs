using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathUi : MonoBehaviour
{

    public GameObject deathScreen;

    public HealthBar healthBar;

    public bool dead;

    public PlayerMovement playerMovement;
    public ReloadShooting reloadShooting;
    public WeaponChange weaponChange;
    public CameraController cameraController;
    public MeleeAttack meleeAttack;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.healthSlider.value == 0)
        {
            deathScreen.SetActive(true);
            dead = true;
        }
        else deathScreen.SetActive(false);

        if (dead) Death();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Death()
    {
        playerMovement.enabled = false;
        reloadShooting.enabled = false;
        weaponChange.enabled = false;
        cameraController.enabled = false;
        meleeAttack.enabled = false;
    }
}
