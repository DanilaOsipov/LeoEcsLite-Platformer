using Contexts.Level.ECS.Listener;
using Leopotam.EcsLite;

namespace Contexts.Level.ECS.Component.Converter
{
    public class PositionListenerConverter : ComponentConverterWithEntity<PositionListener>
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            _component.Value = GetComponent<IPositionListener>();
            base.Convert(entityWithWorld);
        }
    }
}