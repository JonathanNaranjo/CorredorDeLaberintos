using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Game.Scenes;

namespace Game.Factories
{
    public class SceneFactory
    {
        public static Scene CreateScene(StateType type)
        {
            switch(type)
            {
                case StateType.IntroGame:
                    return new IntroGame();
                case StateType.MainMenu:
                    return new Menu();
                case StateType.GamePlay:
                    return new Level();
                case StateType.EndOfGame:
                    return new EndGame();
                case StateType.Credits:
                    return new Credits();
                case StateType.Config:
                    return new Config();
                default:
                    throw new ArgumentException("Scene type not supported");
            }
        }
    }
}
