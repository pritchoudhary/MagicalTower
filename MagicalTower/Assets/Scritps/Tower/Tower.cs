using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tower component responsible for managing and casting spells

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    private readonly Dictionary<Spell, float> _spellCooldowns = new();
    private bool _isCasting = false;

    private void Start()
    {
        foreach(var spell in _spells)
        {
            _spellCooldowns[spell] = 0; //Initalize cooldowns
        }
    }

    private void Update()
    {
        if (_isCasting)
            return; //Skip update if already casting a spell

        foreach (var spell in _spells)
        {
            _spellCooldowns[spell] -= Time.deltaTime; //Update cooldown timers

            if (_spellCooldowns[spell] <= 0 && GetAllVisibleTargets().GetEnumerator().MoveNext()) //check if the cool down is done and there are visible targets
            {
                StartCoroutine(CastSpellRoutine(spell));
                _spellCooldowns[spell] = spell._coolDown; //Reset cooldown timer
                break; //Ensure only one spell is cast at a time
            }
        }
    }

    private IEnumerator CastSpellRoutine(Spell spell)
    {
        _isCasting = true;
        CastSpell(spell);
        yield return new WaitForSeconds(spell._coolDown);
        _isCasting = false;
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
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            yield return enemy.transform;
    }
}
