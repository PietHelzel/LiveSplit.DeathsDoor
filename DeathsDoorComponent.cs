﻿using LiveSplit.Model;
using LiveSplit.UI.Components;
using Voxif.AutoSplitter;
using Voxif.IO;

[assembly: ComponentFactory(typeof(Factory))]
namespace LiveSplit.DeathsDoor {
    public partial class DeathsDoorComponent : Component {
        protected override EGameTime GameTimeType => EGameTime.Loading;

        private DeathsDoorMemory memory;

        public DeathsDoorComponent(LiveSplitState state) : base(state) {
#if DEBUG
            logger = new ConsoleLogger();
#else
            logger = new  FileLogger("_" + Factory.ExAssembly.GetName().Name.Substring(10) + ".log");
#endif
            logger.StartLogger();

            memory = new DeathsDoorMemory(logger);

            settings = new TreeSettings(state, StartSettings, ResetSettings, OptionsSettings);
            
            remainingSplits = new RemainingDictionary(logger);
        }

        public override void Dispose() {
            memory.Dispose();
            memory = null;
            base.Dispose();
        }
    }
}