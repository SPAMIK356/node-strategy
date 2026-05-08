using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NodeStrategy
{
    public static class MapGenerator
    {
        public static void GenerateMap(TurnManager manager, int numberOfNodes, int mapWidth, int mapHeight, List<int> playerFactions)
        {
            Random rnd = new Random();

            List<string> cityNames = File.Exists("CityNames.txt") ? File.ReadAllLines("CityNames.txt").ToList() : new List<string> { "Арциз", "Київ", "Одеса", "Львів", "Дніпро", "Харків" };
            List<string> armyNames = File.Exists("ArmyNames.txt") ? File.ReadAllLines("ArmyNames.txt").ToList() : new List<string> { "Лісові тварюки", "Міська варта", "Найманці", "Ополчення" };

            List<Node> nodes = new List<Node>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                string cityName = cityNames.Count > 0 ? cityNames[rnd.Next(cityNames.Count)] : $"Місто {i}";
                cityNames.Remove(cityName);

                int x = rnd.Next(50, mapWidth - 50);
                int y = rnd.Next(50, mapHeight - 50);


                int randomFactor = rnd.Next(0, 101);

                int income = 30 + (randomFactor / 2);

                int militaryCap = rnd.Next(2,5);

                Node node = new Node(cityName, IDReg.NextID, 0) { X = x, Y = y };
                node.AddComponent(new EconomyComponent(income));
                node.AddComponent(new MilitaryComponent(militaryCap, 1));

                nodes.Add(node);
                manager.mapElements.Add(node.id, node);
            }

            HashSet<Node> connected = new HashSet<Node> { nodes[0] };
            HashSet<Node> unconnected = new HashSet<Node>(nodes.Skip(1));

            while (unconnected.Count > 0)
            {
                Node bestConnected = null;
                Node bestUnconnected = null;
                float minDistance = float.MaxValue;

                foreach (var c in connected)
                {
                    foreach (var u in unconnected)
                    {
                        float dist = MathF.Sqrt(MathF.Pow(c.X - u.X, 2) + MathF.Pow(c.Y - u.Y, 2));
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            bestConnected = c;
                            bestUnconnected = u;
                        }
                    }
                }

                Edge edge = new Edge($"Дорога {bestConnected.Name}-{bestUnconnected.Name}", IDReg.NextID, bestConnected, bestUnconnected, 1.0f, 1);
                bestConnected.TryConnect(bestUnconnected, edge);
                manager.mapElements.Add(edge.id, edge);

                connected.Add(bestUnconnected);
                unconnected.Remove(bestUnconnected);
            }

   
            int extraEdges = numberOfNodes / 5;
            for (int i = 0; i < extraEdges; i++)
            {
                var n1 = nodes[rnd.Next(nodes.Count)];
                var n2 = nodes[rnd.Next(nodes.Count)];
                if (n1 != n2 && !n1.IsConnected(n2))
                {
                    Edge extraEdge = new Edge($"Дорога {n1.Name}-{n2.Name}", IDReg.NextID, n1, n2, 1.5f, 1);
                    n1.TryConnect(n2, extraEdge);
                    manager.mapElements.Add(extraEdge.id, extraEdge);
                }
            }


            var shuffledNodes = nodes.OrderBy(n => rnd.Next()).ToList();

            foreach (int playerId in playerFactions)
            {
                Node startNode = shuffledNodes[0];
                shuffledNodes.RemoveAt(0);

                startNode.SetControl(playerId);

                string armyName = armyNames.Count > 0 ? armyNames[rnd.Next(armyNames.Count)] : $"Армія гравця {playerId}";
                armyNames.Remove(armyName);

                Army playerArmy = new Army(IDReg.NextID, 100, 1, 4, 100, playerId, startNode, armyName);
                startNode.AcceptArmy(playerArmy);
            }


            foreach (Node neutralNode in shuffledNodes)
            {
                string armyName = armyNames.Count > 0 ? armyNames[rnd.Next(armyNames.Count)] : "Ополчення";

                Army neutralArmy = new Army(IDReg.NextID, 50, 1, 4, 100, 0, neutralNode, armyName);
                neutralNode.AcceptArmy(neutralArmy);
            }
        }
    }
}