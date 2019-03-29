﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer.SMZ3 {

    class World {

        public List<Location> Locations { get; set; }
        public List<Region> Regions { get; set; }
        public List<Item> Items { get; set; }
        public Logic Logic { get; set; }
        public string Player { get; set; }

        public World(Logic logic, string player) {
            Logic = logic;
            Player = player;

            Regions = new List<Region> {
                new Regions.SuperMetroid.Crateria.Central(this, Logic),
                new Regions.SuperMetroid.Crateria.West(this, Logic),
                new Regions.SuperMetroid.Crateria.East(this, Logic),
                new Regions.SuperMetroid.Brinstar.Blue(this, Logic),
                new Regions.SuperMetroid.Brinstar.Green(this, Logic),
                new Regions.SuperMetroid.Brinstar.Kraid(this, Logic),
                new Regions.SuperMetroid.Brinstar.Pink(this, Logic),
                new Regions.SuperMetroid.Brinstar.Red(this, Logic),
                new Regions.SuperMetroid.Maridia.Outer(this, Logic),
                new Regions.SuperMetroid.Maridia.Inner(this, Logic),
                new Regions.SuperMetroid.NorfairUpper.West(this, Logic),
                new Regions.SuperMetroid.NorfairUpper.East(this, Logic),
                new Regions.SuperMetroid.NorfairUpper.Crocomire(this, Logic),
                new Regions.SuperMetroid.NorfairLower.West(this, Logic),
                new Regions.SuperMetroid.NorfairLower.East(this, Logic),
                new Regions.SuperMetroid.WreckedShip(this, Logic)
            };

            Locations = Regions.SelectMany(x => x.Locations).ToList();
            Items = new List<Item>();
        }

        public bool CanEnter(string regionName, List<Item> items) {
            var region = Regions.Find(r => r.Name == regionName);
            if (region != null)
                return region.CanEnter(items);
            else
                throw new ArgumentException("World.CanEnter: Invalid region name " + regionName);
        }

    }

}