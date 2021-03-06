// Copyright 2017 Declan Hoare
// This file is part of Whoa.
//
// Whoa is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Whoa is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with Whoa.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Drawing;
using Whoa;

namespace Whoa.Tests
{
	public static class Test
	{
		private enum RecordType
		{
			Single,
			EP,
			LP
		}
		
		[Flags]
		private enum Details
		{
			Catchy = 1,
			Popular = 2,
			Terrible = 4
		}
		
		private class Record
		{
			
			public string title;
			
			
			public string artist;
			
			
			public int rpm { get; set; }
			
			
			public double price;
			
			
			public bool inLibrary;
			
			
			public bool otherBool;
			
			
			public List<string> songs;
			
			
			public Guid guidForSomeReason;
			
			
			public List<bool> moreBools;
			
			
			public string awards;
			
			
			public int? profits;
			
			
			public int? losses;
			
			
			public List<int> somethingElse;
			
			
			public Dictionary<string, string> staff;
			
			
			public Dictionary<string, string> plausibleSampleData;
			
			
			public List<bool> notActuallyMoreBools;
			
			
			public bool boolThree;
			
			
			public bool boolFour;
			
			
			public bool boolFive;
			
			
			public bool boolSix;
			
			
			public bool boolSeven;
			
			
			public bool boolEight;
			
			
			public BigInteger reallyReallyReallyReallyReallyReallyBigNumber;
			
			
			public DateTime releaseDate;
			
			
			public RecordType kind;
			
			
			public Details details;
			
			
			public string[] thisIsAnArrayNotAList;
			
			public Image img;
			
			public Color colour;
			
			public Font font;
			
			public Stream data;
			
			public override string ToString()
			{
				string ret = $@"{title}
Artist: {artist}
RPM: {rpm}
Price: {price}
Released: {releaseDate}
";
				ret += (inLibrary ? "In" : "Not in") + " library" + Environment.NewLine;
				ret += "Something else about it: " + (otherBool ? "Yep" : "Nope") + Environment.NewLine;
				ret += "Songs:" + Environment.NewLine;
				int track = 0;
				foreach (string song in songs)
					ret += $"{++track}. {song}" + Environment.NewLine;
				ret += $"Guid (?!): {guidForSomeReason}" + Environment.NewLine;
				ret += "Some more information:" + Environment.NewLine;
				foreach (bool info in moreBools)
					ret += (info ? "Yes" : "No") + Environment.NewLine;
				ret += "Awards: " + (awards == null ? "N/A" : awards) + Environment.NewLine;
				ret += "Profits: " + (profits == null ? "N/A" : profits.ToString()) + Environment.NewLine;
				ret += "Losses: " + (losses == null ? "N/A" : losses.ToString()) + Environment.NewLine;
				ret += "Null lists work: " + (somethingElse == null ? "Yes" : "No") + Environment.NewLine;
				ret += "Staff:" + Environment.NewLine;
				foreach (var pair in staff)
					ret += $"{pair.Key} - {pair.Value}" + Environment.NewLine;
				ret += "Null dictionaries work: " + (plausibleSampleData == null ? "Yes" : "No") + Environment.NewLine;
				ret += "Null bool lists work: " + (notActuallyMoreBools == null ? "Yes" : "No") + Environment.NewLine;
				byte[] buf = new byte[data.Length];
				data.Read(buf, 0, buf.Length);
				ret += $@"boolThree = {boolThree}
boolFour = {boolFour}
boolFive = {boolFive}
boolSix = {boolSix}
boolSeven = {boolSeven}
boolEight = {boolEight}
A number that is so shockingly large that you won't believe how large it is, even though it doesn't mean anything: {reallyReallyReallyReallyReallyReallyBigNumber}
Category: {kind}.
Is catchy: {details.HasFlag(Details.Catchy)}.
Is popular: {details.HasFlag(Details.Popular)}.
Is terrible: {details.HasFlag(Details.Terrible)}.
The second entry of an array that isn't a list is: {thisIsAnArrayNotAList[1]}
{img.Width}
{colour.R} {colour.G} {colour.B} {colour.A}
{font}
{System.Text.Encoding.UTF8.GetString(buf)}
";
				return ret;
			}
		}
		public static void Main(string[] args)
		{
			using (var str = args.Length > 0 ? (File.Open(args[0], FileMode.Create) as Stream) : (new MemoryStream() as Stream))
			{
				var rec = new Record()
				{
					title = "Cool Songs For Cool People",
					artist = "Ethan Klein",
					rpm = 78,
					price = 99.99,
					inLibrary = true,
					otherBool = true,
					songs = new string[]
					{
						"International Tiles",
						"Test Data",
						"Bonus Track",
						"Casin"
					}.ToList(),
					guidForSomeReason = Guid.NewGuid(),
					moreBools = new bool[] {true, false, false, true, true, true, false, false, true, true}.ToList(),
					awards = null,
					profits = 5000,
					losses = null,
					somethingElse = null,
					staff = new Dictionary<string, string>
					{
						{"Ethan Klein", "Artist"},
						{"Post Malone", "Featured Artist"},
						{"Frank Walker", "Tile Provider"},
						{"This is some", "test data"}
					},
					plausibleSampleData = null,
					notActuallyMoreBools = null,
					boolThree = false,
					boolFour = true,
					boolFive = false,
					boolSix = true,
					boolSeven = false,
					boolEight = true,
					reallyReallyReallyReallyReallyReallyBigNumber = BigInteger.Parse("41290871590318501381209471092481204"),
					releaseDate = new DateTime(2015, 04, 20),
					kind = RecordType.EP,
					details = Details.Catchy | Details.Popular,
					thisIsAnArrayNotAList = new string[]
					{
						"The freedom to run the program as you wish, for any purpose (freedom 0).",
						"The freedom to study how the program works, and change it so it does your computing as you wish (freedom 1). Access to the source code is a precondition for this.",
						"The freedom to redistribute copies so you can help your neighbor (freedom 2).",
						"The freedom to distribute copies of your modified versions to others (freedom 3). By doing this you can give the whole community a chance to benefit from your changes. Access to the source code is a precondition for this."
					},
					img = new Bitmap(800, 600),
					colour = Color.FromArgb(255, 127, 0),
					font = new Font("Times New Roman", 12),
					data = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("what's up, gamers?"))
				};
				string expected = rec.ToString();
				Whoa.SerialiseObject(str, rec, SerialisationOptions.NonSerialized);
				str.Position = 0;
				var res = Whoa.DeserialiseObject<Record>(str, SerialisationOptions.NonSerialized);
				string actual = res.ToString();
				Console.Write("Test ");
				if (expected == actual)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("passed");
					Console.ResetColor();
					Console.Write(actual);
					Environment.Exit(0);
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("FAILED");
					Console.ResetColor();
					Console.WriteLine("Expected:");
					Console.Write(expected);
					Console.WriteLine("");
					Console.WriteLine("Actual:");
					Console.Write(actual);
					Environment.Exit(1);
				}
			}
		}
	}
}
