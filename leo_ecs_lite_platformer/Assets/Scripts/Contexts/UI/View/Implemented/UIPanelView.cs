using System;
using UnityEngine;

namespace Contexts.UI.View.Implemented
{
    public abstract class UIPanelView : MonoBehaviour, IUIPanelView
    {
        void IUIPanelView.Show()
        {
            throw new NotImplementedException();
        }

        void IUIPanelView.Hide()
        {
            throw new NotImplementedException();
        }
    }
}