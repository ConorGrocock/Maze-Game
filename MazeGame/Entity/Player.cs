using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Entity {
    class Player : Entity {
        public int gold = 0;
        public Dictionary<char, int> keys = new Dictionary<char, int>();

        public Player(Program game, int x, int y) {
            this.x = x;
            this.y = y;
            this.game = game;
            icon = "@";

            keys.Add('r', 0);
            keys.Add('g', 0);
            keys.Add('b', 0);
        }

        public void update() {
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();
            if (keyinfo.Key == ConsoleKey.UpArrow) {
                if (checkMove(x - 1, y)) this.x--;
            }
            if (keyinfo.Key == ConsoleKey.DownArrow) {
                if (checkMove(x + 1, y)) this.x++;
            }
            if (keyinfo.Key == ConsoleKey.LeftArrow) {
                if (checkMove(x, y - 1)) this.y--;
            }
            if (keyinfo.Key == ConsoleKey.RightArrow) {
                if (checkMove(x, y + 1)) this.y++;
            }
            game.updateEnemy();
        }


        public override bool checkMove(int x, int y) {
            if (base.checkMove(x, y))
                return true;
            if (this.game.m.map[x][y][0] == 'G') {
                gold++;
                return true;
            }
            if (this.game.m.map[x][y][0] == 'D') {
                if (keys[this.game.m.map[x][y][1]] > 0) {
                    keys[this.game.m.map[x][y][1]]--;
                    return true;
                }
            }
            if (this.game.m.map[x][y][0] == 'E') {
                game.gameOver = true;
                game.gameWon = true;
                return true;
            }
            if (this.game.m.map[x][y][0] == 'K') {
                keys[this.game.m.map[x][y][1]]++;
                return true;
            }
            return false;
        }

        public void die() {
            game.gameOver = true;
        }

        public void postMapDraw() {
            game.info.Show(0, 0, "Gold: " + gold);
            game.info.Show(0, 1, "Enemies: " + game.enemys.Count);
            game.info.Show(1, "Keys", "Red:" + keys['r'], "Green:" + keys['g'], "Blue:" + keys['b']);

            //#if DEBUG
            //            Console.WriteLine(System.Environment.NewLine + "--Debug--");
            //            Console.WriteLine("Player X:" + x + "  Y:" + y);
            //#endif

        }
    }
}
