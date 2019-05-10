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

    public class EntityFactory
    {
        public static Entity CreateEntity(String typeEntity, Vector2 position, int width, int height)
        {
            EntityType type = (EntityType)Enum.Parse(typeof(EntityType), typeEntity);
            
            switch (type)
            {
                case EntityType.Background:
                    return new Background();
                case EntityType.Player:
                    return new Player(position);
				case EntityType.Bug:
					return new Bug(position);
                case EntityType.Coin:
                    return new Coin(position);
                case EntityType.Score:
                    return new Score();
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
