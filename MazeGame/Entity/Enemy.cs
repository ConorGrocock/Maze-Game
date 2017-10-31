using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Entity {
    class Enemy : Entity {
        int intelligence = 5;

        public Enemy(Program game, int x, int y) {
            this.game = game;
            this.x = x;
            this.y = y;
            icon = "■r";
        }

        public void update() {
            if(rand.Next(0,5) <= intelligence) {
                if (game.p.x - x > 0) if (checkMove(x + 1, y)) x++; else if (checkMove(x - 1, y)) x--;
                if (game.p.x - x < 0) if (checkMove(x - 1, y)) x--; else if (checkMove(x + 1, y)) x++;
                if (game.p.y - y > 0) if (checkMove(x, y + 1)) y++; else if (checkMove(x, y - 1)) y--;
                if (game.p.y - y < 0) if (checkMove(x, y - 1)) y--; else if (checkMove(x, y + 1)) y++;

                return;
            }

            int move = rand.Next(0, 5);
            switch (move) {
                case (0): {
                        if (checkMove(x - 1, y)) x--;
                        break;
                    }
                case (1): {
                        if (checkMove(x + 1, y)) x++;
                        break;
                    }
                case (2): {
                        if (checkMove(x, y - 1)) y--;
                        break;
                    }
                case (3): {
                        if (checkMove(x, y + 1)) y++;
                        break;
                    }
                case (4): {
                        break;
                    }
                default: {
                        Console.Write("YOU FUCKED UP");
                        break;
                    }
            }

            if (x == game.p.x && y == game.p.y) {
                game.gameOver = true;
            }
        }
    }
}
