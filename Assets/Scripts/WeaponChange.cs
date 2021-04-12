using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public CrossBowAiming crossBowAiming;
    public ReloadShooting reloadShooting;
    public MeleeAttack meleeAttack;

    public bool swordActive;
    public bool crossBowActive;
    public bool staffActive;
    
    // Start is called before the first frame update
    void Start()
    {
        crossBowActive = false;
        swordActive = false;
        staffActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sword();
            swordActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CrossBow();
            crossBowActive = true;
        }


        if (!crossBowActive || crossBowAiming.weaponIsAway)
        {
            reloadShooting.enabled = false;
        }
        else
        {
            reloadShooting.enabled = true;
        }



    }
    void Sword()
    {
        if (meleeAttack.weaponIsAway)
        {
            meleeAttack.GetSword();
            if (!crossBowAiming.weaponIsAway)
            {
                crossBowAiming.PutAwayCrossBow();
                crossBowActive = false;
            }
        }

    }
    void CrossBow()
    {
        if (crossBowAiming.weaponIsAway)
        {
            crossBowAiming.GetCrossBow();
            if (!meleeAttack.weaponIsAway)
            {
                meleeAttack.PutAway();
                swordActive = false;
            }
        }
    }
}
