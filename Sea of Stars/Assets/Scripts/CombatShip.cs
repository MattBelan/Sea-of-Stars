using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatShip : CombatEntity
{
    [Header("Managers")]
    public UIManager uiManager;

    public List<ShipRoom> rooms;
    public bool shieldActive;
    float prevShield;
    float prevStun;
    public bool stunActive;

    public float stress { get; set; } // 0 - 100
    private bool pillReady;
    private bool pillTaken;
    private float prevPill;
    public bool SOSState;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Health = 20;
        Damage = 2;
        FireRate = 5;
        AttackReady = true;
        shieldActive = false;
        pillReady = true;
        pillTaken = false;
        prevShield = 0;
        prevStun = 0;
        prevPill = 0;
        stress = 0;
        SOSState = false;

        if (!uiManager) uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(Health <= 2)
        {
            Debug.Log("Crisis event");

        }

        FireRate = 5 * (1 / rooms[3].roomModifier);
        Damage = 2 * rooms[4].roomModifier;

        if (Time.time - prevShield > 3)
        {
            shieldActive = false;
        }
        if(Time.time - prevStun > 4)
        {
            stunActive = false;
        }
        if(Time.time - prevPill > 5)
        {
            pillTaken = false;
        }

        if(Time.time - prevPill > 10)
        {
            pillReady = true;
        }

        // Check if stress is too high
        if(stress >= 75 && SOSState == false)
        {
            SOSState = true;
            uiManager.showSOS = true;
        }
    }

    public void Repair(float val)
    {
        Health += val;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Repair(1);
        }
    }

    public void DamageRoom(float dam)
    {
        rooms[Random.Range(0, 4)].health -= dam;
    }

    public void ActivateShield()
    {
        if (inCombat)
        {
            shieldActive = true;
            prevShield = Time.time;
        }
    }

    public override void TakeDamage(float dam)
    {
        if (!shieldActive)
        {
            base.TakeDamage(dam);
            stress += 5;
        }
        else
        {
            stress += 2;
        }
    }

    public override void Attack(CombatEntity target)
    {
        if (inCombat)
        {
            base.Attack(target);

            if (stunActive)
            {
                target.ResetAttackTimer();
            }
        }
    }

    public void ActivateStunner()
    {
        if (inCombat)
        {
            stunActive = true;
            prevStun = Time.time;
        }
    }

    public void ReduceStressTherapist()
    {
        //require combat to be inactive
        if (pillTaken)
        {
            stress = stress - 30;
        }
        stress = stress - 20;
        if(stress < 0)
        {
            stress = 0;
        }
    }

    public void ReduceStressPill()
    {
        if (pillReady)
        {
            pillTaken = true;
            pillReady = false;
            prevPill = Time.time;
            stress = stress - 10;
            if (stress < 0)
            {
                stress = 0;
            }
        }
    }
}
