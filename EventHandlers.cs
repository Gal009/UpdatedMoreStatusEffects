using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.Events.Extensions;
using MEC;

namespace moreStatusEffects
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public bool playerclassscp;

        public void OnEnraging096(AddingTargetEventArgs ev)
        {
            if (Plugin.Singleton.Config.ShyGuyPanic)
            {
                if (Plugin.Singleton.Config.AdrenalienInsteadofPanic)
                {
                    if (Plugin.Singleton.Config.Talk)
                    {
                        ev.Target.ShowHint("Oh No, I looked at it's face stay away from me. I Got to Run!");
                    }
                    ev.Target.ArtificialHealth = ev.Target.MaxArtificialHealth = Plugin.Singleton.Config.PanicTime;
                    ev.Target.EnableEffect(EffectType.Invigorated, Plugin.Singleton.Config.PanicTime);
                }
                else
                {
                    if (Plugin.Singleton.Config.Talk)
                    {
                        ev.Target.ShowHint("Oh No, I looked at it's face stay away from me");
                    }
                    ev.Target.EnableEffect(EffectType.BodyshotReduction, Plugin.Singleton.Config.PanicTime);
                }
            }
        }

        public void OnMicroUse(UsingMicroHIDEnergyEventArgs ev)
        {
            if (Plugin.Singleton.Config.MicroBlur && ev.CurrentState == InventorySystem.Items.MicroHID.HidState.Firing)
            {
                if (Plugin.Singleton.Config.Talk)
                {
                    ev.Player.ShowHint("Woah this thing is powerful");
                }
                ev.Player.EnableEffect(EffectType.Blinded, 1);
            }
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Handler.Type == DamageType.Falldown && ev.Amount > Plugin.Singleton.Config.FallAmount && Plugin.Singleton.Config.FallDisability)
            {
                if (Plugin.Singleton.Config.Talk)
                {
                    ev.Target.ShowHint("Ah I think I fractured something!");
                }
                ev.Target.EnableEffect(EffectType.Disabled, Plugin.Singleton.Config.DisabledTime);
            }
            else if (ev.Handler.Type == DamageType.Explosion && ev.Amount > Plugin.Singleton.Config.GrenadeAmount && Plugin.Singleton.Config.GrenadeBurns)
            {
                if (Plugin.Singleton.Config.Talk)
                {
                    ev.Target.ShowHint("Ah it burns I need painkillers.");
                }
                ev.Target.EnableEffect(EffectType.Burned, Plugin.Singleton.Config.BurnTime);
                ev.Target.EnableEffect(EffectType.Bleeding, Plugin.Singleton.Config.BurnTime);
            }
        }

        public void OnMedicalItem(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Medkit ^ ev.Item.Type == ItemType.Painkillers ^ ev.Item.Type == ItemType.SCP500 ^ ev.Item.Type == ItemType.Adrenaline)
            {
                if (Plugin.Singleton.Config.DisableEffectOnMed)
                {
                    if (Plugin.Singleton.Config.Talk)
                    {
                        ev.Player.ShowHint("Might have fixed another issue aswell");
                    }
                    ev.Player.DisableEffect(EffectType.BodyshotReduction);
                    ev.Player.DisableEffect(EffectType.Exhausted);
                    ev.Player.DisableEffect(EffectType.Disabled);
                }
            }
        }
    }
}