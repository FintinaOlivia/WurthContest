
using System.ComponentModel;
using System.Reflection;

namespace SoftwarePirates.Domain
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }

    public enum ShipTypes
    {
        [Description("Pinnace")]
        Pinnace,
        [Description("Sloop")]
        Sloop,
        [Description("War Galleon")]
        WarGalleon,
    }

    public enum CannonAccuracies
    {
        [Description("")]
        Default,
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

    public enum CannonDamages
    {
        [Description("")]
        Default,
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

    public enum ComparativeSpeeds
    {
        [Description("")]
        Default,
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

    public enum Durabilities
    {
        [Description("")]
        Default,
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

    public enum Maneuverabilities
    {
        [Description("")]
        Default,
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

    public enum PhysicalSizes
    {
        [Description("")]
        Default,
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
    public enum PirateDamages
    {
        [Description("")]
        Default,
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
