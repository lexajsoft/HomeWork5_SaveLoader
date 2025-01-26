using System;
using ObjectLinks.Minings;

namespace ObjectLinks.Units
{
    // описаны линковочные класс пустышки для связи с данными и визуалом
    [Serializable]
    public abstract class UnitLink : LinkBase
    {
        
    }
    
    [Serializable]
    public class WarriorUnit : UnitLink { }
    [Serializable]
    public class ArcherUnit : UnitLink { }
    [Serializable]
    public class HealerUnit : UnitLink { }
    [Serializable]
    public class RunnerUnit : UnitLink { }
}