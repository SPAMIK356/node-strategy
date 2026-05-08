using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public abstract class MapElement
    {
        public virtual int GoldGain { get => 0; }
        public abstract bool isContested { get; }
        public virtual bool AddComponent(Component component)
        {
            component.parent = this;
            components.Add(component);
            return true;
        }
        public virtual T? GetComponent<T>() where T : Component
        {
            return components.OfType<T>().FirstOrDefault();
        }
        public virtual T[] GetComponents<T>()
        {
            return components.OfType<T>().ToArray();
        }
        public string Name { get; protected set; }
        protected List<Component> components;
        public int id { get; protected set; }
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

        public virtual string GetDescription()
        {
            return $"ID: {id}\n" +
                $"Контролюється фракцією {controledBy}\n";
        }
    }
}
