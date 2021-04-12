using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowAiming : MonoBehaviour
{   

    public bool weaponIsAway;
    public Animation aim;

    public WeaponChange weaponChange;

    
    void Start()
    {
        weaponIsAway = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!weaponIsAway)
        {
            if (Input.GetMouseButtonDown(1)) aim.CrossFade("Aiming", 0.5f);
            else if (Input.GetMouseButtonUp(1)) aim.CrossFade("stopAiming", 0.5f);
        }

        if (weaponChange.crossBowActive)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !weaponIsAway)
            {
                PutAwayCrossBow();
            }
            else if (Input.GetKeyDown(KeyCode.Q) && weaponIsAway)
            {
                GetCrossBow();
            }
        }

        
    }

    public void GetCrossBow()
    {
        aim.Play("GetOutWeapon");
        weaponIsAway = false;
    }
    public void PutAwayCrossBow()
    {
        aim.Play("PutAwayWeapon");
        weaponIsAway = true;       
    }
}
