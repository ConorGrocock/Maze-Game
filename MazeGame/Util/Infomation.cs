using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGame.Entity;
using MazeGame.Map;
using MazeGame;

namespace MazeGame.Util {
    class Infomation {
        Program game;
        
        int colWidth = 12;

        public Infomation() {
            game = Program._instance;
        }

        public void Show(int column, int row, string data, ConsoleColor color = ConsoleColor.Gray) {
            Console.SetCursorPosition(column * colWidth, (game.m.map.Length + 1) + row);
            if (data.Length - 1 > colWidth) throw new ArgumentOutOfRangeException();
            
            Console.ForegroundColor = color;
            Console.Write(data);
            Console.ResetColor();
        }

        public void Show(int column, params string[] data) {
            Console.SetCursorPosition(column * colWidth, (game.m.map.Length + 1));
            for (int i = 0; i < data.Length; i++) {
                Show(column, i, data[i]);
            }
            Console.ResetColor();
        }
    }
}
