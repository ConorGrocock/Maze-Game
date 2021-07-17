using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGame.Entity;
using MazeGame.Map;
using MazeGame.Util;

namespace MazeGame {
    class Program {
        public static Program _instance = null;
        public Player player;
        public Map.Map m;
        public Infomation info;
        public List<Enemy> enemys;
        public bool gameOver = false;
        public bool gameWon = false;

        static void Main(string[] args) {
            Console.CursorVisible = false;
            if (_instance == null) _instance = new Program();
            Console.SetWindowSize(100, 40);

            bool selected = false;
            int selectedIndex = 0;
            while(!selected) {
                Console.Clear();
                if (selectedIndex == 0) {
                    Console.WriteLine("> Play <");
                }
                else {
                    Console.WriteLine("  Play");
                }
                if (selectedIndex == 1) {
                    Console.WriteLine("> Help <");
                }
                else {
                    Console.WriteLine("  Help");
                }
                if (selectedIndex == 2) {
                    Console.WriteLine("> Quit <");
                }
                else {
                    Console.WriteLine("  Quit");
                }

                ConsoleKeyInfo input = Console.ReadKey();
                if(input.Key == ConsoleKey.Spacebar || input.Key == ConsoleKey.Enter) {
                    if(selectedIndex == 0) {
                        Console.Clear();
                        _instance.game();
                        selected = true;
                    }
                    if (selectedIndex == 1) {
                        Console.Clear();
                        selected = true;
                        Console.WriteLine("Not done");
                    }
                    if (selectedIndex == 2) {
                        return;
                    }

                }

                if (input.Key == ConsoleKey.UpArrow) {
                    selectedIndex--;
                    if (selectedIndex == -1) selectedIndex = 2;
                }
                if (input.Key == ConsoleKey.DownArrow) {
                    selectedIndex++;
                    if (selectedIndex == 3) selectedIndex = 0;
                }
            }
            Main(args);
        }

        public void game() {
            this.player = new Player(this, 5, 5);
            this.m = new Map.Map(this.player);
            this.enemys = new List<Enemy>();
            this.info = new Infomation();

            m.randomPlacement();

            this.enemys.Add(new Enemy(this, 2, 2));
            this.enemys.Add(new Enemy(this, 2, 5));
            this.enemys.Add(new Enemy(this, 4, 1));
            this.enemys.Add(new Enemy(this, 5, 2));

            while (!gameOver) {
                m.Draw();
                player.update();
            }

            Console.Clear();
            if (!gameWon) {
                Console.WriteLine("Game over");
                Console.WriteLine("You suck");
            } else {
                Console.WriteLine("Game over");
                Console.WriteLine("You collected {0} gold.", player.gold);
                Console.WriteLine("You collected {0} Red, {1} Green, and {2} Blue keys.", player.keys['r'], player.keys['g'], player.keys['b']);
            }
            Console.Read();
        }

        public void updateEnemy() {
            foreach (Enemy enemy in enemys) {
                enemy.update();
            }
        }

        public void postMapDraw() {
            player.postMapDraw();
        }
    }
}
