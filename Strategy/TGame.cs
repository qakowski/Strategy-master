using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Strategy
{
    public class TGame
    {
        
        public Timer Timer;
        public List<TCell> FreeCells = new List<TCell>();
        public List<Bitmap> TileImages = new List<Bitmap>();
        public List<Bitmap> ResImages = new List<Bitmap>();
        public List<Bitmap> ArtifactImages = new List<Bitmap>();
        public TCell[,] Cells;
        public static Random Random = new Random();
        public List<TPlayer> Players = new List<TPlayer>();
        public List<Color> PlayersColors = new List<Color>()
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Cyan,
            Color.Magenta,
            Color.Yellow
        };

        public int MaxPlayersCount = 4;
        public double ArtifactRatio = 0.05;
        public double ResRatio = 0.1;

        public TPlayer ActivePlayer;
        public THero ActiveHero;

        private Bitmap _map;
        public Bitmap Map
        {
            get
            {
                return _map;
            }

            set
            {
                _map = value;
                Cells = new TCell[_map.Height, _map.Width];

                for (int y = 0; y < _map.Height; y++)
                {
                    for (int x = 0; x < _map.Width; x++)
                    {
                        var cell = new TCell();
                        cell.Game = this;
                        cell.X = x;
                        cell.Y = y;

                        if (_map.GetPixel(x,y).R == 0)
                        {
                            var tile = new TTile();
                            tile.ImageIndex = Random.Next(TileImages.Count);
                            
                            cell.Piece = tile;
                        }else
                        {
                            FreeCells.Add(cell);
                        }
                        Cells[y, x] = cell;
                    }
                }
            }
        }

        public TGame([CallerFilePath] string filePath = null)
        {
            var path = Path.GetDirectoryName(filePath) + "/bin/debug";

            var files = Directory.GetFiles(path + "/Tiles", "*.bmp");
            
            foreach (var file in files)
            {
                TileImages.Add(readGraphics(file));
            }
            files = Directory.GetFiles(path + "/Resources", "*.bmp");
            foreach (var file in files)
            {
                ResImages.Add(readGraphics(file));
            }
            files = Directory.GetFiles(path + "/Artifacts", "*.bmp");
            foreach (var file in files)
            {
                ArtifactImages.Add(readGraphics(file));
            }

            Map = new Bitmap(path + "/map.bmp");
            
            Reset();

            for (int i = 0; i < MaxPlayersCount; i++)
            {
                var player = new TPlayer(this);
                player.ColorId = PlayersColors[i];
                Players.Add(player);
            }
            ActivePlayer = Players[MaxPlayersCount - 1];
            NextTurn();
        }

        public void NextTurn()
        {
            ActivePlayer = Players[(Players.IndexOf(ActivePlayer) + 1) % Players.Count];
            ActiveHero = ActivePlayer.Heroes[0];
        }

        public void Reset()
        {
            var resCount = ResRatio * FreeCells.Count;

            for (int i = 0; i < resCount; i++)
            {
                var index = Random.Next(FreeCells.Count);
                var cell = FreeCells[index];
                var res = new TResource();
                res.Type = (TResource.TResourceType)Random.Next(ResImages.Count);
                cell.Piece = res;
                FreeCells.RemoveAt(index);
            }

            var artifactCount = ArtifactRatio * FreeCells.Count;

            for (int i = 0; i < artifactCount; i++)
            {
                var index = Random.Next(FreeCells.Count);
                var cell = FreeCells[index];
                var artifact = new TArtifact();
                artifact.ImageIndex = Random.Next(ArtifactImages.Count);
                cell.Piece = artifact;
                FreeCells.RemoveAt(index);
            }
        }

        private Bitmap readGraphics(string fileName)
        {
            var bmp = new Bitmap(fileName);
            var pal = bmp.Palette;
            for (int i = 0; i < pal.Entries.Length; i++)
            {
                if (pal.Entries[i].ToArgb() == Color.Cyan.ToArgb())
                {
                    pal.Entries[i] = Color.FromArgb(0, 0, 0, 0);
                }
                if (pal.Entries[i].ToArgb() == Color.Magenta.ToArgb())
                {
                    pal.Entries[i] = Color.FromArgb(128, 0, 0, 0);
                }
                if ( (uint)pal.Entries[i].ToArgb() == 0xffff96ff)
                {
                    pal.Entries[i] = Color.FromArgb(0, 0, 0, 0);
                }
            }
            bmp.Palette = pal;
            return bmp;
        }
    }
}
