using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameOfLife
{
	class Grid
	{
		public Point Size { get; private set; }

		private Cell[,] cells;
		private bool[,] nextCellStates;

		private TimeSpan updateTimer;

		public Grid()
		{
			Size = new Point(Game1.CellsX, Game1.CellsY);

			cells = new Cell[Size.X, Size.Y];
			nextCellStates = new bool[Size.X, Size.Y];

			for (int i = 0; i < Size.X; i++)
			{
				for (int j = 0; j < Size.Y; j++)
				{
					cells[i, j] = new Cell(new Point(i, j));
					nextCellStates[i, j] = false;
				}
			}

			updateTimer = TimeSpan.Zero;
		}

		public void Clear()
		{
			for (int i = 0; i < Size.X; i++)
				for (int j = 0; j < Size.Y; j++)
					nextCellStates[i, j] = false;

			SetNextState();
		}

		public void Update(GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState();

			foreach (Cell cell in cells)
				cell.Update(mouseState);

			if (Game1.Paused)
				return;

			updateTimer += gameTime.ElapsedGameTime;

			if (updateTimer.TotalMilliseconds > 1000f / Game1.UPS)
			{
				updateTimer = TimeSpan.Zero;

				// Loop through every cell on the grid.
				for (int i = 0; i < Size.X; i++)
				{
					for (int j = 0; j < Size.Y; j++)
					{
						// Check the cell's current state, count its living neighbors, and apply the rules to set its next state.
						bool living = cells[i, j].IsAlive;
						int count = GetLivingNeighbors(i, j);
						bool result = false;

						if (living && count < 2)
							result = false;
						if (living && (count == 2 || count == 3))
							result = true;
						if (living && count > 3)
							result = false;
						if (!living && count == 3)
							result = true;

						nextCellStates[i, j] = result;
					}
				}

				SetNextState();
			}
		}

		public int GetLivingNeighbors(int x, int y)
		{
			int count = 0;

			// Check cell on the right.
			if (x != Size.X - 1)
				if (cells[x + 1, y].IsAlive)
					count++;

			// Check cell on the bottomw right.
			if (x != Size.X - 1 && y != Size.Y - 1)
				if (cells[x + 1, y + 1].IsAlive)
					count++;

			// Check cell on the bottom.
			if (y != Size.Y - 1)
				if (cells[x, y + 1].IsAlive)
					count++;

			// Check cell on the bottom left.
			if (x != 0 && y != Size.Y - 1)
				if (cells[x - 1, y + 1].IsAlive)
					count++;

			// Check cell on the left.
			if (x != 0)
				if (cells[x - 1, y].IsAlive)
					count++;

			// Check cell on the top left.
			if (x != 0 && y != 0)
				if (cells[x - 1, y - 1].IsAlive)
					count++;

			// Check cell on the top.
			if (y != 0)
				if (cells[x, y - 1].IsAlive)
					count++;

			// Check cell on the top right.
			if (x != Size.X - 1 && y != 0)
				if (cells[x + 1, y - 1].IsAlive)
					count++;

			return count;
		}

		public void SetNextState()
		{
			for (int i = 0; i < Size.X; i++)
				for (int j = 0; j < Size.Y; j++)
					cells[i, j].IsAlive = nextCellStates[i, j];
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Cell cell in cells)
				cell.Draw(spriteBatch);

			// Draw vertical gridlines.
			for (int i = 0; i < Size.X; i++)
				spriteBatch.Draw(Game1.Pixel, new Rectangle(i * Game1.CellSize - 1, 0, 1, Size.Y * Game1.CellSize), Color.DarkGray);

			// Draw horizontal gridlines.
			for (int j = 0; j < Size.Y; j++)
				spriteBatch.Draw(Game1.Pixel, new Rectangle(0, j * Game1.CellSize - 1, Size.X * Game1.CellSize, 1), Color.DarkGray);
		}
	}
}
