using Common;
using Contexts.UI.View;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class ShowUIPanelSystem<TPanel, TEvent> : IEcsInitSystem, IEcsRunSystem
        where TPanel : Object, IUIPanelView
        where TEvent : struct
    {
        private readonly EcsCustomInject<IUIService> _uiService;

        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            EcsWorld ecsWorld = systems.GetWorld(ApplicationConstants.ECS_EVENTS_WORLD_NAME);
            _filter = ecsWorld.Filter<TEvent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            if (_filter.GetEntitiesCount() > 0)
            {
                _uiService.Value.ShowPanel<TPanel>();
            }
        }
    }
}