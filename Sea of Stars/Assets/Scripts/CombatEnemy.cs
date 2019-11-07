using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : CombatEntity
{
    public CombatShip ship;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Health = 10;
        Damage = 1;
        FireRate = 6;
        AttackReady = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (AttackReady)
        {
            Attack(ship);
        }
    }

    public override void Attack(CombatEntity target)
    {
        if (AttackReady)
        {
            ship.DamageRoom(Damage);
        }
        base.Attack(target);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ship.Attack(this);
        }
    }
}
