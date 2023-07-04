using Shared.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public Attributes attributes = new Attributes(hp:100,con:9,mp:1000,wis:0,intel:0);
    public ManaBar manaBar;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {	
		manaBar.SetMaxMana(attributes.MaxMP.FinalValue);
        healthBar.SetMaxHealth(attributes.MaxHP.FinalValue);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(50);
		}
    }

	void TakeDamage(int damage)
	{
		attributes.RemainingHP -= damage;

        healthBar.SetHealth(attributes.RemainingHP);
        attributes.RemainingMP -= damage;

        manaBar.SetMana(attributes.RemainingMP);
    }
}
