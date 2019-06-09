using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Fichero que almacena todos los tipos enumeradores
    /// </summary>
    
	public enum AnimationType
	{
		Walk, Run, Idle, Attack, Death, Falling, Hurt, Jumping, Slide, Blink, Flip
	}

	public enum TagType
	{
		Environment = 1, TileMap, Item, Enemy, Player
	}

	public enum EntityType
	{
		Player, Background, Coin, Diamond, Score, Exit, Bug1, Bug2, Damage, TileMap, Mine, Puff
	}

	public enum StateType
	{
		IntroGame, MainMenu, Config, Credits, GamePlay, LoadLevel, EndOfGame
	}
}
