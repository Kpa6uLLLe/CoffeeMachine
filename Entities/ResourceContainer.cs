using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class ResourceContainer : ICloneable
    {
        private readonly float maxVolume;
        private float currentVolume = 0;

        public ResourceContainer(float maxVolume)
        {
            this.maxVolume = maxVolume;
        }
        public ResourceContainer(float maxVolume, float amount)
        {
            this.maxVolume = maxVolume;
            Add(amount);
        }
        public float Add(float amount)
        {
            if (currentVolume + amount <= maxVolume && currentVolume + amount > 0)
            {
                currentVolume += amount;
                return 0;
            }
            else if (currentVolume + amount < 0)
            {
                throw new NotEnoughResourcesException();
            }
            else
            {
                throw new NotEnoughSpaceException();
            }
        }

        public object Clone()
        {
            return new ResourceContainer(maxVolume, currentVolume);
        }

        public float GetCurrentVolume()
        {
            return currentVolume;
        }

        public override string ToString()
        {
            return $"{currentVolume}/{maxVolume} [{GetPercentage(currentVolume,maxVolume)}%]";
        }

        private float GetPercentage(float divisible, float divider)
        {
            return divisible / divider * 100;
        }
    }
}
