using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace moreStatusEffects
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Scp096.AddingTarget += EventHandlers.OnEnraging096;
            Player.Hurting += EventHandlers.OnHurting;
            Player.ItemUsed += EventHandlers.OnMedicalItem;
            Player.UsingMicroHIDEnergy += EventHandlers.OnMicroUse;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Exiled.Events.Handlers.Scp096.AddingTarget -= EventHandlers.OnEnraging096;
            Player.Hurting -= EventHandlers.OnHurting;
            Player.ItemUsed -= EventHandlers.OnMedicalItem;
            Player.UsingMicroHIDEnergy -= EventHandlers.OnMicroUse;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}