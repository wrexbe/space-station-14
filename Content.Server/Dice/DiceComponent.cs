using Content.Shared.Sound;

namespace Content.Server.Dice
{
    [RegisterComponent]
    public sealed class DiceComponent : Component
    {
        [ViewVariables]
        [DataField("sound")]
        public SoundSpecifier Sound { get; } = new SoundCollectionSpecifier("Dice");

        [ViewVariables]
        [DataField("step")]
        public int Step { get; } = 1;

        [ViewVariables]
        [DataField("sides")]
        public int Sides { get; } = 20;

        [ViewVariables]
        public int CurrentSide { get; set; } = 20;
    }
}
