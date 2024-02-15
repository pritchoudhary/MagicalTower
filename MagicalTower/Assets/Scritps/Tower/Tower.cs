using System.Collections.Generic;
using UnityEngine;

//Tower component responsible for managing and casting spells

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    private readonly Dictionary<Spell, float> _spellCooldowns = new();

    private void Start()
    {
        foreach(var spell in _spells)
        {
            _spellCooldowns[spell] = 0; //Initalize cooldowns
        }
    }

    private void Update()
    {
        foreach (var spell in _spells)
        {
            _spellCooldowns[spell] -= Time.deltaTime; //Update cooldown timers

            if (_spellCooldowns[spell] <= 0 )
            {
                CastSpell(spell);
                _spellCooldowns[spell] = spell._coolDown; //Reset cooldown timer
            }
        }
    }

    private void CastSpell(Spell spell)
    {
        if(spell._requiresTarget)
        {
            //Cast barrage for each visible enemy
            foreach (var target in GetAllVisibleTargets())
            {
                spell.CastSpell(transform.position, target);
            }
        }
        else
        {
            spell.CastSpell(transform.position);
        }
        
    }

    private IEnumerable<Transform> GetAllVisibleTargets()
    {
        //Implement enemy detection logic
        //placeholder for now
        return new List<Transform>();
    }
}
