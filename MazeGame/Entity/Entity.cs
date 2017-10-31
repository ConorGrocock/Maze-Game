using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Entity {
    class Entity {
        public int x, y;
        public String icon;
        public Program game;
        public static Random rand = new Random();


        public virtual bool checkMove(int x, int y) {

            if (this.game.m.map[x][y][0] == ' ') {
                return true;
            }
            if (this.game.m.map[x][y][0] == '@') {
                game.p.die();
                return false;
            }
            if (this.game.m.map[x][y][0] == '?') {
                game.p.die();
                return false;
            }
            return false;
        }

    void update() {

    }
}
}
