using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatShip : CombatEntity
{
    public List<ShipRoom> rooms;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Health = 20;
        Damage = 2;
        FireRate = 5;
        AttackReady = true;
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
}
