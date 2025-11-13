
using System.ComponentModel;

namespace SoftwarePirates.Domain
{
    internal enum CannonAccuracies
    {
        [Description("Very Low")]
        VeryLow,
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High, 
        [Description("Very High")]
        VeryHigh, 
        [Description("Very High Plus")]
        VeryHighPlus
    }

    internal enum CannonDamages
    {
        [Description("Very Low")]
        VeryLow,
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High,
        [Description("Very High")]
        VeryHigh,
        [Description("Very High Plus")]
        VeryHighPlus
    }

    internal enum ComparativeSpeeds
    {
        [Description("Drifting")]
        Drifting,
        [Description("Very Slow")]
        VerySlow,
        [Description("Slow")]
        Slow,
        [Description("Slow High")]
        SlowHigh,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High,
        [Description("Very High")]
        VeryHigh,
        [Description("Very High Plus")]
        VeryHighPlus
    }

    internal enum Durabilities
    {
        [Description("Very Low")]
        VeryLow,
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High,
        [Description("Very High")]
        VeryHigh,
        [Description("Very High Plus")]
        VeryHighPlus
    }

    internal enum Maneuverabilities
    {
        [Description("Very Low")]
        VeryLow,
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High,
        [Description("Very High")]
        VeryHigh,
        [Description("Very High Plus")]
        VeryHighPlus
    }

    internal enum PhysicalSizes
    {
        [Description("Very Small")]
        VerySmall,
        [Description("Small")]
        Small,
        [Description("Medium")]
        Medium,
        [Description("Large")]
        Large,
        [Description("Very Large")]
        VeryLarge,
        [Description("Very Large Plus")]
        VeryLargePlus
    }
    internal enum PirateDamages
    {
        [Description("Very Low")]
        VeryLow,
        [Description("Low")]
        Low,
        [Description("Medium")]
        Medium,
        [Description("High")]
        High,
        [Description("Very High")]
        VeryHigh,
        [Description("Very High Plus")]
        VeryHighPlus
    }
}
