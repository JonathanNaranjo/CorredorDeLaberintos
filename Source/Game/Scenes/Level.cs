using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Game.Entities;
using Game.Components;
using Game.Factories;
using Game.Scenes.Base;

namespace Game.Scenes
{
    /// <summary>
    /// Escena que se encarga de cargar los niveles
    /// </summary>
    class Level : SceneBase
    {
        private Entity mapEntity;
        private TiledMap tiledMap;
        private TiledMapComponent mapLayer;

        public override void initialize()
        {
            base.initialize();

            // Create map
            LoadMap();
            LoadEntities();
            addEntity(new Score(this.canvas));
        }

        /// <summary>
        /// Carga un mapa de Tiled
        /// </summary>
		private void LoadMap()
        {
            mapEntity = createEntity(EntityType.TileMap.ToString());
            tiledMap = content.Load<TiledMap>(Content.Map.level1);
            mapLayer = mapEntity.addComponent(new TiledMapComponent(tiledMap, "Map"));

            // Camera bounds
            var topLeft = new Vector2(tiledMap.tileWidth, tiledMap.tileWidth);
            var bottomRight = new Vector2(tiledMap.tileWidth * (tiledMap.width - 1), tiledMap.tileWidth * (tiledMap.height - 1));
            mapEntity.addComponent(new CameraBounds(topLeft, bottomRight));
            mapEntity.tag = (int)TagType.TileMap;
            //mapLayer.renderLayer = 4;
        }

        /// <summary>
        /// Carga todas las entidades de un mapa
        /// </summary>
        /// <param name="ignorePlayer"></param>
        private void LoadEntities(bool ignorePlayer = false)
        {
            TiledObject[] entities = this.tiledMap.getObjectGroup("Entities").objects;

            foreach (var e in entities)
            {
                if (ignorePlayer && e.name.Equals(EntityType.Player.ToString()))
                    continue;
                else
                    addEntity(EntityFactory.CreateEntity(e.name, new Vector2(e.x, e.y), e.width, e.height));
            }
        }

        /// <summary>
        /// Reinicia el nivel
        /// </summary>
        public void RestartLevel()
        {
            var listaEntidades = this.findEntitiesWithTag((int)TagType.Item);
            listaEntidades.AddRange(this.findEntitiesWithTag((int)TagType.Enemy));
            listaEntidades.AddRange(this.findEntitiesWithTag((int)TagType.Environment));

            foreach (var e in listaEntidades)
            {
                e.components.removeAllComponents();
                this.entities.remove(e);
            }

            LoadEntities(true);
        }

        /// <summary>
        /// Establece una entidad para que sea colisionable
        /// </summary>
        /// <param name="entity"></param>
        public void SetMapCollition(Entity entity)
        {
            entity.addComponent(new TiledMapMover(mapLayer.collisionLayer));
        }

        public override void onStart()
        {
            SoundManager.PlayMusic(Content.Music.level1);
        }
        
            
    }
}
