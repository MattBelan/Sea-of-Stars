using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CombatShip : CombatEntity
{
    [Header("Managers")]
    public UIManager uiManager;

    public GameObject therapyScreen;

    public List<ShipRoom> rooms;
    public bool shieldActive;
    float prevShield;
    float prevStun;
    public bool stunActive;

    public float stress { get; set; } // 0 - 100
    private bool pillReady;
    private bool pillTaken;
    private float prevPill;
    private int therapyHappening;
    private float therapyStartTime;
    public bool SOSState;

    UnityEvent therapyEvent = new UnityEvent();

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
        therapyHappening = 0;
        therapyStartTime = 0;
        stress = 0;
        SOSState = false;

        if (!uiManager) uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        if (!therapyScreen) therapyScreen = GameObject.Find("TherapyScreen");
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        Vector3 therapyPos;
        if(Health <= 2)
        {
            Debug.Log("Crisis event");
            SceneManager.LoadScene("SquareBreathing", LoadSceneMode.Single);
            Health += 4;
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
        if(Time.time - prevPill > 3)
        {
            pillTaken = false;
        }
        if(Time.time - prevPill > 4)
        {
            pillReady = true;
        }
        if (!inCombat)
        {
            if (therapyHappening == 1)
            {
                
                therapyPos = new Vector3(therapyScreen.transform.position.x, therapyScreen.transform.position.y - 0.015f, 1);
                if (therapyPos.y <= 3.5f)
                {
                    therapyPos.y = 3.5f;
                    if(therapyStartTime == 0)
                    {
                        therapyStartTime = Time.time;
                    }
                    if (Time.time - therapyStartTime > 4 && therapyStartTime != 0)
                    {
                        therapyHappening = 2;
                    }
                }
                

                therapyScreen.transform.position = therapyPos;
            }
            else if(therapyHappening == 2)
            {
                therapyPos = new Vector3(therapyScreen.transform.position.x, therapyScreen.transform.position.y + 0.015f, 1);
                if (therapyPos.y >= 7.0f)
                {
                    therapyPos.y = 7.0f;
                    therapyHappening = 0;
                }
                therapyScreen.transform.position = therapyPos;
                
            }
        }

        // Check if stress is too high
        if(stress >= 85 && SOSState == false)
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
        if (!inCombat)
        {
            therapyHappening = 1;
            if (pillTaken)
            {
                stress = stress - 30;
            }
            stress = stress - 20;
            if (stress < 0)
            {
                stress = 0;
            }
        }
        else
        {
            Debug.Log("Cannot undergo therapy in combat");
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
        else
        {
            Debug.Log("Medication on Cooldown");
        }
    }
}
