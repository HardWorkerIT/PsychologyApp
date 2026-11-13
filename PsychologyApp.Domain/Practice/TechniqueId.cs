namespace PsychologyApp.Domain.Practice;

public enum TechniqueId
{
    Spin,
    Comparison,
    Polarity,
    Paper,
    Future,
    Hack,
    Experience,
    Copied,
    Extend,
    Resize,
    Check,
    Observer,
    Anchor,
    Grounding,
    Breathing,
    SmallStep,
    ThoughtRecord,
    SelfCompassion,

    /// <summary>Where is it in the body: noticing the body sensation of a feeling and breathing with it (body scan).</summary>
    BodyScan,

    /// <summary>Help when a traumatic memory takes over: a guided return to the present (dialogue).</summary>
    Flashback,

    /// <summary>Rewriting a recurring nightmare and rehearsing the new version (imagery rehearsal therapy).</summary>
    Nightmare,

    /// <summary>Popping balloons with taps: a short, bounded game to let acute tension out.</summary>
    Balloons,

    /// <summary>The cyclic sigh: a double breath in through the nose and a long breath out, paced for a few minutes.</summary>
    CyclicSigh,

    /// <summary>A short progressive muscle relaxation: tense and let go of five muscle groups in turn.</summary>
    MuscleRelax,

    /// <summary>A brief temporary attention shift with a neutral task; it does not replace returning to an actionable problem.</summary>
    BusyMind,

    /// <summary>Notice a thought as a thought, then reconnect with the present and choose a small next action.</summary>
    ThoughtDefusion,

    /// <summary>Pause before acting on an intense urge; notice facts and choose a safe response.</summary>
    PauseBeforeReaction,

    /// <summary>Choose an action opposite to an emotion-driven urge only when facts and safety support it.</summary>
    OppositeAction,

    /// <summary>Define one controllable problem, compare options, and choose a concrete next step.</summary>
    ProblemSolving,

    /// <summary>Separate observable facts from interpretations before choosing an emotional response.</summary>
    CheckTheFacts,

    /// <summary>Record a hypothetical worry and schedule a later time to revisit it instead of suppressing it.</summary>
    WorryTime,
    ImplementationIntention,
    SensoryComfort,
    UrgeSurfing,
    MoneyWorryPlan
}

public enum TechniqueUiKind
{
    None,
    Entry,
    Polarity,
    Paper,
    Copied
}
