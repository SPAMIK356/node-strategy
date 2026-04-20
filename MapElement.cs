using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    abstract class MapElement
    {
        public virtual bool AddComponent(Component component)
        {
            components.Add(component);
            return true;
        }
        public virtual T? GetComponent<T>() where T : Component
        {
            return components.OfType<T>().FirstOrDefault();
        }
        public string Name { get; protected set; }
        protected List<Component> components;
        public int id;
        public virtual int controledBy { get; protected set; }
        public MapElement(string name, int id)
        {
            components = new List<Component>();
            Name = name;
            this.id = id;
        }
        public abstract void OnTurnEnd();

        public abstract bool AcceptArmy(Army army);
        public abstract bool CanAcceptArmy(Army army);

        public abstract bool TryRemoveArmy(Army army);

    }
}
