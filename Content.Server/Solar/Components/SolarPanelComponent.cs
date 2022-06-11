using Content.Server.Solar.EntitySystems;

namespace Content.Server.Solar.Components
{

    /// <summary>
    ///     This is a solar panel.
    ///     It generates power from the sun based on coverage.
    /// </summary>
    [RegisterComponent]

    public sealed class SolarPanelComponent : Component
    {
        /// <summary>
        /// Maximum supply output by this panel (coverage = 1)
        /// </summary>
        [DataField("maxSupply")]
        [ViewVariables]
        public int MaxSupply = 1500;

        /// <summary>
        /// Current coverage of this panel (from 0 to 1).
        /// This is updated by <see cref='PowerSolarSystem'/>.
        /// DO NOT WRITE WITHOUT CALLING UpdateSupply()!
        /// </summary>
        [ViewVariables]
        public float Coverage { get; set; } = 0;
    }
}
