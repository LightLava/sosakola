using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager;
using Content.Shared.Tag;

namespace Content.Shared.Imerial.Virology;

public sealed class VirologySystem : EntitySystem
{
    [Dependency] private readonly ISerializationManager _seriMan = default!;

    public override void Initialize()
    {
        base.Initialize();
    }
    private void AddSymptom(EntityUid uid, VirusSymptomPrototype symptom)
    {
        /// <summary>
        /// Проверка на то, есть ли у таргетного энтити компонент вируса.
        /// </summary>
        if(!TryComp<VirusComponent>(uid, out var virusComp))
            return;
        
        var symptoms = virusComp.Symptoms;

        virusComp.Speed += symptom.SpeedModifier;
        virusComp.Stealth += symptom.StealthModifier;
        virusComp.Spread += symptom.SpreadModifier;
        virusComp.Resistance += symptom.ResistanceModifier;
        virusComp.Level += symptom.LevelModifier;

        AddComponents(virusComp.ContainerEntity, symptom.SymptomComponent);

        symptoms.Add(symptom);
    }
    private void RemSymptom(EntityUid uid, VirusSymptomPrototype symptom)
    {
        /// <summary>
        /// Проверка на то, есть ли у таргетного энтити компонент вируса.
        /// </summary>
        if(!TryComp<VirusComponent>(uid, out var virusComp))
            return;
        
        var symptoms = virusComp.Symptoms;

        virusComp.Speed -= symptom.SpeedModifier;
        virusComp.Stealth -= symptom.StealthModifier;
        virusComp.Spread -= symptom.SpreadModifier;
        virusComp.Resistance -= symptom.ResistanceModifier;
        virusComp.Level -= symptom.LevelModifier;
        if(Factory.TryGetRegistration(symptom.SymptomComponentString, out var registration))
            RemComp(virusComp.ContainerEntity, registration.Type);

        symptoms.Remove(symptom);
    }
    /// <summary>
    /// Взято из SharedMagicSystem.cs
    /// </summary>
    private void AddComponents(EntityUid target, ComponentRegistry comps)
    {
        foreach (var (name, data) in comps)
        {
            if (HasComp(target, data.Component.GetType()))
                continue;

            var component = (Component)Factory.GetComponent(name);
            var temp = (object)component;
            _seriMan.CopyTo(data.Component, ref temp);
            AddComp(target, (Component)temp!);
        }
    }
}