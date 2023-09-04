using UnityEngine;

namespace Contexts.UI.View.Implemented
{
    public abstract class UIPanelView : MonoBehaviour, IUIPanelView
    {
        public GameObject GameObject => gameObject;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}