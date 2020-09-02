using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core
{
    internal class BaseManager
    {
        private int m_Priority = 0;

        public virtual void Initialize(int priority)
        {
            m_Priority = priority;
        }

        public virtual void Update()
        {

        }

        public virtual void Destroy()
        {
            m_Priority = 0;
        }

        public virtual void Pause()
        {

        }

        public virtual void Resume()
        {

        }
        
    }
}

