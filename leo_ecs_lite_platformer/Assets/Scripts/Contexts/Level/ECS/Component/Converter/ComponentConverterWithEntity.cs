using AB_Utility.FromSceneToEntityConverter;
using Contexts.Level.ECS.View;
using Leopotam.EcsLite;

namespace Contexts.Level.ECS.Component.Converter
{
    public abstract class ComponentConverterWithEntity<T> : ComponentConverter<T> where T : struct
    {
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            var entityView = GetComponent<IEntityView>();
            entityView ??= gameObject.AddComponent<EntityView>();
            if (!entityView.IsInitialized)
            {
                entityView.Initialize(entityWithWorld);
            }

            base.Convert(entityWithWorld);
        }
    }
}