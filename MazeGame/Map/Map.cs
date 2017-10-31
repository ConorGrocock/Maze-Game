using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGame.Entity;

namespace MazeGame.Map {
    class Map {
        Player player;
        Random rand = new Random();

        public String[][] screen;
        public String[][] map = {
            new String[]{ "┌", "─","─","─","─","─","─","─","─","─","─","─","─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "┐" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", "Dr", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", "|"," ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", "|"," ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", "|"," ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", "|"," ", " ", " ", "│" },
            new String[]{ "│", "Kb", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", "|"," ", " ", " ", "│" },
            new String[]{ "├", "─","─","─","─","─","─","─","─","─","─","─","─", "─", "─", "─", "Db", "─", "─", "─", "─", "─", "┤" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","|", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","|", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","Dg", "Kg", " ", " ", " ", " ", " ", "Kg", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","|", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","|", " ", " ", " ", " ", " ", " ", " ", "Kg", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," ","|", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "├", "─","─","─","─","─","─","─","─","─","─","─","─", "─", "─", "─", "Dg", "─", "─", "─", "─", "─", "┤" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
            new String[]{ "│", "Kr", " "," "," "," "," "," "," "," "," "," "," "," ", " ", " ", "E", " ", " ", " ", " ", " ", "│" },
            new String[]{ "└", "─","─","─","─","─","─","─","─","─","─","─","─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "┘" },
        };

        public Map(Player p) {
            this.player = p;
            int mapwidth = map[0].Length;
            this.screen = new String[map.Length][];
            for (int i = 0; i < screen.Length; i++) {
                screen[i] = new string[map[i].Length];
            }
            
        }

        public void randomPlacement() {
            //Spawn Gold
            for (int i = 0; i < rand.Next(15, 25); i++) {
                int x = rand.Next(map.Length), y = rand.Next(map[x].Length);
                if (placementCheck(x, y)) map[x][y] = "GG";
            }
            //Spawn Enemys
            for (int i = 0; i < rand.Next(5, 10); i++) {
                int x = rand.Next(map.Length), y = rand.Next(map[x].Length);
                if (placementCheck(x, y)) Program._instance.enemys.Add(new Enemy(Program._instance, x, y));
            }
        }

        private bool placementCheck(int x, int y) {
            if (map[x][y] == " ") return true;
            return false;
        }

        public void Draw() {
            map[this.player.x][this.player.y] = this.player.icon;

            foreach (Enemy enemy in this.player.game.enemys) {
                map[enemy.x][enemy.y] = enemy.icon;
            }
            for (int i = 0; i < map.Length; i++) {
                for (int j = 0; j < map[i].Length; j++) {
                    //if (screen[i][j] == map[i][j]) continue;
                    if (map[i][j].Length > 1) {
                        switch (map[i][j][1]) {
                            case ('r'): {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                }
                            case ('g'): {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                }
                            case ('b'): {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                }
                            case ('G'): {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                }
                            case ('c'): {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                }
                            case ('w'): {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }

                        }
                    }
                    Console.SetCursorPosition(j, i);
                    Console.Write(map[i][j][0]);
                    Console.ResetColor();

                }
                Console.WriteLine();
            }

            map[this.player.x][this.player.y] = " ";
            foreach (Enemy enemy in this.player.game.enemys) {
                map[enemy.x][enemy.y] = " ";
            }

            screen = map;
            Program._instance.postMapDraw();
        }
    }
}
