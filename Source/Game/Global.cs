using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public enum TypeAnimation
	{
		Walk, Run, Idle, Attack, Death, Falling, Hurt, Jumping, Slide, Blink, Flip
	}

	public enum TagType
	{
		Environment = 1, TileMap, Item, Enemy, Player
	}

	public enum EntityType
	{
		Player, Background, Coin, Diamond, Score, Exit, Bug1, Bug2, Damage, TileMap, Mine
	}

	public enum StateType
	{
		IntroGame, MainMenu, Config, Credits, GamePlay, LoadLevel, EndOfGame
	}


	public enum RenderLayer
    {
        AboveDetailShadow = -2,
        AboveDetail = -1,
        Player = 1,
        TileMap = 10,
        ScreenSpace = 999
    }

    public static class Global
    {
        public const int TILE_SIZE = 16;
        public static float Volume = 0.2f;
    }
}
