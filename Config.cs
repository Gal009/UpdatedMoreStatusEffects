using System.ComponentModel;
using Exiled.API.Interfaces;

namespace moreStatusEffects
{
    public sealed class Config : IConfig
    {
        [Description("Whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Removes bad effects on medkit")]
        public bool DisableEffectOnMed { get; set; } = true;

        [Description("Should the player say something upon effect activated using showhint")]
        public bool Talk { get; set; } = true;

        //Panics

        [Description("Should the player get adrenaline instead of panic")]
        public bool AdrenalienInsteadofPanic { get; set; } = true;

        [Description("How long the player will panic if triggered/extra ahp from adrenaline")]
        public int PanicTime { get; set; } = 15;

        [Description("Whether the player Panics whenever he looks at shy guy")]
        public bool ShyGuyPanic { get; set; } = true;

        //Blur
        [Description("Whether the player is blurred when using micro")]
        public bool MicroBlur { get; set; } = true;

        //Disabilities
        [Description("How long until the player recovers from leg damage")]
        public float DisabledTime { get; set; } = 15;

        [Description("Whether the player becomes disabled from falling")]
        public bool FallDisability { get; set; } = true;

        [Description("How much leg damage to trigger effect")]
        public float FallAmount { get; set; } = 35;

        //Burns
        [Description("How long until the player recovers from burn damage")]
        public float BurnTime { get; set; } = 15;

        [Description("How much grenade damage to trigger effect")]
        public float GrenadeAmount { get; set; } = 17;

        [Description("Whether the player is burned from grenades/ extra damage per couple seconds + more damage overall")]
        public bool GrenadeBurns { get; set; } = true;


    }
}