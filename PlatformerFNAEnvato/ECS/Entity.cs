using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS
{
    public class Entity
    {
        public int ID { get; set; }
        private List<Component> components = new List<Component>();

        public void Send(int message)
        {
            foreach (var c in components)
            {
                c.Receive(message);
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.entity = this;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach(var c in components)
            {
                if (c.GetType().Equals(typeof(T)))
                    return (T)c;
            }

            return null;
        }

        public bool HasComponent<T>()
        {
            foreach (var c in components)
            {
                if (c.GetType().Equals(typeof(T)))
                    return true;
            }

            return false;
        }

        public bool HasComponent(Type type)
        {
            foreach (var c in components)
            {
                if (c.GetType().Equals(type))
                    return true;
            }

            return false;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var c in components)
            {
                c.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var c in components)
            {
                c.Draw(spriteBatch);
            }
        }
    }
}
