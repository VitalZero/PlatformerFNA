using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerFNAEnvato.ECS.Systems
{
    public abstract class System
    {
        private HashSet<int> registeredEntityIds;
        private List<Type> requiredComponents;

        protected System()
        {
            registeredEntityIds = new HashSet<int>();
            requiredComponents = new List<Type>();
        }

        public bool Matches(Entity entity)
        {
            foreach(var t in requiredComponents)
            {
                if (!entity.HasComponent(t))
                    return false;
            }

            return true;
        }

        public void UpdateEntityRegistry(Entity entity)
        {
            bool matches = Matches(entity);

            if(registeredEntityIds.Contains(entity.ID))
            {
                if(!matches)
                {
                    registeredEntityIds.Remove(entity.ID);
                }
            }
            else
            {
                if(matches)
                {
                    registeredEntityIds.Add(entity.ID);
                }
            }
        }

        protected void AddRequiredComponent<T>() where T : Component
        {
            requiredComponents.Add(typeof(T));
        }

        public void UpdateAll(float dt)
        {
        }
    }
}
