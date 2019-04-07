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

namespace Game.Scenes
{
    class Level : Scene
    {
        public override void initialize()
        {
            clearColor = Color.Coral;
			addRenderer(new DefaultRenderer());

            var managerScene = createEntity("ManagerScene");
            managerScene.addComponent(new DebugScene());
			managerScene.addComponent(new LevelBehavior());

            // setup a pixel perfect screen that fits our map
            setDesignResolution(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);

            // render layer for all lights and any emissive Sprites
            var LIGHT_RENDER_LAYER = 5;

            // create a Renderer that renders all but the light layer and screen space layer
            addRenderer(new RenderLayerExcludeRenderer(0, LIGHT_RENDER_LAYER, 5));

            // create a Renderer that renders only the light layer into a render target
            var lightRenderer = addRenderer(new RenderLayerRenderer(-1, LIGHT_RENDER_LAYER));
            lightRenderer.renderTargetClearColor = new Color(10, 10, 10, 255);
            lightRenderer.renderTexture = new RenderTexture();

            // Create map
            LoadMap();
        }

        private void LoadMap()
        {
            var tiledEntity = createEntity("TileMap");
            var tiledMap = content.Load<TiledMap>(Content.Map.tiledMap);
            var objectLayer = tiledMap.getObjectGroup("entities");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledMap, "main"));

            LoadEntities(objectLayer);

            // Add compontent of collition with tilemap 
            var playerEntity = this.entities.findEntity("Player");
            if (playerEntity != null)
                playerEntity.addComponent(new TiledMapMover(tiledMapComponent.collisionLayer));

			var bugEntity = this.entities.findEntity("Bug");
			if (bugEntity != null)
				bugEntity.addComponent(new TiledMapMover(tiledMapComponent.collisionLayer));

		}

        private void LoadEntities(TiledObjectGroup objects)
        {
            var entities = objects.objects;

            foreach (var item in entities)
            {
                addEntity(EntityFactory.CreateEntity(item.name, new Vector2(item.x, item.y), item.width,item.height));
            }
        }
    }
}
