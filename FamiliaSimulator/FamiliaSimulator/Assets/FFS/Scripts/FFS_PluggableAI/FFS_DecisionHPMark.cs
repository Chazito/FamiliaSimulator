using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HPMark")]
public class FFS_DecisionHPMark : FFS_Decision {
    
    public int hpRequired;
    public bool isPercent = false;
    public FFS_HPRequirement requirement = FFS_HPRequirement.Equal;

    public override bool Decide(FFS_StateController controller)
    {
        int currentHp = controller.enemyStats.currentHealth;
        if (isPercent)
        {
            currentHp = Mathf.RoundToInt((currentHp / controller.enemyStats.maxHealth) * 100);
        }

        switch (requirement)
        {
            case FFS_HPRequirement.Lower:
                if(currentHp <= hpRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FFS_HPRequirement.Equal:
                if (currentHp == hpRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FFS_HPRequirement.Higher:
                if (currentHp >= hpRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }

}

public enum FFS_HPRequirement
{
    Lower, Equal, Higher
};
