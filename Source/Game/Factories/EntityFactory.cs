using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game.Entities;
using Nez;


namespace Game.Factories
{
    /// <summary>
    /// Crea las entidades del juego
    /// </summary>
    public class EntityFactory
    {
        public static Entity CreateEntity(String typeEntity, Vector2 position, int width, int height)
        {
            EntityType type = (EntityType)Enum.Parse(typeof(EntityType), typeEntity);
            
            switch (type)
            {
                case EntityType.Player:
                    return new Player(position);
				case EntityType.Bug1:
					return new Bug1(position);
                case EntityType.Bug2:
                    return new Bug2(position);
                case EntityType.Coin:
                    return new Coin(position);
				case EntityType.Exit:
					return new Exit(position, width, height);
				case EntityType.Damage:
					return new Damage(position, width, height);
                case EntityType.Diamond:
                    return new Diamond(position);
				case EntityType.Mine:
					return new Mine(position);
				default:
                    throw new ArgumentException("Entity type not supported");
            }
        }
    }
}
