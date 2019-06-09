using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace Game.Components
{
    /// <summary>
    /// Componente lanza eventos en un intervalo de tiempo
    /// </summary>
    class TimeEvent : Component, IUpdatable
    {
        readonly float refreshTime;
        float previousRefreshTime;
        public event EventHandler Interval;
        private bool active;
        public bool Active
        {
            get => this.active;
            set => this.active = value;
        }

        public TimeEvent(float refreshTime)
        {
            this.refreshTime = refreshTime;
            this.active = false;
            
        }

        public override void onAddedToEntity()
        {
            previousRefreshTime = Time.time;
        }

        void IUpdatable.update()
        {
            if (active)
            {
                if (Time.time - previousRefreshTime > refreshTime)
                {
                    previousRefreshTime = Time.time;

                    OnInterval(new EventArgs());
                }
            }
        }

        protected virtual void OnInterval(EventArgs e)
        {
            Interval?.Invoke(this, e);
        }
    }
}
