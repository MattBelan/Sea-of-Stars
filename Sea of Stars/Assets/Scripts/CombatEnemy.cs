using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : CombatEntity
{
    public CombatShip ship;
    public Vector3 startLerp;
    public Vector3 endLerp;

    public float speed = 1.0f;
    float startTime;
    float tripLength;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Health = 10;
        Damage = 1;
        FireRate = 6;
        AttackReady = true;
        startTime = Time.time;
        tripLength = Vector3.Distance(startLerp, endLerp);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (inCombat)
        {
            if (AttackReady)
            {
                Attack(ship);
            }

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / tripLength;
            transform.position = Vector3.Lerp(startLerp, endLerp, fracJourney);

            if (fracJourney >= 1)
            {
                Vector3 temp = endLerp;
                endLerp = startLerp;
                startLerp = temp;
                startTime = Time.time;
            }
        }
    }

    public override void Attack(CombatEntity target)
    {
        if (inCombat)
        {
            if (AttackReady)
            {
                ship.DamageRoom(Damage);
            }
            base.Attack(target);
        }
    }

    public void OnMouseOver()
    {
        if (inCombat)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ship.Attack(this);
            }
        }
    }
}
