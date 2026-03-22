using Project_Orin.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Orin.Core
{
    public class Element : IWorldElement
    {
        public string? Name { get; set; }
        public IWorldElement Parent { get; set; }
        public List<IComponent> Components { get; set; } = new List<IComponent>();

        public Element(string name)
        {
            Name = name;
        }
        public void AddComponent(IComponent component)
        {
            Components.Add(component);
            component.OnAttach(this);
        }

        public IComponent GetComponent(string name)
        {
            return Components.Find(c => c.Name == name);
        }

        public void RemoveComponent(string name)
        {
            var component = GetComponent(name);
            if (component != null)
            {
                Components.Remove(component);
                component.OnDetach(this);
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var component in Components)
            {
                component.OnUpdate(deltaTime);
            }
        }

        public void SetParent(IWorldElement parent)
        {
            Parent = parent;
        }

        public void RemoveParent()
        {
            Parent = null;
        }

        public void ClearComponents()
        {
            foreach (var component in Components)
            {
                component.OnDetach(this);
            }
            Components.Clear();
        }

        public void Clear()
        {
            ClearComponents();
            RemoveParent();
        }

        public override string ToString()
        {
            return $"Element: {Name}, Components: {Components.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Element other)
            {
                return Name == other.Name && Components.Count == other.Components.Count;
            }
            return false;
        }
    }
}
