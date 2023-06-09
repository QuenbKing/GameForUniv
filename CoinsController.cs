﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public static class CoinsController
    {
        public static List<Coins> coinsList;
        public static int coinsCount = 1;
        public static int money;

        public static void CreateCoins()
        {
            if (coinsList.Count < coinsCount)
            {
                var coin = new Coins();
                CreatePosition(coin);
                coinsList.Add(coin);
            }
        }

        public static void CreatePosition(Coins coin)
        {
            var rnd = new Random();
            coin.location = new Point(rnd.Next(0, Screen.PrimaryScreen.Bounds.Width - coin.size.Width),
                -rnd.Next((int)(Screen.PrimaryScreen.Bounds.Height / 5.4), (int)(Screen.PrimaryScreen.Bounds.Height / 1.67)));
        }

        public static void MoveCoins(Player player)
        {
            if (coinsList.Count > 0)
            {
                for (int i = 0; i < coinsCount; i++)
                {
                    if (coinsList[i].CheckContactPlayerWithCoin(player) && coinsList[i].location.Y < Screen.PrimaryScreen.Bounds.Height)
                    {
                        money += 10;
                        coinsList.RemoveAt(i);
                    }
                    else if (coinsList[i].location.Y >= Screen.PrimaryScreen.Bounds.Height)
                        coinsList.RemoveAt(i);
                    else
                        coinsList[i].location.Y += coinsList[i].speed;
                }

            }
        }
    }
}