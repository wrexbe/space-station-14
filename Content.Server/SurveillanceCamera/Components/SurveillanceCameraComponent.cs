using Content.Shared.DeviceNetwork;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;

namespace Content.Server.SurveillanceCamera;

[RegisterComponent]

public sealed class SurveillanceCameraComponent : Component
{
    // List of active viewers. This is for bookkeeping purposes,
    // so that when a camera shuts down, any entity viewing it
    // will immediately have their subscription revoked.
    public HashSet<EntityUid> ActiveViewers { get; } = new();

    // Monitors != Viewers, as viewers are entities that are tied
    // to a player session that's viewing from this camera
    //
    // Monitors are grouped sets of viewers, and may be
    // completely different monitor types (e.g., monitor console,
    // AI, etc.)
    public HashSet<EntityUid> ActiveMonitors { get; } = new();

    // If this camera is active or not. Deactivating a camera
    // will not allow it to obtain any new viewers.
    [ViewVariables]
    public bool Active { get; set; } = true;

    // This one isn't easy to deal with. Will require a UI
    // to change/set this so mapping these in isn't
    // the most terrible thing possible.
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("id")]
    public string CameraId { get; set;  } = "camera";

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("nameSet")]
    public bool NameSet { get; set; }

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("networkSet")]
    public bool NetworkSet { get; set; }

    // This has to be device network frequency prototypes.
    [DataField("setupAvailableNetworks", customTypeSerializer:typeof(PrototypeIdListSerializer<DeviceFrequencyPrototype>))]
    public List<string> AvailableNetworks { get; } = new();
}
