using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animation meleeAnimation;

    public bool weaponIsAway;

    public WeaponChange weaponChange;

    // Start is called before the first frame update
    void Start()
    {
        weaponIsAway = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!weaponIsAway)
        {
            if (Input.GetMouseButtonDown(0)) meleeAnimation.Play("Attack");

            if (Input.GetMouseButtonDown(1)) meleeAnimation.CrossFade("Block", 0.5f);
            else if (Input.GetMouseButtonUp(1)) meleeAnimation.CrossFade("Unblock", 0.5f);
        }

        if (weaponChange.swordActive)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !weaponIsAway)
            {
                PutAway();
            }
            else if (Input.GetKeyDown(KeyCode.Q) && weaponIsAway)
            {
                GetSword();
            }
        }
    }
    public void PutAway()
    {
        meleeAnimation.Play("PutAway");
        weaponIsAway = true;
    }
    public void GetSword()
    {
        meleeAnimation.Play("GetSword");
        weaponIsAway = false;
    }
}
