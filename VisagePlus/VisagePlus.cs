﻿using System.ComponentModel.Composition;

using Ensage;
using Ensage.SDK.Abilities;
using Ensage.SDK.Abilities.npc_dota_hero_visage;
using Ensage.SDK.Service;
using Ensage.SDK.Service.Metadata;
using Ensage.SDK.Abilities.Items;
using Ensage.SDK.Inventory.Metadata;

namespace VisagePlus
{
    [ExportPlugin(
        name: "VisagePlus",
        mode: StartupMode.Auto,
        author: "YEEEEEEE", 
        version: "1.0.0.2",
        units: HeroId.npc_dota_hero_visage)]
    internal class VisagePlus : Plugin
    {
        private Config Config { get; set; }

        public IServiceContext Context { get; }

        private AbilityFactory AbilityFactory { get; }

        [ImportingConstructor]
        public VisagePlus([Import] IServiceContext context)
        {
            Context = context;
            AbilityFactory = context.AbilityFactory;
        }

        public visage_grave_chill GraveChill { get; set; }

        public visage_soul_assumption SoulAssumption { get; set; }

        public Dagon Dagon
        {
            get
            {
                return Dagon1 ?? Dagon2 ?? Dagon3 ?? Dagon4 ?? (Dagon)Dagon5;
            }
        }

        public Necronomicon Necronomicon
        {
            get
            {
                return Necronomicon1 ?? Necronomicon2 ?? (Necronomicon)Necronomicon3;
            }
        }

        [ItemBinding]
        public item_sheepstick Hex { get; set; }

        [ItemBinding]
        public item_orchid Orchid { get; set; }

        [ItemBinding]
        public item_bloodthorn Bloodthorn { get; set; }

        [ItemBinding]
        public item_rod_of_atos RodofAtos { get; set; }

        [ItemBinding]
        public item_veil_of_discord Veil { get; set; }

        [ItemBinding]
        public item_ethereal_blade Ethereal { get; set; }

        [ItemBinding]
        public item_dagon Dagon1 { get; set; }

        [ItemBinding]
        public item_dagon_2 Dagon2 { get; set; }

        [ItemBinding]
        public item_dagon_3 Dagon3 { get; set; }

        [ItemBinding]
        public item_dagon_4 Dagon4 { get; set; }

        [ItemBinding]
        public item_dagon_5 Dagon5 { get; set; }

        [ItemBinding]
        public item_necronomicon Necronomicon1 { get; set; }

        [ItemBinding]
        public item_necronomicon_2 Necronomicon2 { get; set; }

        [ItemBinding]
        public item_necronomicon_3 Necronomicon3 { get; set; }

        [ItemBinding]
        public item_force_staff ForceStaff { get; set; }

        [ItemBinding]
        public item_cyclone Eul { get; set; }

        [ItemBinding]
        public item_medallion_of_courage Medallion { get; set; }

        [ItemBinding]
        public item_solar_crest SolarCrest { get; set; }

        [ItemBinding]
        public item_armlet Armlet { get; set; }

        protected override void OnActivate()
        {
            Config = new Config(this);

            GraveChill = AbilityFactory.GetAbility<visage_grave_chill>();
            SoulAssumption = AbilityFactory.GetAbility<visage_soul_assumption>();

            Context.Inventory.Attach(this);
        }

        protected override void OnDeactivate()
        {
            Context.Inventory.Detach(this);

            Config?.Dispose();
        }
    }
}
