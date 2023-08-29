using Contexts.Level.ECS.Listener;
using Leopotam.EcsLite;

namespace Contexts.Level.ECS.Component.Converter
{
    public class ForceListenerConverter : ComponentConverterWithEntity<ForceListener>
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            _component.Value = GetComponent<IForceListener>();
            base.Convert(entityWithWorld);
        }
    }
}