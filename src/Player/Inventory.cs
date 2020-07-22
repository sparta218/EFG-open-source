using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using EvilFarmingGame.Items;

namespace EvilFarmingGame.Player
{
	public class Inventory
	{
		public List<Item> Items = new List<Item>(5);
		public Item HeldItem;

		public int HeldSlot = 0;

		public Item this[int index]
		{
			get { return this.Items[index]; }
			set { this.Items[index] = value; }
		}

		public void Gain(Item item)
		{
			if(Items.Count < Items.Capacity)
				Items.Add(item);
		}

		public void Remove(Item item)
		{
			if (Items.Count > 0)
				Items.Remove(item);
		}

	}
}
