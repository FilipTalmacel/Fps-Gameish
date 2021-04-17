using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animation meleeAnimation;

    public int DamadgeModifier = 20;
    private float startTime, endTime;

    public bool weaponIsAway;

    public WeaponChange weaponChange;
    public BoxCollider swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        weaponIsAway = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thisObject = this.gameObject;
        swordCollider = thisObject.GetComponent<BoxCollider>();
        DamadgeModifier = 20;

        if (!weaponIsAway)
        {
            if (Input.GetMouseButtonUp(0)) meleeAnimation.Play("Attack");

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

        if (Input.GetMouseButtonDown(0)) startTime = Time.time;
        if (Input.GetMouseButtonUp(0)) endTime = Time.time;
        HeavyAttack();
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

    public void HeavyAttack()
    {
        if (endTime - startTime > 1f) DamadgeModifier = 35;
        else DamadgeModifier = 20;
    }
}
