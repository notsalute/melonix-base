using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace neeko
{
    public class EnableDisableListener : MonoBehaviour
    {
        [method: HideFromIl2Cpp]
        public event Action OnEnableEvent;
        [method: HideFromIl2Cpp]
        public event Action OnDisableEvent;
        public EnableDisableListener(IntPtr obj) : base(obj)
        {
        }
        public void OnEnable()
        {
            Action onEnableEvent = this.OnEnableEvent;
            if (onEnableEvent == null)
            {
                return;
            }
            onEnableEvent();
        }
        public void OnDisable()
        {
            Action onDisableEvent = this.OnDisableEvent;
            if (onDisableEvent == null)
            {
                return;
            }
            onDisableEvent();
        }
    }
}
