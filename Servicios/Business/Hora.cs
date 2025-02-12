﻿using System;

namespace Base.Business {
	public struct Hora {
		public int seconds;

		public Hora(int seconds) {
			this.seconds = seconds;
		}

		public static Hora operator +(Hora a, Hora b) { return new Hora(a.seconds + b.seconds); }
		public static Hora operator -(Hora a, Hora b) { return new Hora(a.seconds - b.seconds); }

		public override string ToString() {
			string hh = Math.Floor(seconds / 3600f).ToString();

			
			string mm = Math.Floor((seconds / 60f)%60).ToString();

			string ss = (seconds % 60).ToString();

			if (hh.Length == 1) hh = "0" + hh;
			if (mm.Length == 1) mm = "0" + mm;
			if (ss.Length == 1) ss = "0" + ss;

			return string.Join(":", hh, mm, ss);
		}
	}
}
