using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;   
    }

    void onEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {

            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            hookRange.AddModifier(newItem.hookLengthModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            hookRange.RemoveModifier(oldItem.hookLengthModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();









































































    }
}
