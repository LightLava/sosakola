using Content.Shared.Imerial.Virology;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared.Imerial.Virology;

[RegisterComponent]
public sealed partial class VirusComponent : Component
{
    /// <summary>
    /// Айди энтити контейнера, или же носителя.
    /// </summary>
    [DataField]
    public EntityUid ContainerEntity;
    /// <summary>
    /// Скорость протекающих процессов и развития болезни.
    /// </summary>
    [DataField]
    public int Speed = 0;
    /// <summary>
    /// Отвечает за то, видно ли болезнь на сканере.
    /// </summary>
    [DataField]
    public int Stealth = 0;
    /// <summary>
    /// Отвечает за тип распростронения.
    /// </summary>
    [DataField]
    public int Spread = 0;
    /// <summary>
    /// То, сколько химиката нужно для излечения.
    /// </summary>
    [DataField] 
    public int Resistance = 0;
    [DataField] 
    public int Level = 0;
    /// <summary>
    /// То, какой химикат нужен для излечения.
    /// </summary>
    [DataField]
    public VirusCure CurrentCure = VirusCure.TableSalt;
    /// <summary>
    /// Лист со всеми симптомами.
    /// </summary>
    [DataField]
    public List<ProtoId<VirusSymptomPrototype>> Symptoms = new();
}
[Serializable, NetSerializable]
public enum VirusCure
{
    TableSalt,
    JuiceOrange,
    Ethanol,
    Cryptobiolin,
    Spaceacillin
}