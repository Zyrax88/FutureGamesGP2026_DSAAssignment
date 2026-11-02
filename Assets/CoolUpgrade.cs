using System;
using UnityEditor;
using UnityEngine;

using System.Collections.Generic;

[Serializable]
public abstract class UpgradeValues : ScriptableObject
{
    public abstract string GetDescription();
    public abstract void ApplyUpgrade();
}

[Serializable]
[CreateAssetMenu(menuName = "GameData/DamageValue")]
public class DamageUpgrade : UpgradeValues {
    public float damage;

    public override void ApplyUpgrade() {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        if(damage < 0)
        {
            return $"<color=red>Decrease damage by {damage}</color>";
        }

        return $"<color=green>Increse damage by {damage}</color>";
    }
}
[Serializable]
[CreateAssetMenu(menuName = "GameData/SpeedValue")]
public class SpeedUpgrade : UpgradeValues {
    public float speed;

    public override void ApplyUpgrade() {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return $"Increase speed by {speed}";
    }
}

[Serializable]
[CreateAssetMenu(menuName = "GameData/ProjectileValue")]
public class ProjectileUpgrade : UpgradeValues {
    public GameObject projectile;

    public override void ApplyUpgrade() {
        throw new NotImplementedException();
    }

    public override string GetDescription() {
        return $"Change projectile to {projectile.name}";
    }
}

[Serializable]
[CreateAssetMenu(menuName = "GameData/Health Condition")]
public class HealthCondition : UpgradeValues {
    public float health;
    public UpgradeValues lessThan;
    public UpgradeValues moreThan;
    public override void ApplyUpgrade() {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return $"if health is less than {health} {lessThan.GetDescription()} otherwise {moreThan.GetDescription()}";
    }
}

[CreateAssetMenu(menuName = "GameData/UpgradeData")]
public class CoolUpgrade : ScriptableObject
{
    public UpgradeValues[] upgradeActions;
    public string GetDescription()
    {
        string finalDescription = string.Empty;

        for(int i = 0; i < upgradeActions.Length; i++) {
            finalDescription += upgradeActions[i].GetDescription();
            if(i < upgradeActions.Length - 2)
            {
                finalDescription += "and ";
            }
        }

        return finalDescription;
    }

    public void ApplyUpgrade()
    {
        for(int i = 0; i < upgradeActions.Length; i++) {
            upgradeActions[i].ApplyUpgrade();
        }
    }
}
