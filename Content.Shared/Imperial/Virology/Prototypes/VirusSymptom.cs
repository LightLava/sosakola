using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared.Imerial.Virology;

/// <summary>
/// Прототип определеного симптома.
/// </summary>
[Prototype]
public sealed partial class VirusSymptomPrototype : IPrototype
{

    [IdDataField] public string ID { get; private set; } = default!;
    /// <summary>
    /// Имя должно отображаться в ПАН-Д.Е.М.И.К
    /// </summary>
    [DataField] public string Name { get; private set; } = string.Empty;
    /// <summary>
    /// Скорость протекающих процессов и развития болезни.
    /// </summary>
    [DataField] public int SpeedModifier { get; private set; } = 0;
    /// <summary>
    /// Отвечает за то, видно ли болезнь на сканере.
    /// </summary>
    [DataField] public int StealthModifier { get; private set; } = 0;
    /// <summary>
    /// Отвечает за тип распростронения.
    /// </summary>
    [DataField] public int SpreadModifier { get; private set; } = 0;
    /// <summary>
    /// То, сколько химиката нужно для излечения.
    /// </summary>
    [DataField] public int ResistanceModifier { get; private set; } = 0;
    /// <summary>
    /// То, какой химикат нужен для излечения.
    /// </summary>
    [DataField] public int LevelModifier { get; private set; } = 0;
    /// <summary>
    /// На какой стадии проявляется симптом.
    /// </summary>
    [DataField] public int SymptomLevelModifier { get; private set; } = 0;
    /// <summary>
    /// Компонент, добовляющийся при проявлении симптома.
    /// </summary>
    [DataField] public ComponentRegistry SymptomComponent { get; private set; } = new();
    [DataField] public string SymptomComponentString { get; private set; } = string.Empty;
}